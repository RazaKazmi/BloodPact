using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat_ManaCost : MonoBehaviour
{

    public float increaseValue = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        if (GameInformation.Upgrades.statcount[4] * GetComponent<VendorSoul>().item.GetComponent<StoreItem>().cost <= GameInformation.staticVars.souls)
        {
            GameInformation.entities.player.GetComponent<Player>().removeSouls(GameInformation.Upgrades.statcount[4] * GetComponent<VendorSoul>().item.GetComponent<StoreItem>().cost);
            GameInformation.entities.player.GetComponent<Player>().ManaCostReduction += increaseValue;
            GameInformation.Upgrades.statcount[4]++;
            Destroy(this);
        }
        
       
    }
}
