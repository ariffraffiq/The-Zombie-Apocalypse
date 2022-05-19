using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class CharMove : MonoBehaviour
{
    public int speed = 5;
    public Animator anim, death;
    public GameObject timecount;
    public AudioSource  aud;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    PhotonView view;
         
         Rigidbody rb;

       
     
         void OnCollisionStay()
         {
             isGrounded = true;
         }

      void Start()
    {
        view = GetComponent<PhotonView>();
        //GetComponent<Rigidbody>().velocity = new Vector3(0,0,12);
        
        anim.Play("m_run");
        
         //Start the coroutine we define below named ExampleCoroutine.
        //StartCoroutine(ExampleCoroutine());

        rb = GetComponent<Rigidbody>();
             jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

  

     IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.

        yield return new WaitForSeconds(3);     
            timecount.gameObject.SetActive(true);
            Time.timeScale = 0; 
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * 12* Time.deltaTime);
        // if (view.IsMine)
         //{
            if (Input.GetKey("a"))
            {
            // GetComponent<Rigidbody>().velocity = new Vector3(-1,0,12);
            // StartCoroutine(StopMove());

            transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            if (Input.GetKey("d"))
            {
                //GetComponent<Rigidbody>().velocity = new Vector3(1,0,12);
                //StartCoroutine(StopMove());

                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
        
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
         //}
        

        

    }

    IEnumerator StopMove()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,12);
    }

       void OnCollisionEnter(Collision collision)
      {
          //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Obstacle")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            aud.Play(1);
            death.Play("m_death_A");
            StartCoroutine(ExampleCoroutine());
       
      }

      
}

 public void TryAgain()
      {
          SceneManager.LoadScene("Demo");
          Time.timeScale = 1; 
      }

    public void MainMenu()
      {
          SceneManager.LoadScene("MainMenu");
          Time.timeScale = 1; 
      }  
}