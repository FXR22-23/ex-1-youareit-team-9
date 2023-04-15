using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Movment : MonoBehaviour
{
    [SerializeField] GameObject _goal;
    private bool _isChased = false;
    private double currentStamina;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = Constants.walkingSpeed;
        currentStamina = Constants.maxStamina;
    }

    Vector3 GetMovement()
    {
        Vector3 goalVec = new Vector3(_goal.transform.position.x, transform.position.y, _goal.transform.position.z);
        Vector3 path = goalVec - transform.position;
        Debug.DrawRay(transform.position, path, Color.red);

        // Vector3 pushVector = path.normalized * speed;
        Vector3 pushVector = path;
        if (_isChased)
        {
            pushVector *= -1;
        }

        return pushVector;
    }

    void Update()
    {
        Debug.Log(_agent.speed);
        Debug.Log(currentStamina);
        Debug.Log("----------");
        CheckRunning();
        Vector3 goalVec = GetMovement();
        _agent.SetDestination(goalVec);

        Quaternion rotation = Quaternion.LookRotation(goalVec, Vector3.up);
        transform.rotation = rotation;
    }

    void CheckRunning()
    {
        double reducedStamina = currentStamina - Constants.reduceStamina;
        double incresedStamina = currentStamina + Constants.increasedStamina;
        if (Input.GetKey(KeyCode.LeftShift) && reducedStamina >= 0)
        {
            _agent.speed = Constants.sprintSpeed;
            currentStamina = reducedStamina;
        }
        else
        {
            currentStamina = incresedStamina;
            _agent.speed = Constants.walkingSpeed;
            if(currentStamina > Constants.maxStamina)
            {
                currentStamina = Constants.maxStamina;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Main"))
        {
            _isChased = true;
        }
    }
}