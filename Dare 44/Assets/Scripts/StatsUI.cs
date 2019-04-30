using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GameInformation;

public class StatsUI : MonoBehaviour
{

    public Text currentHP;
    public Text currentMP;
    public Text maxHP;
    public Text maxMP;
    public Text dmgIncrease;
    public Text dmgResist;
    public Text manaCostReduction;

    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            currentHP.text = entities.player.GetComponent<Player>().currentHealth.ToString();
            currentMP.text = entities.player.GetComponent<Player>().currentMana.ToString();
            maxHP.text = entities.player.GetComponent<Player>().maxHealth.ToString();
            maxMP.text = entities.player.GetComponent<Player>().maxMana.ToString();
            dmgIncrease.text = ((int)(entities.player.GetComponent<Player>().damageIncrease * 100)).ToString() + "%";
            dmgResist.text = ((int)(entities.player.GetComponent<Player>().damageResistance * 100)).ToString() + "%";
            manaCostReduction.text = ((int)(entities.player.GetComponent<Player>().ManaCostReduction * 100)).ToString() + "%";

        }
    }
}
