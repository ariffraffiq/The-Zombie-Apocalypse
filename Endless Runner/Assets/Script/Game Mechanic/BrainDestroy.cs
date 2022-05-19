using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainDestroy : MonoBehaviour
{
    public GameObject brain;

      void OnTriggerEnter(Collider other) 
      {
           if (other.gameObject.tag == "Player")
        {
            Destroy(brain);
        }
      }
}
