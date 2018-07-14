
public class MeleeWeapon : Weapon
{
#region Variables (public)



	#endregion

#region Variables (private)



	#endregion


	override protected void Attack()
	{
		m_pMaster.m_pAnimator?.SetTrigger(m_sAttackTriggerName);
	}
}
