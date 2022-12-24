using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealZombie : MonoBehaviour
{
    public float health = 500f;
    public float healthMax = 500f;
    Animator animator;
    public float timeRemaining = 2;
    public void TakeDame(float dame)
    {
        health-= dame;
        if(health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            FollowPlayer follow = gameObject.GetComponent<FollowPlayer>();
            if (follow != null)
            {
                follow.enabled = false;
                animator.SetBool("Die", true);
                Destroy(gameObject, 3);

            }
        }
    }
   public void HealHP()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 2;
            if (health <= healthMax)
            {
                health+=10;
            }
        }

    }
    private void Start()
    {
        animator = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
