using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class Victory : MonoBehaviour
{
    public bool isDestroy = false;
    GameObject police;
    public GameObject victory;
    int healTank = 3;
    public float timeRemaining = 3;
    public bool isCountDown = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountDown)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                victory.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand") )
        {
            police = GameObject.FindGameObjectWithTag("Person");
            if(police == null)
            {
                isDestroy = true;
                isCountDown = true;
                Destroy(gameObject, 3f);
                
            }
            if (transform.CompareTag("Tank"))
            {
                healTank--;
                if(healTank < 0)
                {
                    isDestroy = true;
                    Destroy(gameObject, 3f);
                }
            }

        }
    }
}
