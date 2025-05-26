using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuView : MonoBehaviour
{
    [field: SerializeField] public Button StartButton { get; private set; }
    [field: SerializeField] public Button SelectCharButton { get; private set; }
    [field: SerializeField] public Button SettingsButton { get; private set; }
    [field: SerializeField] public Button QuitButton { get; private set; }

    public void AnimateButton(Button button, int index, ShowData showData)
    {
        var delayedData = new ShowData
        {
            Duration = showData.Duration,
            Delay = index * showData.Delay
        };

        button.transform.ShowWithBounce(delayedData);
    }

    public void AnimateOnClick(Button button, ScaleData scaleData)
    {
        button.onClick.AddListener(() => button.transform.ScaleWithBounce(scaleData));
    }
}