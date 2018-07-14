
using UnityEngine;
using System.Collections.Generic;

public class WeaponAttack : MonoBehaviour
{
#region Variables (public)

	public Character m_pMaster = null;

	public Collider m_pAttackCollider = null;

	public Vector2 m_tMinMaxDamage = Vector2.zero;

	#endregion

#region Variables (private)

	private List<Character> m_pTouchedCharactersThisAttack = null;

	#endregion


	private void Awake()
	{
		m_pTouchedCharactersThisAttack = new List<Character>();
	}

	public void ClearTargets()
	{
		m_pTouchedCharactersThisAttack.Clear();
	}

	virtual protected void DamageCharacter(Character pTouchedCharacter)
	{
		pTouchedCharacter.Damage(Random.Range(m_tMinMaxDamage.x, m_tMinMaxDamage.y));
		m_pTouchedCharactersThisAttack.Add(pTouchedCharacter);
	}

	virtual protected void OnTriggerEnter(Collider pOther)
	{
		Character pTouchedCharacter = pOther.GetComponent<Character>();

		if (pTouchedCharacter != null && !m_pTouchedCharactersThisAttack.Contains(pTouchedCharacter) && pTouchedCharacter.m_eFaction != m_pMaster.m_eFaction)
			DamageCharacter(pTouchedCharacter);
	}
}
