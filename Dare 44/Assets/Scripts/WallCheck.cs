using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;

public class WallCheck : MonoBehaviour
{
    [SerializeField]
    bool right;

    // Start is called before the first frame update
    void Start()
    {
       Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), entities.player.GetComponent<BoxCollider>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Wall" || other.tag == "Platform")
        {
            if(right)
            {
                entities.player.GetComponent<Player>().rightWall = true;
            }
            else
            {
                entities.player.GetComponent<Player>().leftWall = true;
            }
        }
    }
}
