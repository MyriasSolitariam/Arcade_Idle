using UnityEngine;

public class TurretUpgradeInfoView : UpgradeInfoView
{
    public override void WriteStatsUpgradeInfo()
    {
        if (Upgrade.CurrentLvl == 1)
        {
            GameObject nextLvlTurret = Upgrade.WeaponUpgrades[Upgrade.CurrentLvl];
            float turretDamage = nextLvlTurret.GetComponentInChildren<ShootBehaviour>().ProjectileDamage;
            
            _upgradeStatsText.text = $"Turret Damage: {turretDamage}";
        }
        else if (Upgrade.CurrentLvl != Upgrade.MaxLvl)
        {
            GameObject currentLvlTurret = Upgrade.WeaponUpgrades[Upgrade.CurrentLvl - 1];
            GameObject nextLvlTurret = Upgrade.WeaponUpgrades[Upgrade.CurrentLvl];
            
            float damageBeforeUpgrade = currentLvlTurret.GetComponentInChildren<ShootBehaviour>().ProjectileDamage;
            float damageAfterUpgrade = nextLvlTurret.GetComponentInChildren<ShootBehaviour>().ProjectileDamage;

            _upgradeStatsText.text = $"Damage: {damageBeforeUpgrade} -> {damageAfterUpgrade}";
        }
        else
        {
            GameObject currentLvlTurret = Upgrade.WeaponUpgrades[Upgrade.CurrentLvl - 1];
            
            float damage = currentLvlTurret.GetComponentInChildren<ShootBehaviour>().ProjectileDamage;
            
            _upgradeStatsText.text = $"Damage: {damage}";
        }
    }
}
