using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;

public class MagicAttack : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 1;

    [SerializeField]
    float speed = 1;

    [SerializeField]
    bool destroyOnHit = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().health -= entities.player.GetComponent<Player>().magicDamage * (1.0f + entities.player.GetComponent<Player>().magicDamageIncrease 
                + entities.player.GetComponent<Player>().damageIncrease); // MagicDmg * (1.0f + MagicDmgIncrease + DmgIncrease)
            if (destroyOnHit)
            {
                //do effect?
                Destroy(gameObject);
            }
        }
    }
}
