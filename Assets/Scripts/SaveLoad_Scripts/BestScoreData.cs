using UnityEngine;

public class BestScoreData : MonoBehaviour, ISerializableData
{
    [HideInInspector] public int BestScore;
    [HideInInspector] public float LifeTime;
    [HideInInspector] public int EnemiesKilled, WavesSurvived;
    [HideInInspector] public int WoodCollected, StoneCollected, CrystalCollected;

    private ScoreSystem _scoreSystem;

    void Awake()
    {
        _scoreSystem = GetComponent<ScoreSystem>();
    }

    public void SaveValues()
    {
        if (CompareValues())
        {
            BestScore = _scoreSystem.Score;
            LifeTime = _scoreSystem.LifeTime;
            EnemiesKilled = _scoreSystem.EnemiesKilled;
            WavesSurvived = _scoreSystem.WavesSurvived;
            WoodCollected = _scoreSystem.WoodCollected;
            StoneCollected = _scoreSystem.StoneCollected;
            CrystalCollected = _scoreSystem.CrystalCollected;
        }
    }

    public void SetValues()
    {
        PlayerPrefs.SetInt("BestScore", BestScore);
        PlayerPrefs.SetFloat("LifeTime", LifeTime);
        PlayerPrefs.SetInt("EnemiesKilled", EnemiesKilled);
        PlayerPrefs.SetInt("WavesSurvived", WavesSurvived);
        PlayerPrefs.SetInt("WoodCollected", WoodCollected);
        PlayerPrefs.SetInt("StoneCollected", StoneCollected);
        PlayerPrefs.SetInt("CrystalCollected", CrystalCollected);
    }

    public bool CompareValues()
    {
        return BestScore < _scoreSystem.Score;
    }
}
