﻿
using UnityEngine;

public class PlayerCharacter : Character
{
#region Variables (public)



	#endregion

#region Variables (private)



	#endregion


	private void Update()
	{
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

		if (tMovement == Vector3.zero)
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
}