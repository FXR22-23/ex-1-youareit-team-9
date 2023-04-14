using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public Transform goal;
    public float distance = 1.5f;
  
    void Update()
    {        
        Vector3 direction = goal.position - transform.position;       
        transform.Translate(direction, Space.World);                                 
                
    }
}
