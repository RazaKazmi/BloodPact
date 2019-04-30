using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    Inventory inventory;

    RelicSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        inventory = Inventory.instance;
        inventory.onRelicChangedCallback += UpdateUI;

        slots = transform.GetComponentsInChildren<RelicSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.relics.Count)
            {
                slots[i].AddRelic(inventory.relics[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
