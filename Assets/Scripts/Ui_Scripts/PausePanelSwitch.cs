using UnityEngine;
using UnityEngine.InputSystem;

public class PausePanelSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject[] _nonInterruptiblePanels;
    
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            SetPausePanel();
        }
    }

    private void SetPausePanel()
    {
        foreach (var panel in _nonInterruptiblePanels)
        {
            if (panel.activeSelf) return;
        }
        
        if (!_pausePanel.activeSelf)
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
