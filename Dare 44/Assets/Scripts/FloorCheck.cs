using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;
public class FloorCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), entities.player.GetComponent<BoxCollider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor" || other.tag == "Platform")
        {
            entities.player.GetComponent<Player>().canJump = true;
            entities.player.GetComponent<Player>().knocked = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Floor" || other.tag == "Platform")
        {
            entities.player.GetComponent<Player>().canJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Floor" || other.tag == "Platform")
        {
            entities.player.GetComponent<Player>().canJump = false;
        }
    }
}
