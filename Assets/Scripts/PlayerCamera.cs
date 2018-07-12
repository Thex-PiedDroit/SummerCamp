
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
#region Variables (public)

	static public PlayerCamera Instance = null;

	public Transform m_pTarget = null;

	public float m_fFollowDistance = 0.0f;

	[Tooltip("In degrees per second")]
	public float m_fYRotationSpeed = 0.0f;

	#endregion

#region Variables (private)

	private Vector3 m_tLastTargetPosition = Vector3.zero;

	#endregion


	private void Awake()
	{
		if (Instance != null)
		{
			if (this != Instance)
			{
				Destroy(gameObject);
				Debug.LogError("Two instances of singleton class " + GetType() + " exist. Second instance has been destroyed.");
			}

			return;
		}

		Instance = this;
	}

	private void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void LateUpdate()
	{
		CatchCameraRotationInput();

		if (m_pTarget != null && m_pTarget.position != m_tLastTargetPosition)
			FollowTarget();
	}

	private void CatchCameraRotationInput()
	{
		float fYRotation = Input.GetAxis("Mouse X");
		if (fYRotation != 0.0f)
			transform.localEulerAngles += new Vector3(0.0f, fYRotation * m_fYRotationSpeed, 0.0f) * Time.deltaTime;
	}

	private void FollowTarget()
	{
		transform.position = m_pTarget.position;
		m_tLastTargetPosition = m_pTarget.position;
	}
}
