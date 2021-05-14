using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Road_Spawner : MonoBehaviour
{
    public List<GameObject> Roads;

    private float offset = 200f;
    
    void Start()
    {
        
        if(Roads!=null && Roads.Count>0)
       {
           Roads = Roads.OrderBy(r => r.transform.position.z).ToList();
       }
        
    }

    // Update is called once per frame
    public void MoveRoad()
    {
      
        GameObject axy = Roads[0];
        Roads.Remove(axy);
        float newz = Roads[Roads.Count - 1].transform.position.z + offset;
        axy.transform.position = new Vector3(0f,0f,newz);
        Roads.Add(axy);
    }
}
