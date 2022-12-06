using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    public float restartDelay = 1f;
    public void EndGame()
    {
        if (gameOver == false)
        {
            gameOver = true;
            Debug.Log("wah");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
