using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUiButtonsFunctions : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private GameObject _tutorialPanel, _bestScorePanel, _buttonsPanel;

    [SerializeField] private int _levelSceneIndex;
    [SerializeField] private string _gameDataFilePath = "GameData.json";
    
    void Update()
    {
        if (File.Exists(_gameDataFilePath))
        {
            _continueButton.interactable = true;
        }
        else
        {
            _continueButton.interactable = false;
        }
    }
    
    public void OnNewGame()
    {
        File.Delete(_gameDataFilePath);
        SceneManager.LoadScene(_levelSceneIndex);
        Time.timeScale = 1f;
    }

    public void OnContinueGame()
    {
        SceneManager.LoadScene(_levelSceneIndex);
        Time.timeScale = 1f;
    }

    public void OnTutorial()
    {
        _bestScorePanel.SetActive(false);
        _buttonsPanel.SetActive(false);
        
        _tutorialPanel.SetActive(true);
    }
    
    public void OnExit()
    {
        Application.Quit();
    }
}
