
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharacter : Character
{
#region Variables (public)

	public NavMeshAgent m_pNavMeshAgent = null;

	public float m_fDistanceToTargetToAttack = 0.0f;

	#endregion

#region Variables (private)

	private Character m_pTarget = null;

	#endregion


	private void Start()
	{
		m_pNavMeshAgent.speed = m_fSpeed;
		m_pNavMeshAgent.stoppingDistance = m_fDistanceToTargetToAttack + (m_pNavMeshAgent.radius * 2.0f);

		m_pTarget = PlayerCharacter.Instance;
	}

	private bool IsAttacking()
	{
		return m_pWeapon.IsAttacking();
	}

	private bool HasReachedDestination()
	{
		return (transform.position - m_pTarget.transform.position).sqrMagnitude <= (m_pNavMeshAgent.stoppingDistance * m_pNavMeshAgent.stoppingDistance);
	}

	protected override void LaunchDeathAnim()
	{
		base.LaunchDeathAnim();
		m_pNavMeshAgent.enabled = false;
	}

	private void Update()
	{
		if (IsDead)
			return;

		if (m_pTarget != null && !m_pTarget.IsDead)
		{
			if (!HasReachedDestination())
				FollowTarget();
			else
				AttackTarget();
		}
	}

	private void LateUpdate()
	{
		m_pAnimator.SetBool("Moving", !HasReachedDestination());
	}

	private void FollowTarget()
	{
		m_pNavMeshAgent.SetDestination(m_pTarget.transform.position);
	}

	private void AttackTarget()
	{
		transform.LookAt(m_pTarget.transform, Vector3.up);
		m_pNavMeshAgent.SetDestination(transform.position);
		if (!IsAttacking())
			m_pWeapon.TryAttack();
	}
}
