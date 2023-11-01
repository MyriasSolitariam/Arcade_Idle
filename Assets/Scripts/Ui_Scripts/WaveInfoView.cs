using System;
using UnityEngine;
using UnityEngine.UI;

public class WaveInfoView : MonoBehaviour
{
    [SerializeField] private WaveSystem _waveSystem;

    [SerializeField] private Text _waveNumberText, _waveCountdownText, _waveEnemiesLeftText;

    void Update()
    {
        _waveNumberText.text = _waveSystem.WaveNumber.ToString();
        _waveCountdownText.text = TimeSpan.FromSeconds(_waveSystem.Countdown).ToString("mm':'ss");
        _waveEnemiesLeftText.text = _waveSystem.EnemiesLeft.ToString();
    }
}
