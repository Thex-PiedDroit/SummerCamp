
using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character
{
#region Variables (public)

	static public PlayerCharacter Instance = null;

	public Rigidbody m_pRigidBody = null;

	#endregion

#region Variables (private)



	#endregion


	override protected void Awake()
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

		base.Awake();
	}

	private void Update()
	{
		if (IsDead)
			return;

		CatchMoveInput();
		CatchShootInput();
	}

	private void CatchMoveInput()
	{
		Vector3 tMovement = new Vector3
		{
			x = Input.GetAxis("Horizontal"),
			z = Input.GetAxis("Vertical")
		};

		bool bMoving = tMovement != Vector3.zero;
		m_pAnimator.SetBool("Moving", bMoving);

		if (!bMoving)
			return;

		tMovement = PlayerCamera.Instance.transform.TransformVector(tMovement);

		m_pRigidBody.MovePosition(m_pRigidBody.position + tMovement * (m_fSpeed * Time.deltaTime));
		transform.forward = tMovement.normalized;
	}

	private void CatchShootInput()
	{
		if (Input.GetButton("Shoot"))
			m_pWeapon?.TryAttack();
	}

	override public void KillCharacter()
	{
		StartCoroutine(WaitBeforeRespawn());
	}

	private IEnumerator WaitBeforeRespawn()
	{
		float fStartTime = Time.time;
		while (Time.time - fStartTime < 2.0f)
			yield return false;

		Respawn(Vector3.zero);
	}
}
