using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData : MonoBehaviour, ISerializableData
{
    [HideInInspector] public string[] RecoursesKeys;
    [HideInInspector] public List<int> RecoursesStorageValues = new List<int>();
    [HideInInspector] public List<int> TotalRecoursesStorageValues = new List<int>();
    [HideInInspector] public List<int> UpgradesLvl = new List<int>();
    [HideInInspector] public float PlayerCurrentHp, BaseCurrentHp;
    [HideInInspector] public int EnemiesKilled, WaveNumber;
    [HideInInspector] public float LifeTimeTimer;

    private List<UpgradeAbility> _upgrades = new List<UpgradeAbility>();
    private GameObject _player;
    private PlayerInventory _inventory;
    private HealthProperty _playerHealth;
    private HealthProperty _baseHealth;
    
    private ScoreSystem _scoreSystem;
    private WaveSystem _waveSystem;

    void Awake()
    {
        _scoreSystem = GetComponent<ScoreSystem>();
        _waveSystem = GetComponent<WaveSystem>();

        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");
        
        Array.Sort(turrets, CompareObjNames);
        Array.Sort(weapons, CompareObjNames);
        
        foreach (var turret in turrets)
        {
            _upgrades.Add(turret.GetComponent<UpgradeAbility>());
        }
        foreach (var weapon in weapons)
        {
            _upgrades.Add(weapon.GetComponent<UpgradeAbility>());
        }
        
        _baseHealth = GameObject.FindGameObjectWithTag("Base").GetComponent<HealthProperty>();

        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = _player.GetComponent<HealthProperty>();
        _inventory = _player.GetComponent<PlayerInventory>();
    }
    
    public void SaveValues()
    {
        UpgradesLvl.Clear();
        RecoursesStorageValues.Clear();
        TotalRecoursesStorageValues.Clear();
        
        for (int i = 0; i < _upgrades.Count; i++)
        {
            UpgradesLvl.Add(_upgrades[i].CurrentLvl);
        }
        
        RecoursesKeys = _inventory.RecourseKey;

        for (int i = 0; i < RecoursesKeys.Length; i++)
        {
            RecoursesStorageValues.Add(_inventory.RecoursesStorage[RecoursesKeys[i]]);
            TotalRecoursesStorageValues.Add(_inventory.TotalRecoursesStorage[RecoursesKeys[i]]);
        }
        
        PlayerCurrentHp = _playerHealth.CurrentHealth;
        BaseCurrentHp = _baseHealth.CurrentHealth;

        LifeTimeTimer = _scoreSystem.LifeTime;
        EnemiesKilled = _scoreSystem.EnemiesKilled;
        WaveNumber = _waveSystem.WaveNumber;
    }

    public void SetValues()
    {
        for (int i = 0; i < _upgrades.Count; i++)
        {
            _upgrades[i].CurrentLvl = UpgradesLvl[i];
        }
        
        for (int i = 0; i < RecoursesKeys.Length; i++)
        {
            _inventory.RecoursesStorage[RecoursesKeys[i]] = RecoursesStorageValues[i];
            _inventory.TotalRecoursesStorage[RecoursesKeys[i]] = TotalRecoursesStorageValues[i];
        }
        
        _playerHealth.CurrentHealth = PlayerCurrentHp;
        _baseHealth.CurrentHealth = BaseCurrentHp;
        
        _scoreSystem.LifeTime = LifeTimeTimer;
        _scoreSystem.EnemiesKilled = EnemiesKilled;
        _waveSystem.WaveNumber = WaveNumber;
    }
    
    int CompareObjNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }
}
