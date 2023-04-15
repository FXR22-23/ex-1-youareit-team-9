using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Movment : MonoBehaviour
{
    [SerializeField] GameObject _goal;
    private bool _isChased = false;
    private double _currentStamina;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = Constants.walkingSpeed;
        _currentStamina = Constants.maxStamina;
    }

    Vector3 GetMovement()
    {
        if (_isChased)
        {
            return 2 * transform.position - _goal.transform.position;
        }

        return _goal.transform.position;
    }

    void Update()
    {
        Debug.Log(_agent.speed);
        Debug.Log(_currentStamina);
        Debug.Log("----------");
        CheckRunning();
        Vector3 goalVec = GetMovement();
        _agent.SetDestination(goalVec);
    }

    void CheckRunning()
    {
        double reducedStamina = _currentStamina - Constants.reduceStamina;
        double increasedStamina = _currentStamina + Constants.increasedStamina;
        if (Input.GetKey(KeyCode.LeftShift) && reducedStamina >= 0)
        {
            _agent.speed = Constants.sprintSpeed;
            _currentStamina = reducedStamina;
        }
        else
        {
            _currentStamina = increasedStamina;
            _agent.speed = Constants.walkingSpeed;
            if (_currentStamina > Constants.maxStamina)
            {
                _currentStamina = Constants.maxStamina;
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