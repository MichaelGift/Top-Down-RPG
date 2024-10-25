using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
    }

    private EnemyPathFinding pathFinding;
    private State currentState;
    [SerializeField] private float waitTime = 2f;

    private void Awake()
    {
        pathFinding = GetComponent<EnemyPathFinding>();
        currentState = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (currentState == State.Roaming)
        {
            Vector2 randomPosition = GetRandomPosition();
            pathFinding.MoveTo(randomPosition);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private Vector2 GetRandomPosition()
    {
        return new Vector2(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f)).normalized;
    }
}
