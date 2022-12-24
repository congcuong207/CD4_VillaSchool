using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Victory victory;

    ParticleSystem particle;
    AudioSource audio;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        audio=GetComponent<AudioSource>();
        audio.Stop();
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (victory.isDestroy)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            DestroyPlane();
        }
    }
    public void DestroyPlane()
    {
        particle.Play();
    }
}
