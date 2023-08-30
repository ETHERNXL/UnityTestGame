using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPause : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameMenuUI;
    public Text killed;
    public static int kills;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        gameMenuUI.SetActive(false);
        Time.timeScale = 0f; // Pause the game by setting the time scale to 0
        isPaused = true;
        Debug.Log("Game paused");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        killed.text = "KILLED : " + kills;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        gameMenuUI.SetActive(true);
        Time.timeScale = 1f; // Resume the game by setting the time scale back to 1
        isPaused = false;
        Debug.Log("Game resumed");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void RestartGame()
    {
        Debug.Log("Restarting");
        gameMenuUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        isPaused = false;
        PlayerHealthDisplay.health = 100;
        PlayerUltimate.currentPower = 50;
        kills = 0;
}
    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
