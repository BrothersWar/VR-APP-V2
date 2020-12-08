using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject GameOverPanel;
    public GameObject ScoreInGame;

    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            GameOverPanel.SetActive(true);
            ScoreInGame.SetActive(false);
            Time.timeScale = 0;
        }


    }
}