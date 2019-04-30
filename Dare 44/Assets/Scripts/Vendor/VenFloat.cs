using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenFloat : MonoBehaviour
{

    [SerializeField]
    float speed = 1, scale = 1;

    float ogHight;

    Vector3 target;

    bool flip;
    // Start is called before the first frame update
    void Start()
    {
        ogHight = transform.position.y;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(!flip)
        {
            target += transform.up * speed * Time.deltaTime;
            if (transform.position.y > ogHight + scale)
            {
                flip = true;
            }
        }
        else
        {
            target -= transform.up * speed * Time.deltaTime;
            if (transform.position.y < ogHight - scale)
            {
                flip = false;
            }
        }

        transform.position = Vector3.Slerp(transform.position, target,0.1f);

        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
    }
}
