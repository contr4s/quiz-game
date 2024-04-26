using System.Collections.Generic;
using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Util
{
    public class ImageLoader
    {
        private readonly Dictionary<string, Texture2D> _cachedTextures = new();
        
        public async UniTask<Texture2D> FromFile(string pathToImage, CancellationToken cancellationToken)
        {
            if (_cachedTextures.TryGetValue(pathToImage, out Texture2D texture2D))
                return texture2D;

            byte[] bytes = await File.ReadAllBytesAsync(pathToImage, cancellationToken);
            Texture2D result = new Texture2D(2, 2) { name = pathToImage };
            result.LoadImage(bytes);
            _cachedTextures.Add(pathToImage, result);
            return result;
        }
    }
}