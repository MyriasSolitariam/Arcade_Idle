using UnityEngine;

public class UiUpgradeWindowsSwitch : MonoBehaviour
{
    [SerializeField] protected GameObject _upgradePanel, _buttonHint;
    [SerializeField] protected PlayerControlsInputs _input;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _buttonHint.SetActive(true);

            if (_input.InteractInput > 0f)
            {
                SetUpgradeValues();
                
                _upgradePanel.SetActive(true);
            }
        }
    }
    
    public virtual void SetUpgradeValues() { }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseUpgradePanel();
        }
    }

    public void CloseUpgradePanel()
    {
        _upgradePanel.SetActive(false);
        _buttonHint.SetActive(false);
    }
}
