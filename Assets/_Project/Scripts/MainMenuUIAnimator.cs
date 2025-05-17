using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public sealed class MainMenuUIAnimator : MonoBehaviour
{
    [field: SerializeField] public CanvasGroup CanvasGroup { get; private set; }
    [field: SerializeField] public Button[] Buttons { get; private set; }

    // TODO: move to some settings
    private float _inBetweenDelay = 0.05f;

    private void Start()
    {
        CanvasGroup.alpha = 0f;
        CanvasGroup.blocksRaycasts = false;

        CanvasGroup.DOFade(1f, 0.6f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => { CanvasGroup.blocksRaycasts = true; });

        for (var i = 0; i < Buttons.Length; i++)
        {
            var button = Buttons[i];
            var delay = i * _inBetweenDelay;

            var originalScale = button.transform.localScale;
            button.transform.localScale = Vector3.zero;
            button.transform.DOScale(originalScale, 0.4f)
                .SetEase(Ease.OutBack)
                .SetDelay(delay);
        }
    }
}
