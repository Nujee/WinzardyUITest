using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Data/Settings")]
public sealed class Settings : ScriptableObject
{
    [field: SerializeField] public CharView CharViewPrefab { get; private set; }
    [field: Space]
    [field: SerializeField] public ScaleData ButtonsScaleData { get; private set; }
    [field: Space]
    [field: SerializeField] public ShowData MainMenuButtonsShowData { get; private set; }
    [field: SerializeField] public ShowData CharsViewportShowData { get; private set; }
    [field: SerializeField] public ShowData BigIconShowData { get; private set; }
    [field: SerializeField] public ShowData BackButtonShowData { get; private set; }
    [field: SerializeField] public ShowData CharShowData { get; private set; }
    [field: Space]
    [field: SerializeField] public float SelectionIconUpdateDuration { get; private set; }
    [field: SerializeField] public float SelectionSliderUpdateDuration { get; private set; }
}