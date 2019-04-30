using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;

public class VendorRelic : MonoBehaviour
{
    public GameObject item;

    public string pItem;

    public bool onItem;

    private GameObject allRelicsObject; // gameobject which contains reference of all relics
    private Relic relic; // scriptable object which has info about relic.

    //relic.scriptname gives you the script name associated with that relic.
    //relic.cost gives you the cost (in health) of the relic.


    // Start is called before the first frame update
    void Start()
    {
        allRelicsObject = GameObject.FindGameObjectWithTag("AllRelics");
        relic = allRelicsObject.GetComponent<AllRelics>().getRandomRelic(); // get a random relic from the allRelics object
        Debug.Log(relic.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(onItem)
        {
            item.GetComponent<StoreItem>().cost = relic.cost;
            item.GetComponent<StoreItem>().icon = relic.art;
            item.GetComponent<StoreItem>().name = relic.name;
            item.GetComponent<StoreItem>().desc = relic.description;

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!item.GetComponent<StoreItem>().purchased)
                {
                    purchaseItem();
                }
            }
        }

    }

    void purchaseItem()
    {
        entities.player.GetComponent<Player>().addRelic(relic.scriptName);
        item.GetComponent<StoreItem>().purchased = true;
        entities.player.GetComponent<Player>().removeHP(item.GetComponent<StoreItem>().cost);
    }

}
