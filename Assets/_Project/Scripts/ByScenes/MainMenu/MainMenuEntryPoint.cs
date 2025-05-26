using UnityEngine;

[DisallowMultipleComponent]
public sealed class MainMenuEntryPoint : MonoBehaviour
{
    [field: SerializeField] public Settings Settings { get; private set; }
    [field: SerializeField] public MainMenuView View { get; private set; }

    private void Start()
    {
        var presenter = new MainMenuPresenter(View, Settings);
        presenter.Init();
    }
}