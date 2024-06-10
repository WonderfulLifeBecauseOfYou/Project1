using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List", menuName = "Inventory/new List")]
public class List : ScriptableObject
{
   public List<Item> list = new List<Item>();
}
