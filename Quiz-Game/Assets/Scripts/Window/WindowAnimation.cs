using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Window
{
    public abstract class WindowAnimation : MonoBehaviour
    {
        public abstract UniTask ShowAnimation(CancellationToken ct);

        public abstract UniTask HideAnimation(CancellationToken ct);
    }
}