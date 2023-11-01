using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BestScorePropertiesView : MonoBehaviour
{
    [SerializeField] private Text _lifeTimeText, _wavesSurvivedText, _enemiesKilledText;
    [SerializeField] private Text _woodNumberText, _stoneNumberText, _crystalNumberText;
    [SerializeField] private Text _totalScoreText;

    [SerializeField] private string _bestScorePath = "BestScore.json";
    
    void Update()
    {
        if (!File.Exists(_bestScorePath)) PlayerPrefs.DeleteAll();

        if (PlayerPrefs.HasKey("BestScore"))
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            return;
        }

        FillTextFields();
    }

    private void FillTextFields()
    {
        _lifeTimeText.text = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("LifeTime")).ToString("hh':'mm':'ss");
        _wavesSurvivedText.text = PlayerPrefs.GetInt("WavesSurvived").ToString();
        _enemiesKilledText.text = PlayerPrefs.GetInt("EnemiesKilled").ToString();
        _woodNumberText.text = PlayerPrefs.GetInt("WoodCollected").ToString();
        _stoneNumberText.text = PlayerPrefs.GetInt("StoneCollected").ToString();
        _crystalNumberText.text = PlayerPrefs.GetInt("CrystalCollected").ToString();
        _totalScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
