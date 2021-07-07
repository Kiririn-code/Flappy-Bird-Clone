using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Text _score;

    private void OnEnable()
    {
        _bird.ScoreChanged += DoScoreChanged;
    }

    private void OnDisable()
    {
        _bird.ScoreChanged -= DoScoreChanged;
    }

    private void DoScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}
