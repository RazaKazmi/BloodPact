using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    [HideInInspector]
    public Item item; //our item scriptable object which contains all our item data
    [HideInInspector]
    public Image artImage;

    public Sprite defaultImage;

    // Start is called before the first frame update
    void Start()
    {
        item = null;
        artImage.sprite = defaultImage;
        artImage.enabled = false;
    }


}
