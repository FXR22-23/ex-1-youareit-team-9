using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private GameObject goal;
    public float speed = 0.005f;
    void Start(){
        goal = GameObject.FindGameObjectWithTag("Main");
    }
  
    void Update()
    {
        Vector3 realGoal = new Vector3(goal.transform.position.x, transform.position.y, goal.transform.position.z);
        Vector3 direction = realGoal - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
        Debug.DrawRay(transform.position, direction, Color.green);
        
        Vector3 pushVector = direction.normalized * speed;
        transform.Translate(pushVector, Space.World);                               
                
    }
}
