using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat_MaxHP : MonoBehaviour
{

    public float increaseValue = 5f;
    // Start is called before the first frame update
    void Start()
    {
        if(GameInformation.Upgrades.statcount[0] * GetComponent<VendorSoul>().item.GetComponent<StoreItem>().cost <= GameInformation.staticVars.souls)
        {
            GameInformation.entities.player.GetComponent<Player>().addHP(0);
            GameInformation.entities.player.GetComponent<Player>().removeSouls(GameInformation.Upgrades.statcount[0] * GetComponent<VendorSoul>().item.GetComponent<StoreItem>().cost);
            GameInformation.entities.player.GetComponent<Player>().maxHealth += increaseValue;
            GameInformation.Upgrades.statcount[0]++;
            Destroy(this);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
