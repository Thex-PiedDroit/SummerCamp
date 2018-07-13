
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
#region Variables (public)

	public Character m_pMaster = null;

	public WeaponAttack m_pWeaponAttack = null;

	[Tooltip("In attacks per second")]
	public float m_fRateOfAttack = 0.0f;

	#endregion

#region Variables (private)

	private float m_fLastAttackTime = 0.0f;

	private bool m_bAttackAnimStarted = false;
	private bool m_bIsAttacking = false;

	#endregion


	public void ActivateCollider()
	{
		m_pWeaponAttack.m_pAttackCollider.enabled = true;
	}

	public void DeactivateCollider()
	{
		m_pWeaponAttack.m_pAttackCollider.enabled = false;
		m_pWeaponAttack.ClearTargets();
	}

	public void AttackFinished()
	{
		m_bIsAttacking = false;
		m_bAttackAnimStarted = false;
	}

	private void LateUpdate()
	{
		if (m_bIsAttacking)
		{
			bool bIsAttackAnim = m_pMaster.m_pAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack");

			if (!m_bAttackAnimStarted)
				m_bAttackAnimStarted = bIsAttackAnim;
			else if (!bIsAttackAnim)
				AttackFinished();
		}
	}

	public bool IsAttacking()
	{
		return m_bIsAttacking;
	}

	public void TryAttack()
	{
		float fTimeBetweenAttacks = m_fRateOfAttack != 0.0f ? (1.0f / m_fRateOfAttack) : 0.0f;

		if (Time.time - m_fLastAttackTime < fTimeBetweenAttacks)
			return;

		Attack();
		m_bIsAttacking = true;
		m_fLastAttackTime = Time.time;
	}

	abstract protected void Attack();
}
