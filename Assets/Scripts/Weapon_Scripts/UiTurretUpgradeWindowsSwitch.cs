using UnityEngine.UI;

public class UiTurretUpgradeWindowsSwitch : UiUpgradeWindowsSwitch
{
    public override void SetUpgradeValues()
    {
        UpgradeAbility upgradeAbility = GetComponent<UpgradeAbility>();
        _upgradePanel.GetComponentInChildren<TurretUpgradeInfoView>().Upgrade = upgradeAbility;
        
        _upgradePanel.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        _upgradePanel.GetComponentInChildren<Button>().onClick.AddListener(upgradeAbility.Upgrade);
    }
}
