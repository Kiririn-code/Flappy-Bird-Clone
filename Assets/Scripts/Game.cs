using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _generator;
    [SerializeField] private StartScreen _start;
    [SerializeField] private RestartScreen _restart;

    private void OnEnable()
    {
        _start.PlayButtonClick += OnPlayButtonClick;
        _restart.RestartButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _start.PlayButtonClick -= OnPlayButtonClick;
        _restart.RestartButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _start.Open();
    }

    private void OnPlayButtonClick()
    {
        _start.Close();
        RestartGame();
    }

    private void OnRestartButtonClick()
    {
        _restart.Close();
        _generator.ResetPool();
        RestartGame();
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        _bird.RestartBird();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _restart.Open();
    }
}
