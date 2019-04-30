using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    bool destroyOnHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().playhit();
            other.GetComponent<Enemy>().health -= entities.player.GetComponent<Player>().meleeDamage * (1.0f + entities.player.GetComponent<Player>().meleeDamageIncrease
                + entities.player.GetComponent<Player>().damageIncrease); // MeleeDmg * (1.0f + MeleeDmgIncrease + DmgIncrease)
            if (destroyOnHit)
            {
                //do effect?
                Destroy(gameObject);
            }
        }
    }

}
