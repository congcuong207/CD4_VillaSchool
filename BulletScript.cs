using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletScript : MonoBehaviour
{
    private GameObject player;
    private GameObject zombie;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        zombie = GameObject.FindGameObjectWithTag("Zombie");
        player = GameObject.FindGameObjectWithTag("Player");

        if (zombie != null && Vector3.Distance(transform.position, zombie.transform.position) < Vector3.Distance(transform.position, player.transform.position))
        {
            transform.position = Vector3.Lerp(transform.position, zombie.transform.position, force * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, force * Time.deltaTime);
        }
       

    }
    private void Awake()
    {
        Destroy(gameObject, 2f);
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Zombie"))
        {
            HealZombie heal = other.transform.GetComponent<HealZombie>();
            if (transform.CompareTag("Bullet"))
            {
                heal.TakeDame(1.5f);
            }
            else
            {
                heal.TakeDame(15f);
            }
        }
    }
}
