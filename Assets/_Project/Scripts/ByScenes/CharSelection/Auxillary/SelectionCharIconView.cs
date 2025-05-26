using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[DisallowMultipleComponent]
public sealed class SelectionCharIconView : MonoBehaviour
{
    [field: SerializeField] public Image Icon { get; private set; }
    [field: SerializeField] public Slider ExpSlider { get; private set; }

    public void UpdateIcon(Sprite newIcon, float duration)
    {
        Icon.DOKill();
        Icon.DOFade(0f, duration)
            .OnComplete(() =>
            {
                Icon.sprite = newIcon;
                Icon.DOFade(1f, duration);
            });
    }

    public void UpdateExpSlider(float newExpNormalized, float duration)
    {
        ExpSlider.DOKill();
        ExpSlider.DOValue(newExpNormalized, duration)
            .SetEase(Ease.OutBack);
    }
}