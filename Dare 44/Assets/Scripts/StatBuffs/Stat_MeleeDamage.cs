using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat_MeleeDamage : MonoBehaviour
{

    public float increaseValue = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        if (GameInformation.Upgrades.statcount[2] * GetComponent<VendorSoul>().item.GetComponent<StoreItem>().cost <= GameInformation.staticVars.souls)
        {
            GameInformation.entities.player.GetComponent<Player>().addMP(0);
            GameInformation.entities.player.GetComponent<Player>().removeSouls(GameInformation.Upgrades.statcount[2] * GetComponent<VendorSoul>().item.GetComponent<StoreItem>().cost);
            GameInformation.entities.player.GetComponent<Player>().meleeDamageIncrease += increaseValue;
            GameInformation.Upgrades.statcount[2]++;
            Destroy(this);
        }
        
       
    }
}
