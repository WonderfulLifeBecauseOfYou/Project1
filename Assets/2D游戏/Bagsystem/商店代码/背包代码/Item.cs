using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/new Item")]
public class Item: ScriptableObject
{
    public string Name;
    public Sprite Image;
    public Sprite Image2;
    public int number;
    [TextArea]
    public string info;
    public bool Equip;
    public float Price;
    public string style;
    public string style2;
}
