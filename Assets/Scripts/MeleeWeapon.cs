
using UnityEngine;

public class MeleeWeapon : Weapon
{
#region Variables (public)

	public string m_sAttackTriggerName = null;

	#endregion

#region Variables (private)



	#endregion


	override protected void Attack()
	{
		m_pMaster.m_pAnimator?.SetTrigger(m_sAttackTriggerName);
	}
}
