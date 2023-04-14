using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private GameObject other;
    public float distance = 1.5f;
    void Start(){
        other = GameObject.FindGameObjectWithTag("Main");
    }
  
    void Update()
    {   
        Vector3 direction = other.position - transform.position;       
        transform.Translate(direction, Space.World);                                 
                
    }
}
