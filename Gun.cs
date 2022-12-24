using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Update is called once per frame
    public void Shot()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 200);
        print(hit.transform.name);
    }
}
