using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn_Controller : MonoBehaviour
{
    public GameObject enemyPrefab;
    int _maxEnemiesSpawns = 1;
    int _maxLimit = 10;

    List<GameObject> _poolEnemys = new List<GameObject>();


    private void Start()
    {
        StartPoolSpanw();
        StartCoroutine(SpawnWave());
    }

    void StartPoolSpanw()
    {
        for(int i = 0; i < _maxLimit; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform);
            enemy.SetActive(false);
            _poolEnemys.Add(enemy);
        }
    }

    IEnumerator SpawnWave()
    {
        while (_maxEnemiesSpawns <= _maxLimit)
        {
            // activar enemigos de la oleada actual
            int spawned = 0;
            foreach (GameObject enemy in _poolEnemys)
            {
                if (!enemy.activeInHierarchy && spawned < _maxEnemiesSpawns)
                {
                    enemy.transform.position = new Vector3(
                        Random.Range(-9.5f, 9.5f),
                        transform.position.y,
                        Random.Range(-9.5f, 9.5f)
                    );
                    enemy.SetActive(true);
                    spawned++;
                }
            }

            // esperar hasta que todos los enemigos de la oleada estén muertos/desactivados
            yield return new WaitUntil(() => AllEnemiesDefeated());

            // aumentar oleada
            _maxEnemiesSpawns++;

            if (_maxEnemiesSpawns > _maxLimit)
            {
                Debug.Log("¡Victoria! Todas las oleadas completadas.");
                // aquí podrías disparar un evento de win, cargar escena, etc.
                yield break;
            }
        }
    }

    bool AllEnemiesDefeated()
    {
        foreach (GameObject enemy in _poolEnemys)
        {
            if (enemy.activeInHierarchy) return false;
        }
        return true;
    }



    /*
    GameObject GetEnemy()
    {
        foreach(GameObject enemy in _poolEnemys)
        {
            if(!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null;
    }

    void SpawnEnemy()
    {
        GameObject enemy = GetEnemy();
        if(enemy != null)
        {
            enemy.transform.position = new Vector3(
                Random.Range(-9.5f,9.5f), 
                transform.position.y, 
                Random.Range(-9.5f,9.5f)
                );
            enemy.SetActive(true);
        }
    }
    */
}
