using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    public TMPro.TMP_Text userName;
    public GameObject mainButton, loginButton;
    //public Text username;
    public APISystem api;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void savePlayerName()
    {
        if (string.IsNullOrEmpty(userName.text))
        {
            Debug.Log("Enter the username");
        }

        else
        {
            PlayerPrefs.SetString("username", userName.text);
            FindObjectOfType<APISystem>().Register(userName.text, userName.text, userName.text, userName.text);
            Debug.Log(userName.text);
            Debug.Log("My name is " + PlayerPrefs.GetString("username"));
            //mainButton.gameObject.SetActive(true);
            //loginButton.gameObject.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
    

