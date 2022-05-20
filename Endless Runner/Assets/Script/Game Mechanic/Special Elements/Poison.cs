using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    bool slow = false;
      //Power up trigger
      void OnTriggerEnter(Collider other) 
      {
           if (other.gameObject.tag == "Poison")
        {      
            StartCoroutine(PoisonEffect()); 
            
        }
      }

       IEnumerator PoisonEffect()
      {
          slow = true;
          yield return new WaitForSeconds(8);
          slow = false;
          
      }

      void Update()
      {
          if(slow == true)
          {
              transform.Translate(Vector3.forward * -8* Time.deltaTime);
              Debug.Log("Slow");
          }
          
          else if ( slow == false)
          {
              //transform.Translate(Vector3.forward * 12* Time.deltaTime);
              Debug.Log("Normal");
          }
      }
}
