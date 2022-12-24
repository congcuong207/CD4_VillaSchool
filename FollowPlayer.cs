using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1f;
    public GameObject target;
    public GameObject police;
    public RightHandController RigthandController;
    Animator animator;
    AudioSource audio;
    void Start()
    {
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        audio= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        police = GameObject.FindGameObjectWithTag("Person");
        if(police != null)
        {
            if (Vector3.Distance(transform.position, police.transform.position) > 20)
            {
                animator.SetBool("attack", false);
                animator.SetBool("walk", true);
                transform.position = Vector3.Lerp(transform.position, police.transform.position, speed * Time.deltaTime);
                transform.LookAt(police.transform);
            }
            else
            {
                animator.SetBool("attack", true);
            }
     
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 100)
            {
                animator.SetBool("attack", false);
                animator.SetBool("walk", true);
                transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
                transform.LookAt(target.transform);
            }
            else
            {
                animator.SetBool("walk", false);
            }
        }
       
    }
    public void right_attack()
    {
        RigthandController.Attack();
    }
    public void right_attackStop()
    {
        RigthandController.StopAttack();
    }
}
