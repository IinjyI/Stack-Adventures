using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
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
