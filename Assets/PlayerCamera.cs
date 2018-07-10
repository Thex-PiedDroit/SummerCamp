
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
#region Variables (public)

	public Transform m_pTarget = null;

	public float m_fFollowDistance = 0.0f;

	#endregion

#region Variables (private)

	private Vector3 m_tLastTargetPosition = Vector3.zero;

	#endregion


	private void LateUpdate()
	{
		if (m_pTarget != null && m_pTarget.position != m_tLastTargetPosition)
			FollowTarget();
	}

	private void FollowTarget()
	{
		transform.position = m_pTarget.position - (transform.forward * m_fFollowDistance);
		m_tLastTargetPosition = m_pTarget.position;
	}
}
