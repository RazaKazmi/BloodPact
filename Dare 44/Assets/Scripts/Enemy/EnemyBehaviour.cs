using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameInformation;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody rb;
    float moveSpeed;

    [SerializeField]
    Vector2 buffer;

    [SerializeField]
    GameObject sprite;

    [SerializeField]
    bool fliped;
    public bool moveRight;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = GetComponent<Enemy>().movespeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if(transform.parent != null)
        {
            if(transform.parent.tag == "Holder")
            {
                transform.parent.position = transform.position;
            }
        }

        if(Mathf.Abs(entities.player.transform.position.y - transform.position.y) < buffer.y)
        {
            if (Mathf.Abs(entities.player.transform.position.x - transform.position.x) < buffer.x)
            {
                if(entities.player.transform.position.x - transform.position.x > 0)
                {
                    moveRight = true;
                }
                else
                {
                    moveRight = false;
                }
            }
        }

        if (moveRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if(!fliped)
            sprite.transform.localEulerAngles = new Vector3(0, 0, 0);
            else
                sprite.transform.localEulerAngles = new Vector3(0, 180, 0);

        }
        else
        {
         
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (!fliped)
                sprite.transform.localEulerAngles = new Vector3(0, 180, 0);
            else
                sprite.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
