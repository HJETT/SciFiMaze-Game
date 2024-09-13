public class ImpEnemy : Enemy
{
    private void Start()
    {
        _agent.speed += 1f * difficulty;
        _agent.acceleration += 1f * difficulty;
    }

    void Update()
    {
        if (target != null)
            _agent.destination = target.position;

        _animator.SetFloat("Speed", _agent.velocity.magnitude / _agent.speed);
        _animator.SetBool("IsJumping", _agent.isOnOffMeshLink);
    }
}
