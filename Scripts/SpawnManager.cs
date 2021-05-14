using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Road_Spawner roadSpawner;
    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GetComponent<Road_Spawner>();
        
    }

    // Update is called once per frame
    public void enteredATrigger()
    {
        roadSpawner.MoveRoad();
    }
}
