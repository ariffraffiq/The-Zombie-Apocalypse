using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public GameObject gameOver,immune,bgrMusic;
    [SerializeField]
    int life = 3;
    Collider trigger;
    bool died = false;
    public Animator run;

    // Start is called before the first frame update
    void Start()
    {
         trigger = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "x " + life;
        
        if (died == false)
        {
            transform.Translate(Vector3.forward * 12* Time.deltaTime);
        }

        else if (died == true)
        {
            transform.Translate(Vector3.down * 0* Time.deltaTime);  
            Debug.Log("died");

            //GetComponent<CharacterController>().enabled = false;
        }
    }

    
      void OnCollisionEnter(Collision collision)
      {
          //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Obstacle")
        {
            life--;
            died = true;

            if (life < 1)
            {
                gameOver.gameObject.SetActive(true);
                died = true;
                //transform.Translate(Vector3.down * 0* Time.deltaTime);  
            }

            else
            {
                StartCoroutine(Respawn());
            }  
        } 
      }

        void OnTriggerEnter(Collider other) 
      {
           if (other.gameObject.tag == "Life")
        {
            
            life++; 
            Debug.Log("Add Life");
        }
      }

      

       IEnumerator Respawn()
      {
          yield return new WaitForSeconds(3);
          run.Play("m_run");
          died = false;
          trigger.isTrigger = true;
          immune.gameObject.SetActive(true);
          bgrMusic.gameObject.SetActive(true);

          yield return new WaitForSeconds(5);
          
          trigger.isTrigger = false;
          immune.gameObject.SetActive(false);
      }

      public void End()
      {
          SceneManager.LoadScene("MainMenu");
      }

}
