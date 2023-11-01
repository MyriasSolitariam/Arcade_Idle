using System;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public delegate void WaveStartCallback();
    public WaveStartCallback OnWaveStart;
    
    public EnemySpawn EnemySpawn;
    
    public float WaveCountdownTime;
    public int EnemiesNumberIncreasePerWave;
    [HideInInspector] public float Countdown = 0f;
    [HideInInspector] public int WaveNumber = 1;
    [HideInInspector] public int EnemiesLeft;

    private int _waveEnemiesNumber;
    private int _currentState;

    private const int WaveCountdownState = 0;
    private const int WaveAttackState = 1;

    void Awake()
    {
        Countdown = WaveCountdownTime;
        _currentState = WaveCountdownState;
    }

    void Update()
    {
        _waveEnemiesNumber = WaveNumber * EnemiesNumberIncreasePerWave;
        SetWaveState();
    }

    private void SetWaveState()
    {
        switch (_currentState)
        {
            case WaveCountdownState:
                Countdown -= Time.deltaTime;

                if (Countdown <= 0f)
                {
                    SpawnEnemies();
                    Countdown = 0f;
                    _currentState = WaveAttackState;
                }
                break;

            case WaveAttackState:
                EnemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;

                if (EnemiesLeft <= 0)
                {
                    WaveNumber++;
                    RespawnRecourses();
                    Countdown = WaveCountdownTime;
                    _currentState = WaveCountdownState;

                    OnWaveStart();
                }
                break;
        }
    }
    
    void SpawnEnemies()
    {
        EnemySpawn.Spawn(_waveEnemiesNumber);
    }

    void RespawnRecourses()
    {
        GameObject[] recourseSpawners = GameObject.FindGameObjectsWithTag("RecourseSpawner");

        foreach (var spawner in recourseSpawners)
        {
            RecourseSpawn recourseSpawn = spawner.GetComponent<RecourseSpawn>();
            recourseSpawn.Spawn();
        }
    }
}
