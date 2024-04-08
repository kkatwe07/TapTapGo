using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool gameStarted = false;

    [SerializeField] private GameObject platformSpawner;
    [SerializeField] private GameObject gamePlayUI;
    [SerializeField] private GameObject menuUI;

    [SerializeField] private Text highScoreText;
    [SerializeField] private Text scoreText;

    private int _score = 0;
    private int _highScore = 0;
    private bool _gameLost = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best Score : " + _highScore;

        
    }

    private void Update()
    {
        if(!gameStarted)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    private void GameStart()
    {
        _gameLost = false;
        gameStarted = true;
        platformSpawner.SetActive(true);
        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        StartCoroutine(Co_UpdateScore());
    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);
        _gameLost = true;
        StartCoroutine(Co_UpdateScore());
        SaveHighScore();
        StartCoroutine(Co_ReloadLevel());
    }

    private IEnumerator Co_ReloadLevel()
    {
        yield return new WaitForSeconds(1f);
        gameStarted = false;
        SceneManager.LoadScene("Game");
    }

    private IEnumerator Co_UpdateScore()
    {
        while(!_gameLost)
        {
            yield return new WaitForSeconds(1f);
            _score++;
            scoreText.text = _score.ToString();
        }
    }

    private void SaveHighScore()
    {
        if(_score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }
}
