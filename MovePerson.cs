using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class MovePerson : MonoBehaviour
{
    public GameObject target;
    GameObject zombie;
    public float speed = 1f;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        zombie= GameObject.FindGameObjectWithTag("Zombie");
        if(zombie != null&& Vector3.Distance(transform.position, target.transform.position)< Vector3.Distance(transform.position, target.transform.position))
        {
            if (Vector3.Distance(transform.position, zombie.transform.position) < 100)
            {
                speed = 40;
                animator.SetBool("run", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            else if (Vector3.Distance(transform.position, zombie.transform.position) < 200)
            {
                speed = 20;
                animator.SetBool("walk", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("run", false);
                animator.SetBool("walk", false);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 100)
            {
                speed = 40;
                animator.SetBool("run", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            else if (Vector3.Distance(transform.position, target.transform.position) < 200)
            {
                speed = 20;
                animator.SetBool("walk", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("run", false);
                animator.SetBool("walk", false);
            }
        }

    }
}
