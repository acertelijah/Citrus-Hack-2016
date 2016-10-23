using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour 
{
	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
