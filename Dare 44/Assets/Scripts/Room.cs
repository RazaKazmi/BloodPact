using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public bool boss, start, vendor;

    [HideInInspector]
    public bool bossDead = false;

    [SerializeField]
    public GameObject exits;

    [SerializeField]
    GameObject[] enemyPrefabs;

    [SerializeField]
    GameObject[] enemyLocations;

    [SerializeField]
    float spawnchance = 1;

    public GameObject bottomBlocker, topBlocker, leftBlocker, rightBlocker;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyLocations.Length; i++)
        {
            if (Random.Range(0.0f, 1.0f) < spawnchance)
            {
                GameObject t = Instantiate<GameObject>(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], enemyLocations[i].transform.position, transform.rotation);
                t.transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //debug
        if(Input.GetKeyDown(KeyCode.K))
        {
            bossDead = true;
        }
        if (boss)
        {
            if (bossDead)
            {
                exits.SetActive(true);
            }
            else
            {
                exits.SetActive(false);
            }
        }
    }
}
