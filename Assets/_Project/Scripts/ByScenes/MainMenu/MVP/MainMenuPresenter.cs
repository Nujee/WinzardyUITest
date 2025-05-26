using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class MainMenuPresenter
{
    private readonly MainMenuView _view;
    private readonly Settings _settings;

    public MainMenuPresenter(MainMenuView view, Settings settings)
    {
        _view = view;
        _settings = settings;
    }

    public void Init()
    {
        var buttons = new[]
        {
            _view.StartButton,
            _view.SelectCharButton,
            _view.SettingsButton,
            _view.QuitButton
        };

        for (var i = 0; i < buttons.Length; i++)
        {
            _view.AnimateButton(buttons[i], i, _settings.MainMenuButtonsShowData);
            _view.AnimateOnClick(buttons[i], _settings.ButtonsScaleData);
        }

        _view.StartButton.onClick.AddListener(OnStartClicked);
        _view.SelectCharButton.onClick.AddListener(OnSelectCharClicked);
        _view.SettingsButton.onClick.AddListener(OnSettingsClicked);
        _view.QuitButton.onClick.AddListener(OnQuitClicked);
    }

    private void OnStartClicked() => Debug.Log("Start game button was pressed");

    private void OnSelectCharClicked() => SceneManager.LoadScene(Scenes.CharacterSelection);

    private void OnSettingsClicked() => Debug.Log("Settings button was pressed");

    private void OnQuitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}