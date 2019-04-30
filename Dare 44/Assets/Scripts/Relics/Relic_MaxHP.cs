using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* To make a relic:
 * An object containing a reference to all Relic scriptable objects must exist in the hiearchy
 * with the tag "AllRelics".
 * A scriptable object for the relic is need. This will contrain the sprite for the relic.
 */
public class Relic_MaxHP : MonoBehaviour
{
    GameObject allRelicsObject; //this object NEEDS to exist in the hiearchy with the correct tag
    Relic relic; //relic object associated with this relic (just contains the sprite)

    // Start is called before the first frame update
    void Start()
    {
        allRelicsObject = GameObject.FindGameObjectWithTag("AllRelics"); //find our gameobject which has a reference to all relics
        relic = allRelicsObject.GetComponent<AllRelics>().maxHP; // set our relic equal to the speific relic we want
        GameInformation.entities.player.GetComponent<Player>().maxHealth += relic.increaseValue;
        GameInformation.entities.player.GetComponent<Player>().removeHP(0f);
        //relic.increase value for health and mana is their flat health/mana increase. Ex. 10 = 10 maxhealth increase.
        Inventory.instance.Add(relic); // add our relic to our inventory. This also takes care of updating the sprite in the UI.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        GameInformation.entities.player.GetComponent<Player>().maxHealth -= relic.increaseValue;
        Inventory.instance.Remove(relic); //this removes the relic from our inventory
        Debug.Log("relic destoryed");
    }
}
