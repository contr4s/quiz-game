using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Window.Animation
{
    public class FadeAnimation : WindowAnimation
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeInTime;
        [SerializeField] private float _fadeOutTime;
        
        public override async UniTask ShowAnimation(CancellationToken ct)
        {
            var startTime = Time.time;
            while (startTime + _fadeInTime > Time.time)
            {
                _canvasGroup.alpha = (Time.time - startTime) / _fadeInTime;
                await UniTask.Yield();

                if (ct.IsCancellationRequested)
                {
                    _canvasGroup.alpha = 0;
                    break;
                }
            }
            
            _canvasGroup.alpha = 1;
        }

        public override async UniTask HideAnimation(CancellationToken ct)
        {
            var startTime = Time.time;
            while (startTime + _fadeOutTime > Time.time)
            {
                _canvasGroup.alpha = 1 - (Time.time - startTime) / _fadeOutTime;
                await UniTask.Yield();
                
                if (ct.IsCancellationRequested)
                {
                    _canvasGroup.alpha = 1;
                    break;
                }
            }
            
            _canvasGroup.alpha = 0;
        }
    }
}