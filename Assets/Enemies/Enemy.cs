using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Script moving an enemy
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected Animator _animator;

    /// <summary>
    /// Current target of this enemy
    /// </summary>
    public Transform target;

    protected int difficulty = 0;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public void IncreaseDifficulty(int amount) => difficulty = amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerDeath();
        }
    }
}