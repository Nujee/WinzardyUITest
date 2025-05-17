using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Button))]
public sealed class UIButtonAnimator : MonoBehaviour
{
    private Button _button;
    private Vector3 _originalScale;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _originalScale = transform.localScale;

        _button.onClick.AddListener(AnimateClick);
    }

    private void AnimateClick()
    {
        transform.DOKill();
        transform.DOScale(_originalScale * 0.9f, 0.05f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                transform.DOScale(_originalScale, 0.15f).SetEase(Ease.OutBack);
            });
    }
}
