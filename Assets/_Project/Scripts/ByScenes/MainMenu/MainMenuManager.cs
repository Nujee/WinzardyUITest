using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

[DisallowMultipleComponent]
public sealed class MainMenuManager : MonoBehaviour
{
    [field: SerializeField] public Settings Settings { get; private set; }
    [field: Space]
    [field: SerializeField] public Button StartButton { get; private set; }
    [field: SerializeField] public Button SelectCharButton { get; private set; }
    [field: SerializeField] public Button SettingsButton { get; private set; }
    [field: SerializeField] public Button QuitButton { get; private set; }

    private void Start()
    {
        var buttons = new[] {StartButton, SelectCharButton, SettingsButton, QuitButton}; 

        for (var i = 0; i < buttons.Length; i++)
        {
            var button = buttons[i];

            ShowButton(button, i);
            SubscribeButtonToAnimationOnClick(button);
        }

        StartButton.onClick.AddListener(DoOnStartPressed);
        SelectCharButton.onClick.AddListener(DoOnSelectCharPressed);
        SettingsButton.onClick.AddListener(DoOnSettingsPressed);
        QuitButton.onClick.AddListener(DoOnQuitPressed);
    }

    private void ShowButton(Button button, int index)
    {
        var showData = new ShowData
        {
            Duration = Settings.MainMenuButtonsShowData.Duration,
            Delay = index * Settings.MainMenuButtonsShowData.Delay
        };
        button.transform.ShowWithBounce(showData);
    }

    private void SubscribeButtonToAnimationOnClick(Button button)
    {
        button.onClick.AddListener(() =>
        {
            button.transform.ScaleWithBounce(Settings.ButtonsScaleData);
        });
    }

    private void DoOnStartPressed() => Debug.Log("Start game button was pressed");

    private void DoOnSelectCharPressed() => SceneManager.LoadScene(Scenes.CharacterSelection);

    private void DoOnSettingsPressed() => Debug.Log("Settings button was pressed");

    private void DoOnQuitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

