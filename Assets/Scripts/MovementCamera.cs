using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    private Vector3 GetBaseInput()
    {
        //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }

        return p_Velocity;
    }

    void Update()
    {
        Vector3 baseInput = GetBaseInput();
        transform.position += baseInput * speed * Time.deltaTime;

        // Quaternion rotation = Quaternion.LookRotation(goalVec, Vector3.up);
        // transform.rotation = rotation;
    }
}