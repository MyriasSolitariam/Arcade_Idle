using UnityEngine;
using UnityEngine.UI;


public class HpBarView : MonoBehaviour
{
    [SerializeField] private HealthProperty _hpObject;
    
    private Image _hpBarImage;
    
    void Awake()
    {
        _hpBarImage = GetComponent<Image>();
    }

    void Update()
    {
        _hpBarImage.fillAmount = _hpObject.CurrentHealth / _hpObject.Health;
    }
}
