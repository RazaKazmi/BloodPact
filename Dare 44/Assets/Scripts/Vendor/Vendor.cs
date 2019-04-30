using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;

public class Vendor : MonoBehaviour
{
    public GameObject item;

    public Item pItem;

    public bool onItem;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(onItem)
        {
            item.GetComponent<StoreItem>().cost = pItem.cost;
            item.GetComponent<StoreItem>().icon = pItem.art;
            item.GetComponent<StoreItem>().name = pItem.name;
            item.GetComponent<StoreItem>().icon = pItem.art;
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
        entities.player.GetComponent<Player>().addItem(pItem);
        item.GetComponent<StoreItem>().purchased = true;
        entities.player.GetComponent<Player>().removeHP(item.GetComponent<StoreItem>().cost);
    }

}
