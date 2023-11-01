using UnityEngine;

public class TutorialView : MonoBehaviour
{
    [SerializeField] private GameObject[] _pages;
    [SerializeField] private GameObject _scorePanel, _buttonsPanel;
    

    public void NextPage()
    {
        for (int i = 0; i < _pages.Length; i++)
        {
            if (_pages[i].activeSelf && i != _pages.Length - 1)
            {
                _pages[i].SetActive(false);
                _pages[i + 1].SetActive(true);

                return;
            }
            else if (_pages[i].activeSelf && i == _pages.Length - 1)
            {
                ToMainMenu();
                return;
            }
        }
    }

    private void ToMainMenu()
    {
        gameObject.SetActive(false);
        _buttonsPanel.SetActive(true);
        _scorePanel.SetActive(true);
    }
}
