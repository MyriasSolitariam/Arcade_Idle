using UnityEngine;

public class GameOverSystem : MonoBehaviour
{
    public delegate void GameOverCallback();
    public GameOverCallback OnGameOver;
    
    [SerializeField] private GameObject _gameOverPanel;
    
    public void SetGameOver()
    {
        OnGameOver();
        
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
