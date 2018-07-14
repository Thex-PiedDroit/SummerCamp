
using System;
using UnityEngine;

abstract public class Character : MonoBehaviour
{
#region Variables (public)

	public enum EFaction
	{
		GOOD,
		BAD
	}

	public Action<Character> OnDeath = null;
	public Action<Character> OnRespawn = null;

	public Animator m_pAnimator = null;

	public Weapon m_pWeapon = null;
	public EFaction m_eFaction = EFaction.BAD;

	public float m_fHealth = 0.0f;
	public float m_fSpeed = 0.0f;

	#endregion

#region Variables (private)

	public float CurrentHealth { get; private set; } = 0.0f;

	public bool IsDead { get; private set; } = false;

	#endregion


	virtual protected void Awake()
	{
		CurrentHealth = m_fHealth;
	}

	public void Damage(float fDamage)
	{
		print("Aouch i'm hurt for " + fDamage + " damage!");
		CurrentHealth -= fDamage;

		if (CurrentHealth <= 0.0f)
			LaunchDeathAnim();
	}

	virtual protected void LaunchDeathAnim()
	{
		if (m_pAnimator != null)
			m_pAnimator.SetBool("Dead", true);
		IsDead = true;
		CurrentHealth = 0.0f;

		OnDeath?.Invoke(this);
	}

	virtual public void KillCharacter()
	{
		Destroy(gameObject);
	}

	protected void Respawn(Vector3 tPos)
	{
		transform.position = tPos;
		if (m_pAnimator != null)
			m_pAnimator.SetBool("Dead", false);

		CurrentHealth = m_fHealth;
		IsDead = false;

		OnRespawn?.Invoke(this);
	}
}
