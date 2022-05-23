using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
	public void onClick(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
