
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
#region Variables (public)

	public Character m_pMaster = null;

	[Tooltip("In attacks per second")]
	public float m_fRateOfAttack = 0.0f;

	#endregion

#region Variables (private)

	private float m_fLastAttackTime = 0.0f;

	#endregion


	public void TryAttack()
	{
		float fTimeBetweenAttacks = m_fRateOfAttack != 0.0f ? (1.0f / m_fRateOfAttack) : 0.0f;

		if (Time.time - m_fLastAttackTime < fTimeBetweenAttacks)
			return;

		Attack();
		m_fLastAttackTime = Time.time;
	}

	abstract protected void Attack();
}
