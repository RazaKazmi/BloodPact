using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject[] bosses;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate<GameObject>(bosses[Random.Range(0,bosses.Length)],transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            GetComponentInParent<Room>().bossDead = true;
        }
    }
}
