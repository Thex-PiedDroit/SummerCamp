
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

	private void Update()
	{
		if (m_pTarget != null)
		{
			if ((transform.position - m_pTarget.transform.position).sqrMagnitude > (m_pNavMeshAgent.stoppingDistance * m_pNavMeshAgent.stoppingDistance))
				FollowTarget();
			else
				AttackTarget();
		}
	}

	private void FollowTarget()
	{
		m_pNavMeshAgent.SetDestination(m_pTarget.transform.position);
	}

	private void AttackTarget()
	{
		m_pWeapon?.TryAttack();
	}
}
