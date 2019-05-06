using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class _PlayerMovement : MonoBehaviour
{
   
    [SerializeField]
    float speed, jumpForce;


    bool canJump = true;
    bool canDrop;


    [SerializeField]
    Collider2D physicsBox;
    [SerializeField]
    Collider2D jumpBox;
    Rigidbody2D rb;

    [SerializeField]
    GameObject attackTrigger;

    [SerializeField]
    GameObject playerSprite;

    [SerializeField]
    _PlayerAnimation playerAnimation;

    [Header("Attack Settings")]
    public int currentCombo = 0;
    public int comboCount = 3;
    public float comboClickBuffer = 0.5f;
    public float comboAniBuffer = 0.5f;
    public float attackVel = 0.5f;
    public float[] attackDelay;
    public float[] attackDuration;

    float attackTimer = 0;
    float comboTimer = 0;

    bool attackQued = false;
    bool attacking = false;
    bool lookingRight = false;

    //debug
    public float timescale = 1;


    private void Awake()
    {
        GameInformation.entities.player = this.gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(attackTrigger.GetComponent<BoxCollider2D>(),jumpBox);
        Physics2D.IgnoreCollision(physicsBox, jumpBox);
        Physics2D.IgnoreCollision(attackTrigger.GetComponent<BoxCollider2D>(), physicsBox);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //needs to be called everyframe? doesn't work in start
        Physics2D.IgnoreCollision(attackTrigger.GetComponent<BoxCollider2D>(), jumpBox);
        Physics2D.IgnoreCollision(physicsBox, jumpBox);
        Physics2D.IgnoreCollision(attackTrigger.GetComponent<BoxCollider2D>(), physicsBox);

        Time.timeScale = timescale;

        comboTimer -= Time.deltaTime;
        attackTimer -= Time.deltaTime;

        if (comboTimer <= -comboClickBuffer)
        {
            currentCombo = 0;
        }

        playerAnimation.setSpeed(Mathf.Abs(rb.velocity.x));
        playerAnimation.setYVelocity(rb.velocity.y);
        if (comboTimer <= 0)
        {
            movement();
        }
        else
        {
            attackMovement();
        }

        jump();
        attack();

        attackTrigger.transform.position = transform.position;
    }

    void jump()
    {
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canJump = false;
                playerAnimation.setAir(true);
                playerAnimation.playJump();
            }
        }
    }

    void movement()
    {
        //move
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            playerSprite.transform.localScale = new Vector2(1, 1);
            attackTrigger.transform.localScale = new Vector2(1, 1);
            lookingRight = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            playerSprite.transform.localScale = new Vector2(-1, 1);
            attackTrigger.transform.localScale = new Vector2(-1, 1);
            lookingRight = false;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (canDrop)
            {
                physicsBox.enabled = false;
                canJump = false;
            }
        }
    }

    void attackMovement()
    {
        if (canJump)
        {
            if (lookingRight)
                rb.velocity = new Vector2(attackVel, rb.velocity.y);
            else
                rb.velocity = new Vector2(-attackVel, rb.velocity.y);
        }
       
    }

    void attack()
    {
        if (Input.GetMouseButtonDown(0) || attackQued)
        {
            if (comboTimer <= 0)
            {
                if (currentCombo == 0)
                {
                    playerAnimation.playBaseAttack();
                }
                else if (currentCombo == 1)
                {
                    playerAnimation.playSecondAttack();
                }
                else if (currentCombo == 2)
                {
                    playerAnimation.playThirdAttack();
                }


                currentCombo++;
                if (currentCombo >= comboCount)
                {
                    currentCombo = 0;
                }
                if (currentCombo >= comboCount - 1 && !canJump)
                {
                    currentCombo = 0;
                }

                attackTimer = attackDelay[currentCombo];
                attackQued = false;
                attacking = true;
                comboTimer = comboAniBuffer;
            }
            else
            {
                attackQued = true;
            }
        }
        if(attacking)
        {
            if(attackTimer <= -attackDuration[currentCombo])
            {
                attacking = false;
                attackTrigger.SetActive(false);
            }
            else if (attackTimer <= 0)
            {
                attackTrigger.SetActive(true);
            }
            else
            {
                attackTrigger.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerAttack")
        {
            Debug.Break();
        }
        physicsBox.enabled = true;
        canJump = true;
        playerAnimation.setAir(false);
        if (other.transform.name == "NonJumpThrough")
        {
            canDrop = false;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        canJump = true;
        playerAnimation.setAir(false);
        if (other.transform.name == "NonJumpThrough")
        {
            canDrop = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.name == "NonJumpThrough")
        {
            canDrop = true;
        }
        playerAnimation.setAir(true);
        canJump = false;
    }


}
