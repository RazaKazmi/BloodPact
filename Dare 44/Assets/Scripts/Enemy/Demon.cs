using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Animations;

public class Demon : MonoBehaviour
{
    public Animator ani, breathAni;

    int attack = Animator.StringToHash("Attack");

    int fire = Animator.StringToHash("Fire");

    [SerializeField]
    GameObject attackBox;
    [SerializeField]
    GameObject breath;

    [SerializeField]
    float attackdelay;
    [SerializeField]
    float attackDuration;

    [SerializeField]
    float speed;

    [SerializeField]
    float attackrate;

    float attackrateTimer = 0;

    float timer = 0;
    bool attacking;


    // Start is called before the first frame update
    void Start()
    {
        attackBox.SetActive(false);
        breath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (ani == null)
        {
            Destroy(this.gameObject);
        }

        attackrateTimer -= Time.deltaTime;
        RaycastHit rayHit;

        if (Physics.Raycast(transform.position, GameInformation.entities.player.transform.position - transform.position, out rayHit))
        {
            if (rayHit.transform.tag == "Player" || rayHit.transform.tag == "PlayerBox" || rayHit.transform.tag == "Foot" || rayHit.transform.tag == "Head")
            {
                transform.position += Vector3.Normalize((GameInformation.entities.player.transform.position + (Vector3.up * 2) + (transform.right * 5)) - transform.position) * speed * Time.deltaTime;
            }
        }
        if (Vector3.Distance(GameInformation.entities.player.transform.position, transform.position) > 5)
        {
            if (attackrateTimer < 0)
            {
                attackrateTimer = attackrate;
                ani.SetTrigger(attack);
                attacking = true;
                timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ani.SetTrigger(attack);
            attacking = true;
            timer = 0;
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= attackdelay)
            {
                breath.SetActive(true);
                attackBox.SetActive(true);
                breathAni.SetTrigger(fire);

            }
            if (timer >= attackDuration)
            {
                breath.SetActive(false);
                attackBox.SetActive(false);
                attacking = false;
            }
        }

        if (GameInformation.entities.player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
