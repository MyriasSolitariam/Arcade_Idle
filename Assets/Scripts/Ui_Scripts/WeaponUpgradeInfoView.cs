using UnityEngine;

public class WeaponUpgradeInfoView : UpgradeInfoView
{
    public override void WriteStatsUpgradeInfo()
    {
        if (Upgrade.CurrentLvl != Upgrade.MaxLvl)
        {
            GameObject currentLvlWeapon = Upgrade.WeaponUpgrades[Upgrade.CurrentLvl - 1];
            GameObject nextLvlWeapon = Upgrade.WeaponUpgrades[Upgrade.CurrentLvl];
            
            float damageBeforeUpgrade = currentLvlWeapon.GetComponent<HitAction>().Damage;
            float damageAfterUpgrade = nextLvlWeapon.GetComponent<HitAction>().Damage;

            _upgradeStatsText.text = $"Damage: {damageBeforeUpgrade} -> {damageAfterUpgrade}";
        }
        else
        {
            GameObject currentLvlWeapon = Upgrade.WeaponUpgrades[Upgrade.CurrentLvl - 1];
            
            float damage = currentLvlWeapon.GetComponent<HitAction>().Damage;
            
            _upgradeStatsText.text = $"Damage: {damage}";
        }
    }
}
