using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform building, truck1, truck2, dusbin, powerUP;
    private Vector3 nextSpawn, truck1_Spawn, truck2_Spawn, dusbin_Spawn, powerUpSpawn;
    private int randX,randx2, randx3, randX4;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn.z = 39;
        truck1_Spawn.z = 30;
        truck2_Spawn.z = 60;
        dusbin_Spawn.z = 45;
        powerUpSpawn.z = 80;

       
        StartCoroutine(SpawnBuilding());
        StartCoroutine(SpawnPowerUp());


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(1);
         randX4 = Random.Range(-16,-4);
                 powerUpSpawn.y = 2;
                 powerUpSpawn.x = randX4;
                 //spawn building
                Instantiate(powerUP, powerUpSpawn, powerUP.rotation);
                powerUpSpawn.z += 500;
                StartCoroutine (SpawnPowerUp());
    }

    IEnumerator SpawnBuilding()
    {
        yield return new WaitForSeconds(1);
        randX = Random.Range(-13,-6);
        
        //truck1_Spawn = nextSpawn;
        truck1_Spawn.y = 0;
        truck1_Spawn.x = randX;

        //spawn building
        Instantiate(building, nextSpawn, building.rotation);
        nextSpawn.z += 39;
        
        //spawn Truck1
        Instantiate(truck1, truck1_Spawn, truck1.rotation);
        truck1_Spawn.z += 60;


        yield return new WaitForSeconds(1);
        randx2 = Random.Range(-13,-6);

        //spawn building
        Instantiate(building, nextSpawn, building.rotation);
        nextSpawn.z += 39;

        //truck2_Spawn = nextSpawn;
        truck2_Spawn.y = 0;
        truck2_Spawn.x = randx2;

        //spawn Truck2
        Instantiate(truck2, truck2_Spawn, truck2.rotation);
        truck2_Spawn.z += 60;


        yield return new WaitForSeconds(1);
        randx3 = Random.Range(-3,-16);

        //spawn building
        Instantiate(building, nextSpawn, building.rotation);
        nextSpawn.z += 39;

        //truck2_Spawn = nextSpawn;
        dusbin_Spawn.y = 0;
        dusbin_Spawn.x = randx3;

        //spawn Truck2
        Instantiate(dusbin, dusbin_Spawn, dusbin.rotation);
        dusbin_Spawn.z += 60;


        StartCoroutine (SpawnBuilding());

    }
}
