using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    
    private GameObject goal;
    private bool _isChasing = true;
    public float speed = 0.005f;
    void Start(){
        goal = GameObject.FindGameObjectWithTag("Main");
    }
  
    void Update()
    {
        Vector3 realGoal = new Vector3(goal.transform.position.x, transform.position.y, goal.transform.position.z);
        Vector3 direction = realGoal - transform.position;
        if (!_isChasing)
        {
            direction *= -1;
        }
        
        Debug.DrawRay(transform.position, direction, Color.green);
        
        Vector3 pushVector = direction.normalized * speed;
        transform.Translate(pushVector, Space.World);
        
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;


        if (direction.magnitude <= Constants.CatchDistance)
        {
            direction *= -1;
            _isChasing = !_isChasing;
        }
    }
}
