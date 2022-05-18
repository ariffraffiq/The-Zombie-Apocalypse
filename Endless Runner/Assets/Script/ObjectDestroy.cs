using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public GameObject obj;

   void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        //StartCoroutine(ExampleCoroutine());
        
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
       // Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        
    }

     void OnTriggerEnter(Collider collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        // if (collision.gameObject.tag == "Destroy")
        // {
            

        //      Debug.Log("Hit Object");
        //      obj.gameObject.SetActive(false);
        //      //Destroy(obj);
            
        // }

         if (collision.gameObject.name == "Buildings(Clone)")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            //  Debug.Log("HIT building clone");
              Destroy(GameObject.Find("Buildings(Clone)"));
          
        }

         if (collision.gameObject.name == "Vehicles_HotdogTruck(Clone)")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            //  Debug.Log("HIT hotdog clone");
              Destroy(GameObject.Find("Vehicles_HotdogTruck(Clone)"));
          
        }

         if (collision.gameObject.name == "Vehicles_PizzaCar(Clone)")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            //  Debug.Log("HIT pizza clone");
              Destroy(GameObject.Find("Vehicles_PizzaCar(Clone)"));
          
        }

         if (collision.gameObject.name == "Prop_Dumpster(Clone)")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            //  Debug.Log("HIT dumbster clone");
              Destroy(GameObject.Find("Prop_Dumpster(Clone)"));
          
        }
    }
}
