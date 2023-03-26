using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject gameOverUI;
	public GameObject pauseButton;

	void Awake ()
	{
		instance = this;
	}

	public void EndGame ()
	{
		gameOverUI.SetActive(true);
		pauseButton.SetActive(false);
	}

	public void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1f;
		AudioManager.instance.Play("Click");
	}

	public void ToMenu()
    {
		SceneManager.LoadScene("Menu");
		AudioManager.instance.Play("Click");
		Time.timeScale = 1f;
    }

	
}
