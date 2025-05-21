using System;

public sealed class CharSelectionPresenter : IDisposable
{
    private readonly CharSelectionModel _model;
    private readonly CharSelectionView _view;

    public CharSelectionPresenter(CharSelectionModel model, CharSelectionView view)
    {
        _model = model;
        _view = view;
    }

    public void Init()
    {
        bool isFirstChar = true;
        foreach (var pair in _model.Database)
        {
            var charId = pair.Key;
            var charData = pair.Value;

            _view.InitializeCharView(charId, charData);

            if (isFirstChar)
            {
                HandleSelectChar(charId);
                isFirstChar = false;
            }
        }

        _view.OnSelectChar += HandleSelectChar;
        _view.Show();
    }

    private void HandleSelectChar(int selectedCharId)
    {
        if (!_model.TryUpdateSelection(selectedCharId))
            return;

        var charData = _model.Database[selectedCharId];
        _view.UpdateCharSelection(charData);
    }

    public void Dispose()
    {
       _view.OnSelectChar -= HandleSelectChar;
    }
}