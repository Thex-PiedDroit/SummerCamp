
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
#region Variables (public)

	public Character m_pTarget = null;

	public Image m_pFill = null;

	#endregion

#region Variables (private)

	private float m_fPreviousHealth = 0.0f;

	#endregion


	private void LateUpdate()
	{
		if (m_pTarget != null)
			UpdateBar();
	}

	private void UpdateBar()
	{
		if (m_pTarget.CurrentHealth == m_fPreviousHealth)
			return;

		m_fPreviousHealth = m_pTarget.CurrentHealth;
		m_pFill.fillAmount = m_fPreviousHealth / m_pTarget.m_fHealth;
	}
}
