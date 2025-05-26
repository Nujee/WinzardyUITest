using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public sealed class CharSelectionEntryPoint : MonoBehaviour
{
    [field: SerializeField] public Database Database { get; private set; }
    [field: SerializeField] public Settings Settings { get; private set; }
    [field: SerializeField] public CharSelectionView CharSelectionView { get; private set; }

    private void Start()
    {
        var innerDatabase = new Dictionary<int, CharData>();

        foreach (var pair in Database.CharDatasById)
        {
            innerDatabase[pair.Id] = pair.Value;
        }

        var model = new CharSelectionModel(innerDatabase);
        CharSelectionView.Init(innerDatabase, Settings);

        var presenter = new CharSelectionPresenter(model, CharSelectionView);
        presenter.Init();
    }
}
