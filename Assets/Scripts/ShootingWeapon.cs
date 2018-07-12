
using UnityEngine;

public class ShootingWeapon : Weapon
{
#region Variables (public)

	public Projectile m_pProjectilePrefab = null;
	public Transform m_pShootOrigin = null;

	#endregion

#region Variables (private)



	#endregion


	override protected void Attack()
	{
		Projectile pNewProjectile = Instantiate(m_pProjectilePrefab, m_pShootOrigin.position, m_pShootOrigin.rotation);
		pNewProjectile.m_pMaster = m_pMaster;
	}
}
