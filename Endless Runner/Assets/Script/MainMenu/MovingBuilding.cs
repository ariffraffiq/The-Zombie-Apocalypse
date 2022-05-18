using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBuilding : MonoBehaviour
{
    public Transform building;
    private Vector3 nextSpawn;
    

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn.z = 39;
       
        StartCoroutine(SpawnBuilding());
        
    }

  
    IEnumerator SpawnBuilding()
    {
        yield return new WaitForSeconds(1);
       
        //spawn building
        Instantiate(building, nextSpawn, building.rotation);
        nextSpawn.z += 39; 
       
        StartCoroutine (SpawnBuilding());
    }
}
