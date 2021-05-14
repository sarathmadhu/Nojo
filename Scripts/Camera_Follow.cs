using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject main_Character;
   private Vector3 offset;
    void Update()
    {
        offset = new Vector3(0f,3.5f,-3f);
        transform.position = main_Character.transform.position + offset;
    }
}
