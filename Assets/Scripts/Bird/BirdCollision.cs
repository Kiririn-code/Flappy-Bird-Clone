using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Bird))]
public class BirdCollision : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone zone))
            _bird.AddScore();
        else
            _bird.Die();
    }
}
