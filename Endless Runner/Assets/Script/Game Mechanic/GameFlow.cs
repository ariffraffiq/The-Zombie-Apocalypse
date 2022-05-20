using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public Transform building, truck1, truck2, dusbin, powerUP, zombie, zombie2,life, poison;
    private Vector3 nextSpawn, truck1_Spawn, truck2_Spawn, dusbin_Spawn, powerUpSpawn, zombieSpawn,zombieSpawn2, lifeSpawn, poisonSpawn;
    private int randX,randx2, randx3, randX4,randx5, randX6, randx7, randx8;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn.z = 39;
        truck1_Spawn.z = 30;
        truck2_Spawn.z = 60;
        dusbin_Spawn.z = 45;
        powerUpSpawn.z = 80;
        zombieSpawn.z = 50;
        zombieSpawn2.z = 100;
        lifeSpawn.z = 100;
        poisonSpawn.z = 50; 

       
        StartCoroutine(SpawnBuilding());
        StartCoroutine(SpawnPowerUp());
        StartCoroutine(SpawnZombie());
        StartCoroutine(SpawnZombie2());
        StartCoroutine(SpawnLife());
        StartCoroutine(SpawnPoison());


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPoison()
    {
        yield return new WaitForSeconds(1);
         randx8 = Random.Range(-16,-4);
                 poisonSpawn.y = 0;
                 poisonSpawn.x = randx8;
                Instantiate(poison, poisonSpawn, poison.rotation);
                poisonSpawn.z += 20;
                StartCoroutine (SpawnPoison());
    }

     IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(1);
         randX4 = Random.Range(-16,-4);
                 powerUpSpawn.y = 0;
                 powerUpSpawn.x = randX4;
                Instantiate(powerUP, powerUpSpawn, powerUP.rotation);
                powerUpSpawn.z += 500;
                StartCoroutine (SpawnPowerUp());
    }


    IEnumerator SpawnLife()
    {
        yield return new WaitForSeconds(1);
         randx7 = Random.Range(-16,-4);
                 lifeSpawn.y = 2;
                 lifeSpawn.x = randx7;
                Instantiate(life, lifeSpawn, life.rotation);
                lifeSpawn.z += 300;
                StartCoroutine (SpawnLife());
    }

      IEnumerator SpawnZombie()
    {
        yield return new WaitForSeconds(1);
         randx5 = Random.Range(-16,-4);
                 zombieSpawn.y = 0;
                 zombieSpawn.x = randx5;
                Instantiate(zombie, zombieSpawn, zombie.rotation);
                zombieSpawn.z += 20;
                StartCoroutine (SpawnZombie());
    }

      IEnumerator SpawnZombie2()
    {
        yield return new WaitForSeconds(1);
         randX6 = Random.Range(-16,-4);
                 zombieSpawn2.y = 0;
                 zombieSpawn2.x = randX6;
                Instantiate(zombie2, zombieSpawn2, zombie2.rotation);
                zombieSpawn2.z += 50;
                StartCoroutine (SpawnZombie2());
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
