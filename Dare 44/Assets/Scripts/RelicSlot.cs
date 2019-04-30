using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RelicSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Image icon;
    public GameObject tooltip;

     Relic relic;

    private void Start()
    {
        icon.enabled = false;
        tooltip.SetActive(false);
    }

    public void AddRelic(Relic newRelic)
    {
        relic = newRelic;

        icon.sprite = relic.art;
        icon.enabled = true;

        tooltip.GetComponentInChildren<Text>().text = relic.description;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
    }

    //This is where we will display a description of the relic
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (icon.enabled)
        {
            //Display description overlay
            tooltip.SetActive(true);
            Debug.Log("Mousing over description of relic");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //disable description overlay
        Debug.Log("left description");
        if(tooltip.activeInHierarchy)
            tooltip.SetActive(false);
    }
}
