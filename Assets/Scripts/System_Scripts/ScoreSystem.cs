using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [HideInInspector] public int Score;
    [HideInInspector] public float LifeTime = 0f;
    [HideInInspector] public int EnemiesKilled, WavesSurvived;
    [HideInInspector] public int WoodCollected, StoneCollected, CrystalCollected;
    
    [SerializeField] private PlayerInventory _inventory;
    
    [SerializeField] private int _enemiesKilledMultiplier, _wavesSurvivedMultiplier;
    [SerializeField] private int _woodCollectedMultiplier, _stoneCollectedMultiplier, _crystalCollectedMultiplier;
    
    private WaveSystem _waveSystem;
    
    void Awake()
    {
        _waveSystem = GetComponent<WaveSystem>();
    }
    
    void Update()
    {
        SetScoreProperties();
        CalculateScore();
    }
    
    private void SetScoreProperties()
    {
        LifeTime += Time.deltaTime;

        WavesSurvived = _waveSystem.WaveNumber - 1;
        
        WoodCollected = _inventory.TotalRecoursesStorage["Wood"];
        StoneCollected = _inventory.TotalRecoursesStorage["Stone"];
        CrystalCollected = _inventory.TotalRecoursesStorage["Crystal"];
    }
    
    private void CalculateScore()
    {
        Score = (int)LifeTime
                + WavesSurvived * _wavesSurvivedMultiplier
                + EnemiesKilled * _enemiesKilledMultiplier
                + WoodCollected * _woodCollectedMultiplier
                + StoneCollected * _stoneCollectedMultiplier
                + CrystalCollected * _crystalCollectedMultiplier;
    }

    public void IncreaseEnemiesKilledNumber()
    {
        EnemiesKilled++;
    }
}
