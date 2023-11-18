using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        private enum State
        {
            Roaming
        }

        private State _state;
        private EnemyPathfinder _enemyPathfinder;

        private void Awake()
        {
            _enemyPathfinder = GetComponent<EnemyPathfinder>();
            _state = State.Roaming;
        }

        private void Start()
        {
            StartCoroutine(RoamingRoutine());
        }

        private IEnumerator RoamingRoutine()
        {
            while (_state == State.Roaming)
            {
                var pos = GetRoamingPosition();
                _enemyPathfinder.SetMovementVector(pos);
                
                yield return new WaitForSeconds(2f);
            }
        }

        private Vector2 GetRoamingPosition()
        {
            return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
    }
}
