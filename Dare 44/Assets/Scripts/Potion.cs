using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{

    public Item potion;
    private GameObject itemDisplay;
    private GameObject interactKeyOverlay;
    // Start is called before the first frame update

    private void Start()
    {
        itemDisplay = GameObject.FindGameObjectWithTag("ItemImage");
        interactKeyOverlay = GameObject.FindGameObjectWithTag("InteractKeyOverlay");
        interactKeyOverlay.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            interactKeyOverlay.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                pickup();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactKeyOverlay.SetActive(false);
        }
    }

    void pickup()
    {
        Debug.Log("Picked up potion");
        itemDisplay.GetComponent<ItemDisplay>().item = potion;
        itemDisplay.GetComponent<ItemDisplay>().artImage.sprite = potion.art;
        itemDisplay.GetComponent<ItemDisplay>().artImage.enabled = true;
        Destroy(transform.parent.gameObject);
    }

}
