using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class change_object : MonoBehaviour
{
    public GameObject monter;
    public float timeRemaining = 3;
    public bool timerIsRunning = false;
    public ParticleSystem particle;
    public AudioClip[] audios;
    public AudioSource audioSources;
    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
        audioSources=GetComponent<AudioSource>();
        audioSources.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (!audioSources.isPlaying)
            {
                audioSources.clip = audios[0];
                audioSources.Play();
            }
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Instantiate(monter, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            particle.Play();
            timerIsRunning=true;    
        }
    }
}
