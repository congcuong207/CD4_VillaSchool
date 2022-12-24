using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject target;
    public GameObject zombie;
    public Transform bulletPos;
    public ParticleSystem particle;
    public float timeRemaining = 3;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        audio=GetComponent<AudioSource>();
        particle.Stop();
        audio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        zombie = GameObject.FindGameObjectWithTag("Zombie");
        if (zombie != null)
        {
            transform.LookAt(zombie.transform);

            if (Vector3.Distance(transform.position, zombie.transform.position) > 250 && Vector3.Distance(transform.position, target.transform.position) < 500)
            {
                transform.Translate(Vector3.forward * 10f * Time.deltaTime);
            }
            if (Vector3.Distance(transform.position, zombie.transform.position) < 250)
            {
                transform.Translate(Vector3.back * 10f * Time.deltaTime);
            }
            if(Vector3.Distance(transform.position, zombie.transform.position) > 100 && Vector3.Distance(transform.position, zombie.transform.position) < 400)
            {
                if (timeRemaining > 0)
                {
                    particle.Stop();
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    timeRemaining = 3;
                    if (particle.isStopped)
                    {
                        if (!audio.isPlaying)
                        {
                            audio.Play();
                        }
                        Shot();
                        particle.Play();
                    }
                }
            }
           

        }
        else
        {
            transform.LookAt(target.transform);
            if (Vector3.Distance(transform.position, target.transform.position) > 250 && Vector3.Distance(transform.position, target.transform.position) < 500)
            {
                transform.Translate(Vector3.forward * 10f * Time.deltaTime);
            }
            if (Vector3.Distance(transform.position, target.transform.position) < 250)
            {
                transform.Translate(Vector3.back * 10f * Time.deltaTime);
            }
            if (Vector3.Distance(transform.position, target.transform.position) > 200 && Vector3.Distance(transform.position, target.transform.position) < 400)
            {
                if (timeRemaining > 0)
                {
                    particle.Stop();
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    timeRemaining = 3;
                    if (particle.isStopped)
                    {
                        if (!audio.isPlaying)
                        {
                            audio.Play();
                        }
                        Shot();
                        particle.Play();
                    }
                }
            }
            else
            {
                particle.Stop();
            }

        }
    }
    public void Shot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
