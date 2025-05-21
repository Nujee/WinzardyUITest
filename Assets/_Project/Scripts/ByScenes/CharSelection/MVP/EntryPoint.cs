using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public sealed class EntryPoint : MonoBehaviour
{
    [field: SerializeField] public Database Database { get; private set; }
    [field: SerializeField] public Settings Settings { get; private set; }
    [field: SerializeField] public CharSelectionView CharSelectionView { get; private set; }

    private void Start()
    {
        var innerDb = new Dictionary<int, CharData>();

        foreach (var pair in Database.CharDatasById)
        {
            innerDb[pair.Id] = pair.Value;
        }

        var model = new CharSelectionModel(innerDb);
        var presenter = new CharSelectionPresenter(model, CharSelectionView);

        CharSelectionView.Init(innerDb, Settings);
        presenter.Init();
    }
}
