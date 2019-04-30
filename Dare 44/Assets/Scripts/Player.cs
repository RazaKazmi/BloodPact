using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using GameInformation;

public class Player : MonoBehaviour
{
    [Header("Movement stats")]
    [SerializeField]
    public float baseSpeed = 1;

    [SerializeField]
    float baseJump = 1;

    [Header("Health stats")]
    
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    [SerializeField]
    float knockBack = 10;

    [HideInInspector]
    public bool knocked;
    float knocktimer = 0;
    [SerializeField]
    float knocktime = 0.1f;
    [SerializeField]
    float velocityLimit;

    [SerializeField]
    private float timer = 0.0f;
    [SerializeField]
    private float waitTime = 1.0f;


    [Header("Mana stats")]
    
    public float currentMana = 100f;
    public float maxMana = 100f;
    [SerializeField]
    float manaCost;

    [Header("Other stats")]
    //All of these stats are values between 0 to 1, in %
    public float damageResistance = 0.0f;
    public float damageIncrease = 0.0f;
    public float ManaCostReduction = 0.0f;
    public float meleeDamageIncrease = 0.0f;
    public float magicDamageIncrease = 0.0f;

    public float dmgResistCap = 0.9f;
    public float ManaCostReductionCap = 0.9f;


    [Header("Melee Attack Settings")]
    [SerializeField]
    GameObject meleeHitBox;

    public float meleeDamage;
    public float attackTime, attackDelay, attackCoolDown;
    public bool attacking, canAttack;


    float attackTimer;

    [Header("Magic Attack Settings")]
    [SerializeField]
    GameObject currentAbility;
    [SerializeField]
    GameObject magicOffset;

    public float magicDamage;
    public float magicTime, magicDelay, magicCoolDown;
    public bool magicing, canMagic, hasFired;

    float magicTimer;

    [Header("Camera Settings")]
    [SerializeField]
    Camera cam;

    [HideInInspector]
    public bool rightWall, leftWall, canJump;
    Rigidbody rb;

    [Header("UI bars")]
    public Image healthBar;
    public Image manaBar;
    private Text healthNumber;
    private Text manaNumber;

    [Header("ItemUI")]
    public ItemDisplay item;
    public GameObject InventoryUI;
    public GameObject StatsUI;

    [Header("Relics")]
    public GameObject relicHolder;
    public int totalRelics;

    [Header("Sounds")]
    [SerializeField]
    AudioSource[] sounds;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        entities.player = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthNumber = healthBar.GetComponentInChildren<Text>();
        healthNumber.text = currentHealth.ToString();

        manaNumber = manaBar.GetComponentInChildren<Text>();
        manaNumber.text = currentMana.ToString();

