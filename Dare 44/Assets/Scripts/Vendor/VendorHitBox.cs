using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorHitBox : MonoBehaviour
{
    [SerializeField]
    public bool relic, soul;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (relic)
        {
            if (other.tag == "Player")
            {
                GetComponentInParent<VendorRelic>().item.SetActive(true);
                GetComponentInParent<VendorRelic>().onItem = true;
            }
        }
        else if (soul)
        {
            if (other.tag == "Player")
            {
                GetComponentInParent<VendorSoul>().item.SetActive(true);
                GetComponentInParent<VendorSoul>().onItem = true;
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                GetComponentInParent<Vendor>().item.SetActive(true);
                GetComponentInParent<Vendor>().onItem = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (relic)
        {
            if (other.tag == "Player")
            {
                GetComponentInParent<VendorRelic>().item.SetActive(false);
                GetComponentInParent<VendorRelic>().onItem = false;
            }
        }
        else if (soul)
        {
            if (other.tag == "Player")
            {
                GetComponentInParent<VendorSoul>().item.SetActive(false);
                GetComponentInParent<VendorSoul>().onItem = false;
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                GetComponentInParent<Vendor>().item.SetActive(false);
                GetComponentInParent<Vendor>().onItem = false;
            }
        }
    }
}
