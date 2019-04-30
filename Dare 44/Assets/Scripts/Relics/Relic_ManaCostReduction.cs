using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic_ManaCostReduction : MonoBehaviour
{
    GameObject allRelicsObject; //this object NEEDS to exist in the hiearchy with the correct tag
    Relic relic; //relic object associated with this relic (just contains the sprite)


    // Start is called before the first frame update
    void Start()
    {
        allRelicsObject = GameObject.FindGameObjectWithTag("AllRelics"); //find our gameobject which has a reference to all relics
        relic = allRelicsObject.GetComponent<AllRelics>().ManaCostReduction; // set our relic equal to the speific relic we want
        GameInformation.entities.player.GetComponent<Player>().ManaCostReduction += relic.increaseValue;
        //relic.increaseValue is the percent increase, from 0 to 1. Ex. 0.1 = 10% increase.
        Inventory.instance.Add(relic); // add our relic to our inventory. This also takes care of updating the sprite in the UI.
    }

    private void OnDestroy()
    {
        GameInformation.entities.player.GetComponent<Player>().ManaCostReduction -= relic.increaseValue;
        Inventory.instance.Remove(relic); //this removes the relic from our inventory
        Debug.Log("relic destoryed");
    }
}
