using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using Util;

namespace Quiz
{
    public class QuizJsonParser
    {
        private const string DataPath = "QuizData";
        
        private readonly string _jsonPath;
        private readonly ImageLoader _imageLoader;
        
        public QuizModel Quiz { get; private set; }
        
        public QuizJsonParser(string jsonPath, ImageLoader imageLoader)
        {
            _jsonPath = jsonPath;
            _imageLoader = imageLoader;
        }
        
        public async UniTask Parse(CancellationToken ct)
        {
            string json = await File.ReadAllTextAsync(GetFullPath(_jsonPath), ct);
            var questions = JsonConvert.DeserializeObject<QuizQuestion[]>(json);
            Quiz = new QuizModel(questions);
            foreach (QuizQuestion quizQuestion in Quiz.QuizQuestions)
            {
                quizQuestion.BackgroundTexture = await _imageLoader.FromFile(GetFullPath(quizQuestion.BackgroundPath), ct);
            }
        }

        private static string GetFullPath(string path) => Path.Combine(Application.dataPath, DataPath, path);
    }
}