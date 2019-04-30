using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;
public class Flyer : MonoBehaviour
{
    [SerializeField]
    float fireRate;

    [SerializeField]
    GameObject projectile;

    float firetime;
    // Start is called before the first frame update
    void Start()
    {
        firetime = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = entities.player.transform.position - transform.position;

        RaycastHit rayHit;

        if (Physics.Raycast(transform.position, entities.player.transform.position - transform.position, out rayHit))
        {
            if (rayHit.transform.tag == "Player" || rayHit.transform.tag == "PlayerBox"|| rayHit.transform.tag == "Foot" || rayHit.transform.tag == "Head")
            {
                firetime -= Time.deltaTime;
                if (firetime <= 0)
                {
                    shoot();
                }

                transform.position += transform.up* GetComponent<Enemy>().movespeed * Time.deltaTime;
            }
        }

    }

    void shoot()
    {
        firetime = fireRate;
        Instantiate<GameObject>(projectile, transform.position, transform.rotation);
    }
}
