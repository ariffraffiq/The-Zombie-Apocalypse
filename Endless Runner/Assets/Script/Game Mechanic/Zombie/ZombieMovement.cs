using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
         StartCoroutine(ZombieMove());    
        
    }

   
    IEnumerator ZombieMove()
    {
        yield return new WaitForSeconds(4);
        GetComponent<Rigidbody>().velocity = new Vector3(4,0,0);

        yield return new WaitForSeconds(4);
        GetComponent<Rigidbody>().velocity = new Vector3(-4,0,0);
        StartCoroutine (ZombieMove());
    }

   
}
