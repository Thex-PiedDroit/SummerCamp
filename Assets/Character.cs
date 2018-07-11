
using UnityEngine;

public class Character : MonoBehaviour
{
#region Variables (public)

	public Rigidbody m_pRigidBody = null;

	public float m_fSpeed = 0.0f;

	#endregion

#region Variables (private)



	#endregion


	private void Update()
	{
		Vector3 tMovement = new Vector3
		{
			x = Input.GetAxis("Horizontal"),
			z = Input.GetAxis("Vertical")
		};

		if (tMovement != Vector3.zero)
		{
			tMovement = PlayerCamera.Instance.transform.TransformVector(tMovement);

			m_pRigidBody.MovePosition(m_pRigidBody.position + tMovement * (m_fSpeed * Time.deltaTime));
			transform.forward = tMovement.normalized;
		}
	}
}
