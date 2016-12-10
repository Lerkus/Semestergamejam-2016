using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
    private static GameMaster masterReferenz;
    public GameObject playerPrefab;
    public static GameObject player;

    public static GameMaster getGameMaster()
    {
        return masterReferenz;
    }

	void Awake () {
        masterReferenz = this;
	}
    void Start()
    {
    }
	
	void Update () {
	
	}
}
