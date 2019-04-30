using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Soul", menuName = "Soul")]
public class SoulItem : ScriptableObject
{
    public new string name;
    public string scriptName;
    public int id;
    public float cost;
    public string description;

    public Sprite art;

}