        maxHealth = PlayerPrefs.GetFloat("MaxHP", 100);
        maxMana = PlayerPrefs.GetFloat("MaxMP", 100);
        meleeDamageIncrease = PlayerPrefs.GetFloat("Melee", 0);
        magicDamageIncrease = PlayerPrefs.GetFloat("Magic", 0);
        ManaCostReduction = PlayerPrefs.GetFloat("Mana", 0);
        damageResistance = PlayerPrefs.GetFloat("MagicResist", 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        deathCheck();
        smoothJump();

        if (attackTimer > -attackCoolDown)
        {
            attackTimer -= Time.deltaTime;
            canAttack = false;
        }
        else
        {
            canAttack = true;
        }

        if (magicTimer > -magicCoolDown)
        {
            magicTimer -= Time.deltaTime;
            canMagic = false;
        }
        else
        {
            canMagic = true;
        }

        //Melee Attack
        if (attacking)
        {
            sounds[0].Play();
            if (attackTime - attackTimer > attackDelay)
            {
                meleeHitBox.SetActive(true);
            }
            if (attackTimer <= 0)
            {
                attacking = false;
            }
        }
        else
        {
            meleeHitBox.SetActive(false);
        }

        //Magic Attack
        if (magicing)
        {
            if (magicTime - magicTimer > magicDelay && !hasFired)
            {
                sounds[1].Play();
                Instantiate<GameObject>(currentAbility, magicOffset.transform.position, magicOffset.transform.rotation);
                hasFired = true;
            }
            if (magicTimer <= 0)
            {
                magicing = false;
            }
        }

        //Movemnt
        if (!knocked)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (!attacking)
                {
                    if (!rightWall)
                        transform.position += (transform.right * baseSpeed) * Time.deltaTime;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (transform.eulerAngles == Vector3.zero)
                {
                    transform.position += (transform.right * baseSpeed) * Time.deltaTime;
                }
                else
                {
                    transform.position -= (transform.right * baseSpeed) * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (!attacking)
                {
                    if (!rightWall)
                        transform.position += (transform.right * baseSpeed) * Time.deltaTime;
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (transform.eulerAngles == Vector3.zero)
                {
                    transform.position -= (transform.right * baseSpeed) * Time.deltaTime;
                }
                else
                {
                    transform.position += (transform.right * baseSpeed) * Time.deltaTime;
                }
            }
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
                rb.AddForce(transform.up * baseJump, ForceMode.Impulse);
        }

        //Attacking
        if (Input.GetMouseButton(0))
        {
            if (!attacking)
                attack();
        }

        //MagicAttacking
        if (Input.GetMouseButton(1))
        {
            if (!magicing)
                magicAttack();
        }

        //UsePotion
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (item.item != null) // player has an item equipped
            {
                //Item id 1 = healthPotion
                //Item id 2 = manaPotion

                switch (item.item.id)
                {
                    case 1:
                        {
                            float healthGain = item.item.healthRestorePercent * maxHealth;
                            addHP(healthGain);
                            item.item = null; // removes the equipped potion
                            item.artImage.sprite = item.defaultImage; // removes the potion sprite off our ui
                            item.artImage.enabled = false;
                            break;
                        }
                    case 2:
                        {
                            float manaGain = item.item.manaRestorePercent * maxMana;
                            addMP(manaGain);
                            item.item = null; // removes the potion from our inventory
                            item.artImage.sprite = item.defaultImage; // removes the potion sprite off our ui
                            item.artImage.enabled = false;
                            break;
                        }
                }
            }
        }

        //open and close inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
            StatsUI.SetActive(!StatsUI.activeSelf);
        }


