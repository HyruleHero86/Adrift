using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Scriptable objects/Item")]
public class ItemSO : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public GameObject prefab;
    public int stackMax;
}
