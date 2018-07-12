
using UnityEngine;

public class Projectile : WeaponAttack
{
#region Variables (public)

	public float m_fSpeed = 0.0f;
	public float m_fMaxDistance = 0.0f;

	#endregion

#region Variables (private)

	private Vector3 m_tStartPos = Vector3.zero;

	#endregion


	private void Start()
	{
		m_tStartPos = transform.position;
	}

	private void Update()
	{
		MoveForward();
	}

	private void MoveForward()
	{
		transform.position += transform.forward * (m_fSpeed * Time.deltaTime);

		if ((transform.position - m_tStartPos).sqrMagnitude >= (m_fMaxDistance * m_fMaxDistance))
			DestroyProjectile();
	}

	override protected void DamageCharacter(Character pTouchedCharacter)
	{
		base.DamageCharacter(pTouchedCharacter);
		DestroyProjectile();
	}

	private void DestroyProjectile()
	{
		Destroy(gameObject);
	}

	override protected void OnTriggerEnter(Collider pOther)
	{
		base.OnTriggerEnter(pOther);

		if (pOther.GetComponent<Character>() == null)
			DestroyProjectile();
	}
}
