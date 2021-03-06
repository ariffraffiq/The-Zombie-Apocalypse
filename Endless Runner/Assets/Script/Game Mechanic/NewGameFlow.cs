using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class NewGameFlow : MonoBehaviourPunCallbacks
{
    public Transform building, truck1, truck2, dusbin, powerUP, zombie, zombie2, life, poison;
    private Vector3 nextSpawn, truck1_Spawn, truck2_Spawn, dusbin_Spawn, powerUpSpawn, zombieSpawn, zombieSpawn2, lifeSpawn, poisonSpawn;
    private int randX, randx2, randx3, randX4, randx5, randX6, randx7, randx8;
    int i;
    public GameObject gameOverPanel;
    public GameObject ResultItem;
    public Transform ResultListparent;
    public Text winnerText;
    List<ScoreClass> myPlayer = new List<ScoreClass>();
    private ExitGames.Client.Photon.Hashtable setResult = new ExitGames.Client.Photon.Hashtable();


    // Start is called before the first frame update
    void Start()
    {
        winnerText.gameObject.SetActive(false);
        nextSpawn.z = 39;
        truck1_Spawn.z = 30;
        truck2_Spawn.z = 60;
        dusbin_Spawn.z = 45;
        powerUpSpawn.z = 80;
        zombieSpawn.z = 50;
        zombieSpawn2.z = 100;
        lifeSpawn.z = 100;
        poisonSpawn.z = 50;

        Debug.Log("I am master "+PhotonNetwork.IsMasterClient);
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(SpawnBuilding());
            StartCoroutine(SpawnPowerUp());
            StartCoroutine(SpawnZombie());
            StartCoroutine(SpawnZombie2());
            StartCoroutine(SpawnLife());
            StartCoroutine(SpawnPoison());
        }

    }

    IEnumerator SpawnPoison()
    {
        yield return new WaitForSeconds(1);
        randx8 = Random.Range(-16, -4);
        poisonSpawn.y = 0;
        poisonSpawn.x = randx8;
        PhotonNetwork.Instantiate("Poison", poisonSpawn, poison.rotation);
        poisonSpawn.z += 20;
        StartCoroutine(SpawnPoison());
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(1);
        randX4 = Random.Range(-16, -4);
        powerUpSpawn.y = 0;
        powerUpSpawn.x = randX4;
        PhotonNetwork.Instantiate("Potion", powerUpSpawn, powerUP.rotation);
        powerUpSpawn.z += 500;
        StartCoroutine(SpawnPowerUp());
    }


    IEnumerator SpawnLife()
    {
        yield return new WaitForSeconds(1);
        randx7 = Random.Range(-16, -4);
        lifeSpawn.y = 2;
        lifeSpawn.x = randx7;
        PhotonNetwork.Instantiate("DONUT", lifeSpawn, life.rotation);
        lifeSpawn.z += 300;
        StartCoroutine(SpawnLife());
    }

    IEnumerator SpawnZombie()
    {
        yield return new WaitForSeconds(1);
        randx5 = Random.Range(-16, -4);
        zombieSpawn.y = 0;
        zombieSpawn.x = randx5;
        PhotonNetwork.Instantiate("TT_demo_zombie", zombieSpawn, zombie.rotation);
        zombieSpawn.z += 20;
        StartCoroutine(SpawnZombie());
    }

    IEnumerator SpawnZombie2()
    {
        yield return new WaitForSeconds(1);
        randX6 = Random.Range(-16, -4);
        zombieSpawn2.y = 0;
        zombieSpawn2.x = randX6;
        PhotonNetwork.Instantiate("NewZombie", zombieSpawn2, zombie2.rotation);
        zombieSpawn2.z += 50;
        StartCoroutine(SpawnZombie2());
    }



    IEnumerator SpawnBuilding()
    {
        yield return new WaitForSeconds(1);
        randX = Random.Range(-13, -6);

        //truck1_Spawn = nextSpawn;
        truck1_Spawn.y = 0;
        truck1_Spawn.x = randX;

        //spawn building
        PhotonNetwork.Instantiate("Buildings", nextSpawn, building.rotation);
        nextSpawn.z += 39;

        //spawn Truck1
        PhotonNetwork.Instantiate("Vehicles_PizzaCar", truck1_Spawn, truck1.rotation);
        truck1_Spawn.z += 60;


        yield return new WaitForSeconds(1);
        randx2 = Random.Range(-13, -6);

        //spawn building
        PhotonNetwork.Instantiate("Buildings", nextSpawn, building.rotation);
        nextSpawn.z += 39;

        //truck2_Spawn = nextSpawn;
        truck2_Spawn.y = 0;
        truck2_Spawn.x = randx2;

        //spawn Truck2
        PhotonNetwork.Instantiate("Vehicles_HotdogTruck", truck2_Spawn, truck2.rotation);
        truck2_Spawn.z += 60;


        yield return new WaitForSeconds(1);
        randx3 = Random.Range(-3, -16);

        //spawn building
        PhotonNetwork.Instantiate("Buildings", nextSpawn, building.rotation);
        nextSpawn.z += 39;

        //truck2_Spawn = nextSpawn;
        dusbin_Spawn.y = 0;
        dusbin_Spawn.x = randx3;

        //spawn Truck2
        PhotonNetwork.Instantiate("Prop_Dumpster", dusbin_Spawn, dusbin.rotation);
        dusbin_Spawn.z += 60;
        StartCoroutine(SpawnBuilding());
    }

    public void OnClickLeaveGame(){
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SceneManager.LoadScene("MainMenu");
    }

    public void setPlayerResult(string name, string score){
        ScoreClass a = new ScoreClass();
        a.addplayer(name,score);
        myPlayer.Add(a);
        DisplayResult();
    }
    public void DisplayResult()
    {
        // condition to display gameOverPanel to player that had end the game 
        foreach(ScoreClass _score in myPlayer){
            if(_score.playername==PhotonNetwork.NickName){
                gameOverPanel.gameObject.SetActive(true);
            }        
        }
    
        int index=1;
        // condition if all player end display the winner else hide the winner text
        Debug.Log("hihihi");
        Debug.Log(PhotonNetwork.PlayerList.Length);
        Debug.Log(myPlayer.Count);
        if(myPlayer.Count==PhotonNetwork.PlayerList.Length){
            winnerText.gameObject.SetActive(true);
            int number = myPlayer.Count-1;
            winnerText.text="Winner : "+myPlayer[number].playername;
        }

        // Reload previous listing
        foreach (Transform child in ResultListparent)
        {
            Destroy(child.gameObject);
        }
        foreach (Player player in PhotonNetwork.PlayerList)
        {  
            ResultItem.transform.Find("PlayerText").GetComponent<Text>().text = "Player "+index;
            Instantiate(ResultItem, ResultListparent).transform.Find("PlayerName").GetComponent<Text>().text = player.NickName; 
            index++;       
        }
        foreach(Transform child in ResultListparent){
            foreach(ScoreClass _score in myPlayer){
                // if player name in myplayer list mean he had end and display the score else show playing text
                 if(child.transform.Find("PlayerName").GetComponent<Text>().text == _score.playername){
                     child.transform.Find("PlayerResult").GetComponent<Text>().text = _score.score;
                     break;
                 }
                 else{
                    child.transform.Find("PlayerResult").GetComponent<Text>().text = "Playing";
                 }
            }
           index++;
        }
    }
}
