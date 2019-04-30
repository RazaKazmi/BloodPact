using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;


public class VendorSoul : MonoBehaviour
{
    public GameObject item;

    public SoulItem pItem;

    public bool onItem;

    public int currentSoul;

    private GameObject allRelicsObject;

    // Start is called before the first frame update
    void Start()
    {
        allRelicsObject = GameObject.FindGameObjectWithTag("AllRelics");
    }

    // Update is called once per frame
    void Update()
    {
        pItem = allRelicsObject.GetComponent<AllSoulItems>().items[currentSoul];

        if (onItem)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentSoul--;
                if (0 > currentSoul)
                {
                    currentSoul = allRelicsObject.GetComponent<AllSoulItems>().items.Length - 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentSoul++;
                if(allRelicsObject.GetComponent<AllSoulItems>().items.Length <= currentSoul)
                {
                    currentSoul = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                purchaseItem();
            }
        }

    }

    void purchaseItem()
    {
        if (GameInformation.Upgrades.statcount[1] * item.GetComponent<StoreItem>().cost <= GameInformation.staticVars.souls)
            gameObject.AddComponent(Type.GetType(pItem.scriptName));

    }

}


