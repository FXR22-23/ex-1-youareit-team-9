using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private GameObject goal;
    public float speed = 0.01f;
    void Start(){
        goal = GameObject.FindGameObjectWithTag("Main");
    }
  
    void Update()
    {   
        Vector3 direction = goal.transform.position - transform.position;
        Vector3 pushVector = direction.normalized * speed;
        transform.Translate(pushVector, Space.World);                               
                
    }
}