        //KnockBack
        if (knocked)
        {
            if(rb.velocity.x > velocityLimit)
            {
                rb.velocity = new Vector3(velocityLimit - 1, rb.velocity.y, rb.velocity.z);
            }
            if (rb.velocity.x < -velocityLimit)
            {
                rb.velocity = new Vector3(-(velocityLimit + 1), rb.velocity.y, rb.velocity.z);
            }
            if (rb.velocity.y > velocityLimit)
            {
                rb.velocity = new Vector3(rb.velocity.x, velocityLimit - 1, rb.velocity.z);
            }
           

            knocktimer -= Time.deltaTime;
            if(knocktimer < 0)
            { 
            if (Mathf.Abs(rb.velocity.x) < 2.0f)
            {
                knocked = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (!attacking && !magicing)
                {
                    if (!rightWall)
                        rb.AddForce(transform.right * baseSpeed* 1.5f);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (transform.eulerAngles == Vector3.zero)
                {
                    rb.AddForce(transform.right * baseSpeed* 1.5f);
                }
                else
                {
                    rb.AddForce(-transform.right * baseSpeed* 1.5f);
                }
            }
                if (Input.GetKey(KeyCode.A))
                {
                    if (!attacking && !magicing)
                    {
                        if (!rightWall)
                            rb.AddForce(transform.right * baseSpeed* 1.5f);
                        transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    else if (transform.eulerAngles == Vector3.zero)
                    {
                        rb.AddForce(-transform.right * baseSpeed* 1.5f);
                    }
                    else
                    {
                        rb.AddForce(transform.right * baseSpeed * 1.5f);
                    }
                }
            }
        }
        else
        {
         
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }


        //cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
    }

    private void FixedUpdate()
    {
        rightWall = false;
        leftWall = false;

        if (damageResistance > dmgResistCap)
            damageResistance = dmgResistCap;

        if (ManaCostReduction > ManaCostReductionCap)
            ManaCostReduction = ManaCostReductionCap;

    }

    public void attack()
    {
        if (canAttack)
        {
            attacking = true;
            attackTimer = attackTime;
        }
    }

    public void magicAttack()
    {
        if ((manaCost * (1.0f - ManaCostReduction)) <= currentMana)
        {
            if (canMagic)
            {
                magicing = true;
                magicTimer = magicTime;
                hasFired = false;
                removeMP(manaCost * (1.0f - ManaCostReduction));
            }
        }
    }

    public void removeHP(float hp)
    {
        
        sounds[UnityEngine.Random.Range(0, 2) + 2].Play();
        currentHealth -= hp;
        healthBar.fillAmount = currentHealth / maxHealth; //update health display on the bar
        healthNumber.text = currentHealth.ToString();

    }

    public void addHP(float hp)
    {
        currentHealth += hp;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.fillAmount = currentHealth / maxHealth;
        healthNumber.text = currentHealth.ToString();

    }

    public void removeMP(float mp)
    {
        currentMana -= mp;
        if (currentMana < 0)
        {
            currentMana = 0;
        }
        manaBar.fillAmount = currentMana / maxMana; // update mana display on bar
        manaNumber.text = currentMana.ToString();

    }

    public void addMP(float mp)
    {
        currentMana += mp;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        manaBar.fillAmount = currentMana / maxMana;
        manaNumber.text = currentMana.ToString();

    }

    public void removeSouls(float amount)
    {
        if (amount > GameInformation.staticVars.souls)
        {
            Debug.Log("Do not have enough souls");
            return;
        }
        GameInformation.staticVars.souls -= amount;

    }

    public void addSouls(float amount)
    {
        GameInformation.staticVars.souls += amount;
    }

    public void addItem(Item newItem)
    {
        item.item = newItem;
        item.artImage.sprite = newItem.art;
        item.artImage.enabled = true;
    }

    public void addRelic(string scriptName)
    {
        relicHolder.AddComponent(Type.GetType(scriptName));
        totalRelics++;
    }

    public void addStats(string scriptName)
    {
        relicHolder.AddComponent(Type.GetType(scriptName));
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            sounds[UnityEngine.Random.Range(0, 2) + 2].Play();
            rb.AddForce(Vector3.Normalize(transform.position - collision.transform.position) * knockBack + transform.up * knockBack);
            knocked = true;
            knocktimer = knocktime;

            currentHealth -= collision.transform.GetComponent<Enemy>().damage * (1.0f - damageResistance);
            healthBar.fillAmount = currentHealth / maxHealth; //update health display on the bar
            healthNumber.text = currentHealth.ToString();

        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            timer += Time.fixedDeltaTime; //start timer
            Debug.Log("Timer started");
            if (timer > waitTime) // if they've been staying in enemy collider for certain amount of time
            {
                Debug.Log("Staying in enemy collider");
                sounds[UnityEngine.Random.Range(0, 2) + 2].Play();
                currentHealth -= collision.transform.GetComponent<Enemy>().damage * (1.0f - damageResistance);
                healthBar.fillAmount = currentHealth / maxHealth; //update health display on the bar
                healthNumber.text = currentHealth.ToString();

                timer = 0.0f; // reset timer
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            //timer = 0.0f; // if player leaves enemy collider, reset timer.
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log(gameObject.name);
            sounds[UnityEngine.Random.Range(0, 2) + 2].Play();
            currentHealth -= other.transform.GetComponent<Enemy>().damage * (1.0f-damageResistance);
            healthBar.fillAmount = currentHealth / maxHealth; //update health display on the bar
            healthNumber.text = currentHealth.ToString();

            if (other.GetComponent<Enemy>().dieOnHit)
            {
                other.GetComponent<Enemy>().Death();
            }
        }
    }



    void deathCheck()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("HubWorld");
            //transform.position = new Vector3(0, 2, 0);
            //rb.velocity = Vector3.zero;
            currentHealth = maxHealth;
            removeAllRelics();
            staticVars.souls *= 0.5f;
        }
    }

    void removeAllRelics()
    {
        foreach (var comp in relicHolder.gameObject.GetComponents<Component>())
        {
            if (!(comp is Transform))
            {
                Destroy(comp);
            }
        }
    }

    void smoothJump()
    {
        if (rb.velocity.y < 0)
        {
            GetComponent<ConstantForce>().force = new Vector3(0, -5, 0);
        }
        else
        {
            GetComponent<ConstantForce>().force = new Vector3(0, 0, 0);
        }
    }

}
