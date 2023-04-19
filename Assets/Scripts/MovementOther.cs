using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class MovementOther : MonoBehaviour
{
    [SerializeField] GameObject _goal;
    private bool _isChased = false;
    private bool _needRest = false;
    private double _currentStamina;
    private NavMeshAgent _agent;

    void Start()
    {
        
        // GameObject player = GameObject.FindGameObjectWithTag("Player");     
        // Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());

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
        CheckRunning();
        Vector3 goalVec = GetMovement();
        _agent.SetDestination(goalVec);
    }
    
    void CheckRunning()
    {
        double reducedStamina = _currentStamina - Constants.reduceStamina;

        if (_isChased)
        {
            SetNewCondition();
            return;
        }

        if (NeedForSpeed(reducedStamina))
        {
            _agent.speed = Constants.sprintSpeed;
            _currentStamina = reducedStamina;
        }
        else
        {
            SetNewCondition();
        }
    }

    private void SetNewCondition()
    {
        double increasedStamina = _currentStamina + Constants.increaseStamina;
        _currentStamina = increasedStamina;
        _needRest = true;
        _agent.speed = Constants.walkingSpeed;
        if (_currentStamina > Constants.maxStamina)
        {
            _currentStamina = Constants.maxStamina;
        }

    }

    private bool NeedForSpeed(double reducedStamina)
    {
        Vector3 distance = new(transform.position.x - _goal.transform.position.x,
            transform.position.y - _goal.transform.position.y, transform.position.z - _goal.transform.position.z);
        var norm = distance.magnitude;

        if (_currentStamina == Constants.maxStamina)
        {
            _needRest = false;
            return true;
        }
        if(norm < Constants.distanceToChase && reducedStamina >= 0)
        {
            _needRest = false;
            return true;
        }
        if (!_needRest && reducedStamina > 0)
        {
            return true;
        }
        _needRest = true;
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Main"))
        {
            _isChased = !_isChased;
        }
    }
}