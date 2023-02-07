using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance() => _instance;
    private static GameManager _instance;

    public GameObject Player;

    public GameObject UIGame;
    public GameObject UIEndGame;
    public GameObject UIGameOver;
    public GameObject UIGameWin;

    public int Score() => score;
    private int score;
    private int timer;
    private int enemyCount;
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
        }
    }

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

    public bool HasKey(int keyNum) => keys[keyNum];

    public void CollectKey(int keyNum)
    {
        keys[keyNum] = true;
    }

    public void ReduceScore(int score)
    {
        this.score -= score;
        if (this.score <= 0) { this.score = 0; GameOver(); }
    }

    public void EnemyKilled()
    {
        enemyCount--;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        score -= 500; // score penalty
        if (score < 0) score = 0;
        UIGame.SetActive(false);
        UIEndGame.SetActive(true);
        UIGameOver.SetActive(true);

    }

    public bool CanWin()
    {
        if (keys.Contains(false)) return false; // key collect check
        return enemyCount < 1; // enemy purge check
    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        UIGame.SetActive(false);
        UIEndGame.SetActive(true);
        UIGameWin.SetActive(true);
    }
}
