
using UnityEngine;

abstract public class Character : MonoBehaviour
{
#region Variables (public)

	public enum EFaction
	{
		GOOD,
		BAD
	}

	public Animator m_pAnimator = null;

	public Weapon m_pWeapon = null;
	public EFaction m_eFaction = EFaction.BAD;

	public float m_fHealth = 0.0f;
	public float m_fSpeed = 0.0f;

	#endregion

#region Variables (private)

	public bool IsDead { get; private set; } = false;

	#endregion


	public void Damage(float fDamage)
	{
		print("Aouch i'm hurt for " + fDamage + " damage!");
		m_fHealth -= fDamage;

		if (m_fHealth <= 0.0f)
			LaunchDeathAnim();
	}

	virtual protected void LaunchDeathAnim()
	{
		if (m_pAnimator != null)
			m_pAnimator.SetBool("Dead", true);
		IsDead = true;
		m_fHealth = 0.0f;
	}

	virtual public void KillCharacter()
	{
		Destroy(gameObject);
	}
}
