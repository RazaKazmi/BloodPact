using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingStick : MonoBehaviour
{
    public bool isRight;

    bool right;
    public bool boss;
    private void Start()
    {
      
    }

    public void OnTriggerEnter(Collider other)
    {
        right = GetComponentInParent<EnemyBehaviour>().moveRight;
        if (other.tag == "Wall")
        {
            if(isRight)
                GetComponentInParent<EnemyBehaviour>().moveRight = false;
            else
                GetComponentInParent<EnemyBehaviour>().moveRight = true;
        }
    }
   
    public void OnTriggerExit(Collider other)
    {
        if (!boss)
        {
            right = GetComponentInParent<EnemyBehaviour>().moveRight;
            Debug.Log("Exitted platform collider");
            if (other.tag == "Platform" || other.tag == "Floor")
            {
                GetComponentInParent<EnemyBehaviour>().moveRight = !right;
            }
        }
    }

}
