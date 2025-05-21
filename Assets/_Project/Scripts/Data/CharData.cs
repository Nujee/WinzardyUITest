using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character")]
public sealed class CharData : ScriptableObject
{
    [field: SerializeField] public Sprite SmallIconSprite { get; private set; }
    [field: SerializeField] public Sprite BigIconSprite { get; private set; }
    [field: SerializeField, Range(0, 1)] public float ExpNormalized { get; private set; }
}