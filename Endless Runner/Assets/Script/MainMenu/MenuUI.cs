using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject _play, _multiplayer, waiting,  server, leaderboard, quit;

    public void _Play()
    {
        CloseAll();
        //_play.gameObject.SetActive(true);
        SceneManager.LoadScene("SinglePlayer");
    }
 
    public void _Multiplayer()
    {
        CloseAll();
        server.gameObject.SetActive(true);
        _multiplayer.gameObject.SetActive(true);
        
    }

     public void Waiting()
    {
        CloseAll();
        waiting.gameObject.SetActive(true);
        _multiplayer.gameObject.SetActive(false);
    }

    public void Leaderboard()
    {
        CloseAll();
        leaderboard.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void CloseAll()
    {
      _play.gameObject.SetActive(false);  
      leaderboard.gameObject.SetActive(false);
      _multiplayer.gameObject.SetActive(false);
       server.gameObject.SetActive(false);
      //quit.gameObject.SetActive(false);
    }
}
