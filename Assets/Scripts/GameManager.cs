using System.Linq;
using UnityEngine;

/// <summary>
/// Singleton game manager
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance() => _instance;
    private static GameManager _instance;

    public GameObject Player;

    public GameObject UIGame;
    public GameObject UIEndGame;
    public GameObject UIGameOver;
    public GameObject UIGameWin;

    /// <summary>
    /// Score getter
    /// </summary>
    public int Score() => score;
    private int score;
    private int timer;
    private int enemyCount;
    /// <summary>
    /// Enemy count getter
    /// </summary>
    public int Enemies() => enemyCount;

    private void Start()
    {
        if (_instance == null) _instance = this;
        else
        {
            if (_instance != this) { Destroy(gameObject); return; }
        }
        InitializeGame();
    }

    private void FixedUpdate()
    {
        timer--;
        if (timer < 1)
        {
            timer = 10;
            if (score > 0) score--;
            else GameOver(); // trigger game over when the score hits 0 (time over)
        }
    }

    /// <summary>
    /// Resets game
    /// </summary>
    private void InitializeGame()
    {
        keys = new bool[3];
        score = 999;
        timer = 10;
        enemyCount = 3;
        Time.timeScale = 1f;
        UIGame.SetActive(true);
        UIEndGame.SetActive(false);
        UIGameOver.SetActive(false);
        UIGameWin.SetActive(false);
    }

    private bool[] keys;

    /// <summary>
    /// Whether the player has collected this key
    /// </summary>
    public bool HasKey(int keyNum) => keys[keyNum];

    /// <summary>
    /// Notify that the player collected this key
    /// </summary>
    public void CollectKey(int keyNum)
    {
        keys[keyNum] = true;
    }

    /// <summary>
    /// Reduce score
    /// </summary>
    public void ReduceScore(int score)
    {
        this.score -= score;
        if (this.score <= 0) this.score = 0;
    }

    /// <summary>
    /// Notify that enemy count is reduced by 1
    /// </summary>
    public void EnemyKilled()
    {
        enemyCount--;
    }

    /// <summary>
    /// Trigger game over
    /// </summary>
    public void GameOver()
    {
        Time.timeScale = 0f;
        score -= 500; // score penalty
        if (score < 0) score = 0;
        UIGame.SetActive(false);
        UIEndGame.SetActive(true);
        UIGameOver.SetActive(true);

    }

    /// <summary>
    /// Check whether the game has met win condition
    /// </summary>
    public bool CanWin()
    {
        if (keys.Contains(false)) return false; // key collect check
        return enemyCount < 1; // enemy purge check
    }

    /// <summary>
    /// Trigger game win
    /// </summary>
    public void GameWin()
    {
        Time.timeScale = 0f;
        UIGame.SetActive(false);
        UIEndGame.SetActive(true);
        UIGameWin.SetActive(true);
    }
}
