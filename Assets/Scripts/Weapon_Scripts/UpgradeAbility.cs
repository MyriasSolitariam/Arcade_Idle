using System;
using UnityEngine;

public class UpgradeAbility : MonoBehaviour
{
    public RecoursesRequirementsList[] RecourseRequirements;
    public GameObject[] WeaponUpgrades;

    [Serializable]
    public class RecoursesRequirementsList
    {
        public string[] RequiredRecourses;
        public int[] RequiredRecoursesNumber;
    }
    
    [HideInInspector] public int MaxLvl;
    [HideInInspector] public int CurrentLvl = 1;
    
    [SerializeField] private PlayerInventory _playerInventory;
    
    void Awake()
    {
        MaxLvl = WeaponUpgrades.Length;
    }

    void Update()
    {
        SetCurrentLvlWeapon();
    }

    private void SetCurrentLvlWeapon()
    {
        for (int i = 0; i < WeaponUpgrades.Length; i++)
        {
            if (i == CurrentLvl - 1)
            {
                WeaponUpgrades[i].SetActive(true);
            }
            else
            {
                WeaponUpgrades[i].SetActive(false);
            }
        }
    }

    public void Upgrade()
    {
        if (UseRecourses())
        {
            CurrentLvl++;

            if (CurrentLvl > MaxLvl)
                CurrentLvl = MaxLvl;
        }
    }

    private bool UseRecourses()
    {
        bool isEnough = true;

        // iterates through all weapon's upgrades to define the current weapon
        for (int weaponNumber = 0; weaponNumber < WeaponUpgrades.Length; weaponNumber++)
        {
            if (weaponNumber == CurrentLvl - 1 && CurrentLvl != MaxLvl) // no upgrade for max lvl weapon
            {
                RecoursesRequirementsList requirements = RecourseRequirements[weaponNumber];

                // iterates through RequiredRecourses (string - recourse name), 
                // the same length as the RequiredRecoursesNumber (int - recourse number)
                for (int k = 0; k < requirements.RequiredRecourses.Length; k++)
                {
                    // does player have a recourse from requirements ? if so, how much?
                    if (_playerInventory.RecoursesStorage.TryGetValue(requirements.RequiredRecourses[k], out int recourseNumber))
                    {
                        if (recourseNumber < requirements.RequiredRecoursesNumber[k])
                        {
                            isEnough = false;
                        }
                    }
                    else
                    {
                        isEnough = false;
                    }
                }

                if (isEnough)
                {
                    for (int k = 0; k < requirements.RequiredRecourses.Length; k++)
                    {
                        _playerInventory.RecoursesStorage[requirements.RequiredRecourses[k]] -= requirements.RequiredRecoursesNumber[k];
                    }
                }

                return isEnough;
            }
        }

        return isEnough;
    }
}
