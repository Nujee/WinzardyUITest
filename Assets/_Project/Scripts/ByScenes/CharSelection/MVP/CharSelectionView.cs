using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public sealed class CharSelectionView : MonoBehaviour
{
    private readonly Dictionary<int, CharView> _charViewsById = new();
    private GenericPool<CharView> _charViewPool;
    private Settings _settings;

    [field: SerializeField] public Transform CharsViewPort { get; private set; }
    [field: SerializeField] public Transform CharsParent { get; private set; }
    [field: SerializeField] public SelectionCharIconView BigIconView { get; private set; }
    [field: SerializeField] public Button BackButton { get; private set; }

    public event Action<int> OnSelectChar = delegate { };

    public void Init(Dictionary<int, CharData> innerDb, Settings settings)
    {
        _settings = settings;

        _charViewPool = new GenericPool<CharView>(settings.CharViewPrefab, innerDb.Count, CharsParent);

        BackButton.onClick.AddListener(() =>
        {
            BackButton.transform.ScaleWithBounce(_settings.ButtonsScaleData);
            SceneManager.LoadScene(Scenes.MainMenu);
        });
    }

    public void InitializeCharView(int charId, CharData charData)
    {
        var charButtonView = _charViewPool.Get()
            .Init(charData.SmallIconSprite, charData.ExpNormalized);

        charButtonView.Button.onClick.AddListener(() => 
        {
            charButtonView.transform.ScaleWithBounce(_settings.ButtonsScaleData);
            OnSelectChar(charId); 
        });

        _charViewsById[charId] = charButtonView;
    }

    public void UpdateCharSelection(CharData charData)
    {
        BigIconView.UpdateIcon(charData.BigIconSprite, _settings.SelectionIconUpdateDuration);
        BigIconView.UpdateExpSlider(charData.ExpNormalized,_settings.SelectionSliderUpdateDuration);
    }

    public void Show()
    {
        CharsViewPort.ShowWithBounce(_settings.CharsViewportShowData)
            .OnStart(HideCharViews)
            .OnComplete(ShowCharViewsSequentially);

        BigIconView.transform.ShowWithBounce(_settings.BigIconShowData);
        BackButton.transform.ShowWithBounce(_settings.BackButtonShowData);
    }

    private void HideCharViews()
    {
        foreach (var charView in _charViewsById.Values)
        {
            charView.gameObject.SetActive(false);
        }
    }

    private void ShowCharViewsSequentially()
    {
        var count = 0;
        foreach (var charView in _charViewsById.Values)
        {
            charView.gameObject.SetActive(true);

            var actualShowData = new ShowData 
            { 
                Duration = _settings.CharShowData.Duration,
                Delay = _settings.CharShowData.Delay * count++
            };

            charView.transform.ShowWithBounce(actualShowData);
        }
    }

    private void OnDestroy()
    {
        foreach (var charView in _charViewsById.Values)
        {
            charView.Button.onClick.RemoveAllListeners();
        }

        _charViewPool.Clear();
    }
}
