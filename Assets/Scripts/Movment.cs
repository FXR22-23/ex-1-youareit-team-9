using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private GameObject goal;
    private bool _isChased = false;
    private float speed = 0.01f;

    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Main");
    }

    Vector3 GetMovement()
    {
        Vector3 goalVec = new Vector3(goal.transform.position.x, transform.position.y, goal.transform.position.z);
        Vector3 path = goalVec - transform.position;
        Debug.DrawRay(transform.position, path, Color.green);

        Vector3 pushVector = path.normalized * speed;
        if (_isChased)
        {
            pushVector *= -1;
        }

        return pushVector;
    }

    void Update()
    {
        Vector3 testvec = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Left Shift key is pressed!");
            Debug.DrawLine(transform.position, testvec, Color.red);
        }
        Vector3 goalVec = GetMovement();
        transform.Translate(goalVec, Space.World);

        Quaternion rotation = Quaternion.LookRotation(goalVec, Vector3.up);
        transform.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Main"))
        {
            _isChased = true;
        }
    }
}