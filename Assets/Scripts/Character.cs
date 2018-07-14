
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
	public Rigidbody m_pRigidBody = null;

	public Weapon m_pWeapon = null;
	public EFaction m_eFaction = EFaction.BAD;

	public float m_fHealth = 0.0f;
	public float m_fSpeed = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	public void Damage(float fDamage)
	{
		print("Aouch i'm hurt for " + fDamage + " damage!");
		m_fHealth -= fDamage;
	}
}
