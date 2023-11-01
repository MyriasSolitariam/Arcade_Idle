using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUiButtonFunctions : MonoBehaviour
{
    [SerializeField] private int _mainMenuSceneIndex = 0;
    [SerializeField] private string _saveFilePath = "GameData.json";
    
    
    public void OnContinue(GameObject pausePanel)
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void OnRepeat()
    {
        if (File.Exists(_saveFilePath))
        {
            File.Delete(_saveFilePath);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    
    public void OnMainMenu()
    {
        SceneManager.LoadScene(_mainMenuSceneIndex);
    }
}
