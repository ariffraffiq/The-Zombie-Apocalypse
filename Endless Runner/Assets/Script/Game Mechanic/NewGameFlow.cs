using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameFlow : MonoBehaviour
{
     public Transform tileObj;
    private Vector3 nextTileSpawn;
    public Transform brickObj;
    private Vector3 nextCoinSpawn;
    private int randX;
    public Transform smCrateObj;
    private Vector3 nextsmCrateSpawn;
    public Transform dbCrateObj;
    private Vector3 nextDbCrateSpawn;
    public Transform cartObj;
    private Vector3 nextCartSpam;
    private int randChoice;
    public static int totalCoins = 0;
    public Transform coinObj;
    public Transform potionObj;


    // Start is called before the first frame update
    void Start()
    {
        totalCoins = 0;
        nextTileSpawn.z = 39.4f;
        StartCoroutine(spawnTile());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);
        randX = Random.Range(0, 3);
        nextCoinSpawn = nextTileSpawn;
        nextCoinSpawn.x = randX * 2.5f;
        nextCoinSpawn.y = 1.58f;
        Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
        Instantiate(coinObj, nextCoinSpawn, coinObj.rotation);

        nextTileSpawn.z += 7.88f;
        randX = Random.Range(0, 3);
        nextsmCrateSpawn.z = nextTileSpawn.z;
        nextsmCrateSpawn.y = 1.6f;
        nextsmCrateSpawn.x = randX * 2.5f;
        Instantiate(tileObj, nextTileSpawn, tileObj.rotation);
        Instantiate(smCrateObj, nextsmCrateSpawn, smCrateObj.rotation);

        if (randX == 0)
        {
            randX = 1;
        }
        else if (randX == 1)
        {
            randX = 2;
        }
        else
        {
            randX = 0;
        }

        randChoice = Random.Range(0, 4);
        if (randChoice == 0)
        {
            nextDbCrateSpawn.z = nextTileSpawn.z;
            nextDbCrateSpawn.y = 1.53f;
            nextDbCrateSpawn.x = randX * 2.5f;
            Instantiate(dbCrateObj, nextDbCrateSpawn, dbCrateObj.rotation);
        }
        else if (randChoice == 1)
        {
            nextCartSpam.z = nextTileSpawn.z;
            nextCartSpam.y = 1.16f;
            nextCartSpam.x = randX * 2.5f;
            Instantiate(cartObj, nextCartSpam, cartObj.rotation);
        }
        else if (randChoice == 2)
        {
            nextCartSpam.z = nextTileSpawn.z;
            nextCartSpam.y = 0f;
            nextCartSpam.x = randX * 2.5f;
            Instantiate(potionObj, nextCartSpam, potionObj.rotation);
        }
        else
        {
            nextCartSpam.z = nextTileSpawn.z;
            nextCartSpam.y = 0.66f;
            nextCartSpam.x = randX * 2.5f;
            Instantiate(brickObj, nextCartSpam, brickObj.rotation);
        }

        nextTileSpawn.z += 50f;
        StartCoroutine(spawnTile());
    }

    public void scenenavigate(string sceneMenu){
        SceneManager.LoadScene(sceneMenu);
    }
}
