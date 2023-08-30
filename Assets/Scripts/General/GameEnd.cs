using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {

    public GameObject continueButton;
    private PlayerPause playerPause;
    // Use this for initialization
    void Start () {
        playerPause = FindObjectOfType<PlayerPause>();
    }
	
	// Update is called once per frame
	void Update () {
		if(PlayerHealthDisplay.health <= 0)
        {
            continueButton.SetActive(false);
            playerPause.PauseGame();
        }
	}
}
