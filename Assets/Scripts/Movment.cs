using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private GameObject goal;
    private bool _isChased = false;
    public float speed = 0.005f;

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