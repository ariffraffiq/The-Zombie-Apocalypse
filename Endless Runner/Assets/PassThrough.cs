using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThrough : MonoBehaviour
{
    Collider trigger;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        trigger = GetComponent<Collider>();
        //Here the GameObject's Collider is not a trigger
        
    }

    public void Pass()
    {
        
        StartCoroutine(PoisonEffect());  
    }

     IEnumerator PoisonEffect()
      {
          trigger.isTrigger = false;

          yield return new WaitForSeconds(15f); 

          trigger.isTrigger = true;
        
      }
}
