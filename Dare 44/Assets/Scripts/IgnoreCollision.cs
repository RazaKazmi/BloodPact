using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{

    private Collider thisCollider;

    private void Start()
    {
        thisCollider = gameObject.GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(thisCollider,collision.collider);
        }
    }


}
