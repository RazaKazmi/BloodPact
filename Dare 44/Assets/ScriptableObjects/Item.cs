using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Potion")]
public class Item : ScriptableObject
{
    public new string name;
    public int id;

    public float healthRestorePercent;
    public float manaRestorePercent;

    public Sprite art;

    public float cost;
}
