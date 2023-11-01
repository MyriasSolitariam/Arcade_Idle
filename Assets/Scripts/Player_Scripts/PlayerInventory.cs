using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<string, int> RecoursesStorage = new Dictionary<string, int>();
    public Dictionary<string, int> TotalRecoursesStorage = new Dictionary<string, int>();
    
    public string[] RecourseKey;
    [SerializeField] private int _startingNumberOfRecourses;
    
    void Awake()
    {
        foreach (var key in RecourseKey)
        {
            RecoursesStorage.Add(key, _startingNumberOfRecourses);
            TotalRecoursesStorage.Add(key, _startingNumberOfRecourses);
        }
    }
}
