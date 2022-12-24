using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    // Start is called before the first frame update
    Collider collider;
    void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        collider.enabled = true;
    }
    public void StopAttack()
    {
        collider.enabled = false;
    }
}
