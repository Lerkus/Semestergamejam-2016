using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
    private static GameMaster masterReferenz;

    public static GameMaster getGameMaster()
    {
        return masterReferenz;
    }

	void Awake () {
        masterReferenz = this;
	}
    void Start()
    {
        gameObject.GetComponent<WaveManager>().nextWave();
    }
	
	void Update () {
	
	}
}
