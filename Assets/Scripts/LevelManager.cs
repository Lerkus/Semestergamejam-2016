using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public void nextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void loadLevelByName(string name) {
		SceneManager.LoadScene (name);
	}

	public void loadLevelByIndex(int index) {
		SceneManager.LoadScene (index);
	}

	public void exit() {
		Application.Quit();
	}
}
