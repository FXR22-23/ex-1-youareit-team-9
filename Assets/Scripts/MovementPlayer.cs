using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    private double currentStamina;
    private Vector3 lastDirection = Vector3.back;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentStamina = Constants.maxStamina;
    }

    private Vector3 GetBaseInput()
    {
        //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }

        checkRunning();

        return p_Velocity;
    }
    
    void Update()
    {
        Vector3 baseInput = GetBaseInput();
        transform.position += baseInput * speed * Time.deltaTime;
        if (baseInput != Vector3.zero)
        {
            anim.Play("Walking");
            lastDirection = baseInput;
        }
        else
        {
            anim.Play("Happy Idle");
        }
        transform.rotation = Quaternion.LookRotation(lastDirection, Vector3.up);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     anim.Play("Goalkeeper Catch");
    // }

    private void checkRunning()
    {
        var reducedStamina = currentStamina - Constants.reduceStamina;
        var increasedStamina = currentStamina + Constants.increaseStamina;
        if (Input.GetKey(KeyCode.LeftShift) & reducedStamina >= 0)
        {
            speed = Constants.sprintSpeed;
            currentStamina = reducedStamina;
        }
        else
        {
            currentStamina = increasedStamina;
            speed = Constants.walkingSpeed;
            if (currentStamina > Constants.maxStamina)
            {
                currentStamina = Constants.maxStamina;
            }
        }
    }
}