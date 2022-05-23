using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using TMPro;

public class CharacterMove : MonoBehaviourPunCallbacks
{
    // charMove.cs
    public int speed = 5;
    public int forward = 12;
    public Animator anim, death;
    public AudioSource aud;
    private PhotonView pv;
    Rigidbody rb;

    // life.cs
    private TextMeshProUGUI lifeText;
    public GameObject bgrMusic;
    private GameObject gameOverPanel;
    [SerializeField]
    private int life = 3;
    private Collider trigger;
    private bool died = false;
    public Animator run;
    private GameObject mainCamera;

    //ScoreUpdate.cs
    private GameObject checkpoint;
    private TextMeshProUGUI distanceText;
    private float distance;

    //immune.cs
    public GameObject powerUp;
    private GameObject PowerUpcountdown;
    private bool speedUp = false;
    public PassObject pass;

    //poision.cs
    private bool slow = false;

    // GameOver panel part
    public GameObject ResultItem;
    private Transform ResultListparent;
    private NewGameFlow script;
    

    void Start()
    {
        // charMove.cs
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        anim.Play("m_run");

        // ScoreUpdate.cs
        checkpoint = GameObject.Find("/Game Manager/StartingPoint");
        distanceText = GameObject.Find("/GUI/Distance").GetComponent<TextMeshProUGUI>();

        //life.cs
        lifeText = GameObject.Find("/GUI/Life/lifeText").GetComponent<TextMeshProUGUI>();
        gameOverPanel = GameObject.Find("/GUI/GameOver");
        mainCamera = GameObject.Find("/MainCamera");

        lifeText.text = "x " + life;
        gameOverPanel.SetActive(false);
        trigger = GetComponent<Collider>();
        mainCamera.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward);

        //Immunes.cs
        trigger.isTrigger = false;
        PowerUpcountdown = GameObject.Find("/GUI/PowerUpRampage");
        PowerUpcountdown.SetActive(false);

        // GameOver panel part
        script = GameObject.Find("/Game Manager").GetComponent<NewGameFlow>();
    }

    void Update()
    {
        if (pv.IsMine)
        {
            //life.cs
            lifeText.text = "x " + life;
            if (died == false)
            {
                if (slow == true)
                {
                    forward = 4;
                }
                else if (speedUp)
                {
                    forward = 20;
                }
                else
                {
                    forward = 12;
                }

                // CharMove.cs
                if (Input.GetKey("a"))
                {
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }

                if (Input.GetKey("d"))
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }

                transform.Translate(Vector3.forward * forward * Time.deltaTime);
                mainCamera.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward);
            }
            else if (died == true)
            {
                transform.Translate(Vector3.down * 0 * Time.deltaTime);
            }

            // ScoreUpdate.cs
            distance = (transform.position.z - checkpoint.transform.position.z);
            distanceText.text = "Distance: " + distance.ToString("0") + " meters";
        }
    }

    void OnCollisionEnter(Collision collision)
    {        
        if (pv.IsMine)
        {
            //Check for a match with the specific tag on any GameObject that collides with your GameObject
            if (collision.gameObject.tag == "Obstacle")
            {
                life--;
                died = true;
                aud.Play(1);
                death.Play("m_death_A");
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                mainCamera.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                if (life < 1)
                {       
                    life=0;      
                    //FindObjectOfType<APISystem>().InsertPlayerActivity(PlayerPrefs.GetString("username"), "Time_TakenV2", "add", distance.ToString("0"));  
                    pv.RPC("onPlayerGameOver", RpcTarget.AllBuffered, PhotonNetwork.NickName, distance.ToString("0"));
                }
                else
                {
                    StartCoroutine(Respawn());
                }
            }
        }
    }
    [PunRPC]
    void onPlayerGameOver(string name, string score)
    {
        script = GameObject.Find("/Game Manager").GetComponent<NewGameFlow>();
        Debug.Log("hi");
        script.setPlayerResult(name, score);
    }

    void OnTriggerEnter(Collider other)
    {
        if (pv.IsMine)
        {
            //life.cs
            if (other.gameObject.tag == "Life")
            {
                life++;
                Debug.Log("Add Life");
            }

            //immune.cs
            if (other.gameObject.tag == "PowerUp")
            {
                StartCoroutine(PowerUp());
            }

            //poison.cs
            if (other.gameObject.tag == "Poison")
            {
                StartCoroutine(PoisonEffect());
            }
        }

    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        run.Play("m_run");
        mainCamera.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forward);
        died = false;
        trigger.isTrigger = true;
        powerUp.gameObject.SetActive(true);
        bgrMusic.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        trigger.isTrigger = false;
        powerUp.gameObject.SetActive(false);
    }

    IEnumerator PowerUp()
    {
        speedUp = true;
        trigger.isTrigger = true;
        powerUp.SetActive(true);
        PowerUpcountdown.SetActive(true);
        bgrMusic.gameObject.SetActive(false);
        pass.Pass();

        yield return new WaitForSeconds(15f);
        speedUp = false;
        trigger.isTrigger = false;
        powerUp.SetActive(false);
        PowerUpcountdown.SetActive(false);
        bgrMusic.gameObject.SetActive(true);
        pass.Normal();
    }

    IEnumerator PoisonEffect()
    {
        slow = true;
        yield return new WaitForSeconds(8);
        slow = false;
    }
}
