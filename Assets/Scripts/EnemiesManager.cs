
using UnityEngine;
using System.Collections.Generic;

public class EnemiesManager : MonoBehaviour
{
#region Variables (public)

	static public EnemiesManager Instance = null;

	public EnemyCharacter m_pEnemyPrefab = null;

	#endregion

#region Variables (private)

	private List<EnemyCharacter> m_pAllEnemies = null;

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

		m_pAllEnemies = new List<EnemyCharacter>();
	}

	private void Update()
	{
		CatchSpawnEnemyInput();
	}

	private void CatchSpawnEnemyInput()
	{
		if (!Input.GetButtonDown("SpawnEnemy"))
			return;

		Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit tHit;

		if (Physics.Raycast(tRay, out tHit, 100.0f, LayerMask.GetMask("Set"), QueryTriggerInteraction.Ignore))
			SpawnEnemy(tHit.point);
	}

	private void SpawnEnemy(Vector3 tSpawnPosition)
	{
		EnemyCharacter pNewEnemy = Instantiate(m_pEnemyPrefab, tSpawnPosition, Quaternion.identity, transform);
		m_pAllEnemies.Add(pNewEnemy);
	}
}
