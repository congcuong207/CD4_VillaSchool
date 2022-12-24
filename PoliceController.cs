using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PoliceController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject target;
    public GameObject zombie;
    public Transform bulletPos;
    Animator animator;
    AudioSource audio;
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        audio = GetComponent<AudioSource>();
        audio.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        zombie = GameObject.FindGameObjectWithTag("Zombie");
        if(zombie != null&& Vector3.Distance(transform.position, zombie.transform.position) < 100)
        {
            animator.SetBool("shot", true);
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            transform.LookAt(zombie.transform);
            transform.Translate(Vector3.back * 6f * Time.deltaTime);
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 200)
            {
                if (!audio.isPlaying)
                {
                    audio.Play();
                }
                animator.SetBool("shot", true);
                transform.LookAt(target.transform);
                transform.Translate(Vector3.back * 6f * Time.deltaTime);
            }
            else
            {
                if (audio.isPlaying)
                {
                    audio.Stop();
                }
                animator.SetBool("shot", false);
            }
        }

    }
    public void Shot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
