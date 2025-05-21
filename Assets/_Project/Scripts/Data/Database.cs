using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Database", menuName = "Data/Database")]
public sealed class Database : ScriptableObject
{
    [field: SerializeField] public List<IdValuePair<CharData>> CharDatasById { get; private set; }
}
