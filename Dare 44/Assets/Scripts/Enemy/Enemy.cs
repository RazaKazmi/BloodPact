using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;

public class Enemy : MonoBehaviour
{
    public float health;
    public float movespeed;
    public float damage;
    public float souls;
    public bool dieOnHit;

    [Header("Drop on death")]
    public GameObject healthPotion;
    public GameObject manaPotion;

    private float dropRoll;

    [SerializeField]
    AudioSource[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        if (staticVars.currentfloor > 1)
        {
            health = health * (staticVars.currentfloor * 0.5f + 1);
            damage = damage * (staticVars.currentfloor * 0.25f + 1);
            movespeed = movespeed * (staticVars.currentfloor * 0.05f + 1);
            souls = souls * (staticVars.currentfloor * 0.1f + 1);


        }
        if (movespeed > 20)
        {
            movespeed = 20;
        }
        dropRoll = Random.Range(0, 100);

    }

    // Update is called once per frame
    void Update()
    {

        //Death
        if (health <= 0)
        {
            Death();
        }


    }

    public void playhit()
    {
        sounds[0].Play();
    }

    public void Death()
    {
        Debug.Log(gameObject.name + " killed");
        GameInformation.staticVars.souls += souls;
        if (dropRoll <= 11) // 11% drop rate
        {
            Instantiate(healthPotion, transform.position, Quaternion.identity);
            Debug.Log(" Health Potion Dropped");
        }
        else if (dropRoll > 11 && dropRoll < 17) // 5% drop rate
        {
            Instantiate(manaPotion, transform.position, Quaternion.identity);
            Debug.Log("manaPotion Potion Dropped");
        }
        Destroy(gameObject, 0.0f);
    }
}
