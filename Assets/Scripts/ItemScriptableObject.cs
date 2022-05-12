using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemObject", menuName = "ScriptableObjects/ItemObject")]
public class ItemScriptableObject : ScriptableObject
{
    public ItemColor itemColor;
    public enum ItemColor{
        Blue,
        DarkBlue,
        Green,
        Gery,
        Orange,
        Purple,
        Red,
        Yellow,
    }
    public Sprite icon;
}
