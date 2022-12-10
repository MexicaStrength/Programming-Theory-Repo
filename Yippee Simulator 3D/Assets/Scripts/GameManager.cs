using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    public float restartDelay = 1f;
    private int score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

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
