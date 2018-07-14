
using UnityEngine;

public class InGameHealthBar : MonoBehaviour
{
#region Variables (public)

	public Character m_pTarget = null;

	public SpriteMask m_pSpriteMask = null;

	#endregion

#region Variables (private)

	private float m_fPreviousHealth = 0.0f;

	#endregion


	private void LateUpdate()
	{
		if (m_pTarget != null)
			UpdateBar();

		FaceCamera();
	}

	private void UpdateBar()
	{
		if (m_pTarget.CurrentHealth == m_fPreviousHealth)
			return;

		m_fPreviousHealth = m_pTarget.CurrentHealth;
		m_pSpriteMask.alphaCutoff = 1.0f - (m_fPreviousHealth / m_pTarget.m_fHealth);
	}

	private void FaceCamera()
	{
		transform.forward = -PlayerCamera.Instance.transform.forward;
	}
}
