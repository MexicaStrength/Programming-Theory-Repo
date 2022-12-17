using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenu : MonoBehaviour
{
    public void ReplayButton()
    {
        Debug.Log("replay");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
