using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class _PlayerAnimation : MonoBehaviour
{

    [SerializeField]
    Animator anim;

    int jumpHash = Animator.StringToHash("Jump");

    int baseAttack = Animator.StringToHash("BaseAttack");
    int secondAttack = Animator.StringToHash("SecondAttack");
    int thirdAttack = Animator.StringToHash("ThirdAttack");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playJump()
    {
        anim.SetTrigger(jumpHash);
    }

    public void setAir(bool t)
    {
        anim.SetBool("InAir", t);
    }
    public void setSpeed(float s)
    {
        anim.SetFloat("Speed", s/5f);
    }

    public void playBaseAttack()
    {
        anim.SetTrigger(baseAttack);
    }
    public void playSecondAttack()
    {
        anim.SetTrigger(secondAttack);
    }
    public void playThirdAttack()
    {
        anim.SetTrigger(thirdAttack);
    }
    public void setYVelocity(float y)
    {
        anim.SetFloat("yVelocity", y);
    }

}
