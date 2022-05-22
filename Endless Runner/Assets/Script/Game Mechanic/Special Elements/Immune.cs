using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immune : MonoBehaviour
{
    public GameObject powerUp,PowerUpcountdown,bgrMusic;
    Collider trigger;
    bool  speedUp = false;
    public PassObject pass;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        trigger = GetComponent<Collider>();
        //Here the GameObject's Collider is not a trigger
        trigger.isTrigger = false;
        //Output whether the Collider is a trigger type Collider or not
        Debug.Log("Trigger On : " + trigger.isTrigger);
        // passScript.GetComponent<PassThrough>().Pass();
    }

    // Update is called once per frame
    void Update()
    {
        if(speedUp == true)
        {
            Debug.Log("SpeedUp");
           Debug.Log(Vector3.forward * 10* Time.deltaTime);
            transform.Translate(Vector3.forward * 10* Time.deltaTime);
           Debug.Log(Vector3.forward * 10* Time.deltaTime);
        }
        
    }

     //Power up trigger
      void OnTriggerEnter(Collider other) 
      {
           if (other.gameObject.tag == "PowerUp")
        {
            speedUp = true;
            StartCoroutine(PowerUp());
            speedUp = false;
        }
      }

       IEnumerator PowerUp()
      {
          trigger.isTrigger = true;
          powerUp.gameObject.SetActive(true);
          PowerUpcountdown.gameObject.SetActive(true);
          bgrMusic.gameObject.SetActive(false);
          pass.Pass();

          yield return new WaitForSeconds(15f);
          
          trigger.isTrigger = false;
          powerUp.gameObject.SetActive(false);
          PowerUpcountdown.gameObject.SetActive(false);
          bgrMusic.gameObject.SetActive(true);
          pass.Normal();
      }
}
