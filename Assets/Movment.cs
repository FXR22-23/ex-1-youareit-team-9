using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private GameObject other;
    public float speed = 0.01f;
    void Start(){
        other = GameObject.FindGameObjectWithTag("Main");
    }
  
    void Update()
    {   
        Vector3 direction = other.transform.position - transform.position;       
        transform.position = direction * speed * Time.deltaTime;                                
                
    }
}
