using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Relic", menuName = "Relic")]
public class Relic : ScriptableObject
{
    public new string name;
    public string scriptName;
    public int id;
    public float cost;
    public string description;
    public float increaseValue; // In percent, 0 to 1;

    public Sprite art;


}
