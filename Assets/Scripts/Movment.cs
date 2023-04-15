using UnityEngine;
using UnityEngine.AI;

public class Movment : MonoBehaviour
{
    [SerializeField] GameObject _goal;
    private bool _isChased = false;
    private float speed = 0.01f;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
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
        Vector3 testvec = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Left Shift key is pressed!");
            Debug.DrawLine(transform.position, testvec, Color.red);
        }
        Vector3 goalVec = GetMovement();
        _agent.SetDestination(goalVec);

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