using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //will jump to next scene in queue.
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
