using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat_MaxMP : MonoBehaviour
{

    public float increaseValue = 5f;
    // Start is called before the first frame update
    void Start()
    {
        if (GameInformation.Upgrades.statcount[1] * GetComponent<VendorSoul>().item.GetComponent<StoreItem>().cost <= GameInformation.staticVars.souls)
        {
            GameInformation.entities.player.GetComponent<Player>().addMP(0);
            GameInformation.entities.player.GetComponent<Player>().removeSouls(GameInformation.Upgrades.statcount[1] * GetComponent<VendorSoul>().item.GetComponent<StoreItem>().cost);
            GameInformation.entities.player.GetComponent<Player>().maxMana += increaseValue;
            GameInformation.Upgrades.statcount[1]++;
            Destroy(this);
        }
        
       
    }
}
