using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SkeletonAnimation : MonoBehaviour
{
    public Animator ani;

    int hitHash = Animator.StringToHash("Hit");

    float lastHp = 0;
    // Start is called before the first frame update
    void Start()
    {
        lastHp = GetComponent<Enemy>().health;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastHp > GetComponent<Enemy>().health)
        {
            lastHp = GetComponent<Enemy>().health;
            playHit();
        }
    }

    public void playHit()
    {
        ani.SetTrigger(hitHash);
    }
}
