using UnityEngine;
using UnityEngine.UI;

public class RecoursesView : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    
    [SerializeField] private string _recourseKey;

    private Text _recoursesNumberText;
    private int _recoursesNumber;

    void Awake()
    {
        _recoursesNumberText = GetComponent<Text>();
    }

    void Update()
    {
        if (_playerInventory.RecoursesStorage.TryGetValue(_recourseKey, out _recoursesNumber))
            _recoursesNumberText.text = _recoursesNumber.ToString();
    }
}
