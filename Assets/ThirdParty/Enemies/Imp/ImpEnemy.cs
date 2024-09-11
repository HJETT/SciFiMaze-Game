using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class ImpEnemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;

    public Transform target;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
            _agent.destination = target.position;

        _animator.SetFloat("Speed", _agent.velocity.magnitude / _agent.speed);
        _animator.SetBool("IsJumping", _agent.isOnOffMeshLink);
    }

    public void IncreaseDifficulty()
    {
        _agent.speed += 1f;
        _agent.acceleration += 1f;
    }
}