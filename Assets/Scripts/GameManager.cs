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

    private void Start()
    {
        if (_instance == null) _instance = this;
        else
        {
            if (_instance != this) { Destroy(gameObject); return; }
        }
        InitializeGame();
    }

    private void Update()
    {

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

    public void GameOver()
    {
        Time.timeScale = 0f;
        UIGame.SetActive(false);
        UIEndGame.SetActive(true);
        UIGameOver.SetActive(true);

    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        UIGame.SetActive(false);
        UIEndGame.SetActive(true);
        UIGameWin.SetActive(true);
    }
}
