using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    [SerializeField] private BirdMover _mover;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction GameOver;

    private int _score;
    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void Die()
    {
        _score = 0;
        GameOver?.Invoke();
        ScoreChanged?.Invoke(_score);
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void RestartBird()
    {
        _mover.RestartTransform();
    }
}
