using System;
using UnityEngine;
using UnityEngine.UI;

public class ScorePropertiesView : MonoBehaviour
{
    [SerializeField] private Text _lifeTimeText, _wavesSurvivedText, _enemiesKilledText;
    [SerializeField] private Text _woodNumberText, _stoneNumberText, _crystalNumberText;
    
    [SerializeField] private ScoreSystem _scoreSystem;
    
    void Update()
    {
        _lifeTimeText.text = TimeSpan.FromSeconds(_scoreSystem.LifeTime).ToString("hh':'mm':'ss");
        _wavesSurvivedText.text = _scoreSystem.WavesSurvived.ToString();
        _enemiesKilledText.text = _scoreSystem.EnemiesKilled.ToString();
        _woodNumberText.text = _scoreSystem.WoodCollected.ToString();
        _stoneNumberText.text = _scoreSystem.StoneCollected.ToString();
        _crystalNumberText.text = _scoreSystem.CrystalCollected.ToString();
    }
}
