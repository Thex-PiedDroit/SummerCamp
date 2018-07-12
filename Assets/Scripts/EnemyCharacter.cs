
using UnityEngine;
using UnityEngine.AI;

public class EnemyCharacter : Character
{
#region Variables (public)

	public NavMeshAgent m_pNavMeshAgent = null;

	#endregion

#region Variables (private)



	#endregion


	private void Start()
	{
		m_pNavMeshAgent.speed = m_fSpeed;
	}
}
