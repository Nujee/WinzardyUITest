using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public sealed class CharView : MonoBehaviour
{
    [field: SerializeField] public Image Icon {  get; private set; }
    [field: SerializeField] public Slider ExpSlider { get; private set; }
    [field: SerializeField] public Button Button { get; private set; }

    public CharView Init(Sprite iconSprite, float initialSliderValueNormalized)
    {
        Icon.sprite = iconSprite;
        ExpSlider.value = initialSliderValueNormalized;

        return this;
    }
}
