using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
    private static GameMaster masterReferenz;
    public GameObject playerPrefab;
    public static GameObject player;
	private Canvas canvas;

    public static GameMaster getGameMaster()
    {
        return masterReferenz;
    }

	void Awake () {
        masterReferenz = this;
	}
    void Start()
    {
<<<<<<< HEAD
		canvas = (Canvas) Object.FindObjectOfType<Canvas> ();
=======
		//canvas = GameObject.Find ("Canvas");
>>>>>>> 9b15fa910e80020fd60b9a9d184a9770acd5c9d1
    }
	
	void Update () {
	
	}

	public void Resume() {
		canvas.transform.GetChild (0).gameObject.SetActive (false);
		canvas.transform.GetChild (1).gameObject.SetActive (false);
		canvas.transform.GetChild (2).gameObject.SetActive (false);
		canvas.transform.GetChild (3).gameObject.SetActive (false);
		Time.timeScale = 1f;
	}
}
