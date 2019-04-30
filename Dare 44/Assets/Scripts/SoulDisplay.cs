using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulDisplay : MonoBehaviour
{
    Text soulNumber;
    // Start is called before the first frame update
    void Start()
    {
        soulNumber = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        soulNumber.text = (Math.Round(GameInformation.staticVars.souls,1)).ToString();
    }
}
