using UnityEngine;
using UnityEngine.UI;

public class TotalScoreView : MonoBehaviour
{
    [SerializeField] private ScoreSystem _scoreSystem;
    
    private Text _scoreText;
    
    void Awake()
    {
        _scoreText = GetComponent<Text>();    
    }

    void Update()
    {
        _scoreText.text = _scoreSystem.Score.ToString();
    }
}
