using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{

    public float cost = 10;
    public string name;
    public string desc;
    public Sprite icon;
    public bool purchased = false;

    [SerializeField]
    Text nameText, costText, descriptionText;

    [SerializeField]
    Image iconholder, purchaseIcon;

    GameObject vendor;

    // Start is called before the first frame update
    void Start()
    {
        vendor = transform.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!transform.parent.parent.GetComponentInChildren<VendorHitBox>().soul)
        {
            costText.text = cost.ToString();
            nameText.text = name.ToString();
            descriptionText.text = desc.ToString();
            iconholder.sprite = icon;
        }
        else
        {
            costText.text = (vendor.GetComponent<VendorSoul>().pItem.cost * GameInformation.Upgrades.statcount[vendor.GetComponent<VendorSoul>().currentSoul]).ToString();
            nameText.text = vendor.GetComponent<VendorSoul>().pItem.name;
            descriptionText.text = vendor.GetComponent<VendorSoul>().pItem.description;
            iconholder.sprite = vendor.GetComponent<VendorSoul>().pItem.art;
        }
        
        if(purchased)
        {
            purchaseIcon.gameObject.SetActive(true);
        }
        else
        {
            purchaseIcon.gameObject.SetActive(false);
        }
    }

}
