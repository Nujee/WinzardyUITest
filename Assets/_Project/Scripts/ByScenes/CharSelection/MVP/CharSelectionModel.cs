using System.Collections.Generic;

public sealed class CharSelectionModel
{
    public Dictionary<int, CharData> Database { get; private set; }
    public int? LastSelectedCharId = null;

    public CharSelectionModel(Dictionary<int, CharData> database) => Database = database;

    public bool TryUpdateSelection(int clickedCharId)
    {
        if (clickedCharId != LastSelectedCharId)
        {
            LastSelectedCharId = clickedCharId;
            return true;
        }
        return false;
    }
}