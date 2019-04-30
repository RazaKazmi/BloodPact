using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimation : MonoBehaviour
{
    public Animator ani;

    public bool idle, run, jump;
    public int attack = 0;

    int jumpHash = Animator.StringToHash("Jump");
    int attack1Hash = Animator.StringToHash("Attack1");
    int attack2Hash = Animator.StringToHash("Attack2");
    int attack3Hash = Animator.StringToHash("Attack3");
    int castHash = Animator.StringToHash("Cast");

    int currentattack = 0;
    // Start is called before the first frame update
    void Start()
    {
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        ani.SetFloat("Scale", GameInformation.entities.player.GetComponent<Player>().baseSpeed / 10);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger(jumpHash);
        }
        if (Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger(attack1Hash);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ani.SetTrigger(castHash);
        }

        if (Input.GetKey(KeyCode.D))
        {
            ani.SetFloat("Speed", 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ani.SetFloat("Speed", 1);
        }
        else
        {
            ani.SetFloat("Speed", 0);
        }

        if(GameInformation.entities.player.GetComponent<Player>().canJump)
        {
            ani.SetBool("OnGround", true);
        }
        else
        {
            ani.SetBool("OnGround", false);
        }
    }
}
