using UnityEngine;
using Zenject;

namespace Quiz
{
    public class QuizInstaller : MonoInstaller
    {
        [SerializeField] private string _jsonFilePath;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_jsonFilePath).WhenInjectedInto<QuizJsonParser>();
            Container.BindInterfacesAndSelfTo<QuizJsonParser>().AsSingle();
        }
    }
}