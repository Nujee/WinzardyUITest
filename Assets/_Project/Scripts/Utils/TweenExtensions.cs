using UnityEngine;
using DG.Tweening;

public static class TweenExtensions
{
    public static void ScaleWithBounce(this Transform transform, ScaleData scaleData)
    {
        var originalScale = transform.localScale;
        transform.DOKill();
        transform.DOScale(originalScale * scaleData.ScaleFactor, scaleData.Duration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                transform.DOScale(originalScale, scaleData.Duration)
                    .SetEase(Ease.OutBack);
            });
    }

    public static Tween ShowWithBounce(this Transform transform, ShowData showData)
    {
        var originalScale = transform.localScale;
        transform.localScale = Vector2.zero;
        var tween = transform.DOScale(originalScale, showData.Duration)
            .SetDelay(showData.Delay)
            .SetEase(Ease.OutBack);

        return tween;
    }
}