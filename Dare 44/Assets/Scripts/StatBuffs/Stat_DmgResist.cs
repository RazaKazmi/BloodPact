using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat_DmgResist : MonoBehaviour
{

    public float increaseValue = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        if (GameInformation.Upgrades.statcount[5] * GetComponent<VendorSoul>().item.GetComponent<StoreItem>().cost <= GameInformation.staticVars.souls)
        {
            GameInformation.entities.player.GetComponent<Player>().addMP(0);
            GameInformation.entities.player.GetComponent<Player>().removeSouls(GameInformation.Upgrades.statcount[5] * GetComponent<VendorSoul>().item.GetComponent<StoreItem>().cost);
            GameInformation.entities.player.GetComponent<Player>().damageResistance += increaseValue;
            GameInformation.Upgrades.statcount[5]++;
            Destroy(this);
        }
        
       
    }
}
