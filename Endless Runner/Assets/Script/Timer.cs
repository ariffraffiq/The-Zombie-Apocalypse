using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
   public TextMeshProUGUI timerText, result;
     private float secondsCount,s;
     private int minuteCount,m;
    [SerializeField]
     private float score;
     private int hourCount,h;
     public GameObject timecount,timeresult,powerUp,PowerUpcountdown,bgrMusic;
      Collider trigger;
     
  

     void Update()
     {
        StartCoroutine(timer());
     }

     IEnumerator timer()
     {
         UpdateTimerUI();
         yield return new WaitForSeconds(1);

         s = secondsCount;
         m = minuteCount;
         h = hourCount;

         result.text = minuteCount +" Minute, "+(int)secondsCount + " Second";

     }

 //call this on update
     public void UpdateTimerUI()
     {
         //set timer UI
         secondsCount += Time.deltaTime;
         score += Time.deltaTime;
         //int score = convert.ToInt32(secondsCount);
         timerText.text = "TIME :  " + minuteCount +" : "+(int)secondsCount ;
         if(secondsCount >= 60){
             minuteCount++;
             secondsCount = 0;
         }
         
         else if(minuteCount >= 60)
         {
             hourCount++;
             minuteCount = 0;
         }    
     }

      void OnCollisionEnter(Collision collision)
      {
          //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Obstacle")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //StopCoroutine(timer());
            timecount.gameObject.SetActive(false);
            //Debug.Log("HIT");
            StartCoroutine(saveScore());
        }
      }

       //Power up trigger
      void OnTriggerEnter(Collider other) 
      {
           if (other.gameObject.tag == "PowerUp")
        {
            
            StartCoroutine(PowerUp());
        }
      }

      IEnumerator saveScore()
      {
          yield return new WaitForSeconds(1f);
          FindObjectOfType<APISystem>().InsertPlayerActivity(PlayerPrefs.GetString("username"), "Time_TakenV2", "add", score.ToString("0"));
          Debug.Log("Update player score");
      }

      IEnumerator PowerUp()
      {
          trigger.isTrigger = true;
          powerUp.gameObject.SetActive(true);
          PowerUpcountdown.gameObject.SetActive(true);
          bgrMusic.gameObject.SetActive(false);

          yield return new WaitForSeconds(15f);
          
          trigger.isTrigger = false;
          powerUp.gameObject.SetActive(false);
          PowerUpcountdown.gameObject.SetActive(false);
          bgrMusic.gameObject.SetActive(true);
      }

       void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        trigger = GetComponent<Collider>();
        //Here the GameObject's Collider is not a trigger
        trigger.isTrigger = false;
        //Output whether the Collider is a trigger type Collider or not
        Debug.Log("Trigger On : " + trigger.isTrigger);
    }

}
