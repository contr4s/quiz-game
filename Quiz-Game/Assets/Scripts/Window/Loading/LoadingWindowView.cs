using Cysharp.Threading.Tasks;
using UnityEngine;
using Window.Common;

namespace Window.Loading
{
    public class LoadingWindowView : CanvasWindowView<LoadingWindowAdapter>
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private RectTransform _loadingContainer;
        [SerializeField] private RectTransform _loadingBar1;
        [SerializeField] private RectTransform _loadingBar2;

        protected override void SetAdapter(LoadingWindowAdapter adapter)
        {
            base.SetAdapter(adapter);
            adapter.Load();
        }

        public override void InstantlyShow()
        {
            base.InstantlyShow();
            LoadingAnimation().Forget();
        }

        private async UniTaskVoid LoadingAnimation()
        {
            float size = _loadingContainer.rect.width;
            _loadingBar1.transform.localPosition = new Vector3(0, 0, 0);
            _loadingBar2.transform.localPosition = new Vector3(-size, 0, 0);
            float startPos = _loadingContainer.transform.position.x;
            int cnt = 1;
            while (IsShown) {
                _loadingContainer.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
                if (_loadingContainer.transform.position.x > startPos + size * cnt)
                {
                    cnt++;
                    _loadingBar1.transform.localPosition = _loadingBar2.transform.localPosition;
                    _loadingBar2.transform.localPosition = new Vector3(-size * cnt, 0, 0);
                }
                await UniTask.Yield();
            }
        }
    }
}