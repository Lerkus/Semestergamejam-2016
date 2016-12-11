using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : Stats {

    public override void die()
    {
        SceneManager.LoadScene("Scenes/Main");
    }
}
