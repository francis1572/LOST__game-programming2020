using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlWindow : MonoBehaviour
{
	public GameObject[] pauseObjects;

	// Use this for initialization
	void Start()
	{
		Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ControlObject");
		assignTask();
        hideControl();
	}

	// Update is called once per frame
	void Update()
	{

		//uses the p button to pause and unpause the game
		if (Input.GetKeyDown(KeyCode.I))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showControl();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hideControl();
			}
		}
	}

	void assignTask()
    {
		Button resumeBtn = pauseObjects[0].GetComponent<Button>();
		resumeBtn.onClick.AddListener(Resume);
		//Button reloadBtn = pauseObjects[1].GetComponent<Button>();
		//resumeBtn.onClick.AddListener(Reload);
		//Button mainMenuBtn = pauseObjects[2].GetComponent<Button>();
		//resumeBtn.onClick.AddListener(LoadLevel);
	}


	//Reloads the Level
	void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
	}

	//controls the pausing of the scene
	void Resume()
	{
		Time.timeScale = 1;
		hideControl();
	}

	//shows objects with ShowOnPause tag
	void showControl()
	{
		foreach (GameObject g in pauseObjects)
		{
			Debug.Log(g);
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	void hideControl()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	//loads inputted level
	void LoadLevel()
	{
		SceneManager.LoadScene("Main");
	}
}
