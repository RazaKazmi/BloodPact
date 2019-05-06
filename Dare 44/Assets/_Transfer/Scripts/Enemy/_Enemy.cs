using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float knockBack = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void hit(Vector3 pos)
    {
        rb.velocity = Vector3.zero;

        Vector2 t = new Vector2(1, 2);

        if (pos.x < transform.position.x)
        {
            Debug.Log("left");
            rb.AddForce(t * knockBack, ForceMode2D.Impulse);
        }

        else if (pos.x >= transform.position.x)
        {
            Debug.Log("right");
            rb.AddForce(new Vector2 (-t.x,t.y) * knockBack, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            hit(collision.transform.position);
        }
    }
}
