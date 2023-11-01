using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradeInfoView : MonoBehaviour
{
    public UpgradeAbility Upgrade;
    [SerializeField] protected Text _upgradeStatsText;
    [SerializeField] protected Text[] _recourseRequirementsText;

    void Update()
    {
        WriteStatsUpgradeInfo();
        WriteRecourseRequirementsInfo();
    }

    public virtual void WriteStatsUpgradeInfo() { }

    public virtual void WriteRecourseRequirementsInfo()
    {
        if (Upgrade.CurrentLvl != Upgrade.MaxLvl)
        {
            for (int i = 0; i < Upgrade.RecourseRequirements[Upgrade.CurrentLvl - 1].RequiredRecoursesNumber.Length; i++)
            {
                _recourseRequirementsText[i].text = Upgrade.RecourseRequirements[Upgrade.CurrentLvl - 1].RequiredRecoursesNumber[i].ToString();
            }
        }
        else
        {
            for (int i = 0; i < _recourseRequirementsText.Length; i++)
            {
                _recourseRequirementsText[i].text = "x";
            }
        }
    }
}
