using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    
    // Start is called before the first frame update
    private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
    
    void Update()
    {
        Vector3 baseInput = GetBaseInput();
        Vector3 goalVec = transform.position + baseInput * speed;
        transform.Translate(goalVec, Space.World);

        // Quaternion rotation = Quaternion.LookRotation(goalVec, Vector3.up);
        // transform.rotation = rotation;
    }
}
