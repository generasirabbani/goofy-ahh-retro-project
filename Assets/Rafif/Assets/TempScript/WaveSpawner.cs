using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;

    }

    public Wave[] waves;

    public Transform[] spawnPoints;

    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public bool allWaveCompleted;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public TextMeshProUGUI waveText;
    public GameObject fireBallShooter1;
    public GameObject fireBallShooter2;

    private void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }

        waveCountdown = timeBetweenWaves;

        allWaveCompleted = false;
    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");
        waveText.text = "";
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            allWaveCompleted = true;
            Debug.Log("All waves completed.");
            fireBallShooter1.SetActive(false);
            fireBallShooter2.SetActive(false);
        }
        else
        {
            nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning wave: " + _wave.name);
        waveText.text = _wave.name;
        state = SpawnState.SPAWNING;

        if(nextWave == 1)
        {
            fireBallShooter1.SetActive(true);
        }
        
        if(nextWave == 2)
        {
            fireBallShooter2.SetActive(true);
        }

        for(int i=0; i<_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform[] _enemy)
    {
        Transform _enmy = _enemy[Random.Range(0, _enemy.Length)];
        Debug.Log("Spawning enemy: " + _enmy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enmy, _sp.position, _sp.rotation);
    }
}
