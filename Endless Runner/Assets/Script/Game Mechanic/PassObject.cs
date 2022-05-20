using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassObject : MonoBehaviour
{
      Collider trigger;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        
        //Here the GameObject's Collider is not a trigger
    }

    void Update()
    {
        
    }

    public void Pass()
    {
        trigger = GetComponent<Collider>();
        trigger.isTrigger = false;
        Debug.Log("Pass");
       // StartCoroutine(Poison());  
    }

    public void Normal()
    {
        trigger = GetComponent<Collider>();
        trigger.isTrigger = true;
      //  StartCoroutine(Poison());  
    }

     IEnumerator Poison()
      {
          trigger.isTrigger = false;

          yield return new WaitForSeconds(15f); 

          trigger.isTrigger = true;
        
      }
}
