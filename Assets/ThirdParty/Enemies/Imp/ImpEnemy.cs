using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ImpEnemy : MonoBehaviour
{
    private NavMeshAgent _agent;

    public Transform target;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _agent.destination = target.position;
    }
}
