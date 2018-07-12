
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
#region Variables (public)



	#endregion

#region Variables (private)



	#endregion


	public void LaunchGame(string sSceneName)
	{
		SceneManager.LoadScene(sSceneName, LoadSceneMode.Single);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
