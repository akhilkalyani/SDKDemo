using GF;
using TPSDK.Enums;
using UnityEngine;
using DG.Tweening;
namespace TPSDK.UIScreens
{
    public class SplashScreenUI : BaseScreen<SplashScreenType>
    {
        [SerializeField] private RectTransform _logoRectTransform;
        protected override void OnEnable()
        {
            base.OnEnable();
            _logoRectTransform.DOScale(new Vector3(0,0,0), 0.4f)
                .SetEase(Ease.Flash)
                .OnComplete(() =>
                {
                    _logoRectTransform.DOKill();
                    Utils.RaiseEventAsync(new LoadingEvent(()=> SwitchScreen(SplashScreenType.Login)));
                });
        }
    }
}
