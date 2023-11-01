using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecourseSpawn : MonoBehaviour
{
    public RecoursesList[] RecoursesLists;
    
    [Serializable]
    public class RecoursesList
    {
        public GameObject[] Recourse;
    }
    
    public float[] RecourseSpawnChance;

    public GameObject SpawnedObject;

    void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (SpawnedObject != null) return;
        SpawnedObject = Instantiate(ChooseRecourseToSpawn(), transform.position, Quaternion.identity);
    }

    private GameObject ChooseRecourseToSpawn()
    {
        RecoursesList recourseType;
        GameObject recourseToSpawn;

        recourseType = RecoursesLists[ChooseRecourseType()];
        recourseToSpawn = recourseType.Recourse[Random.Range(0, recourseType.Recourse.Length)];

        return recourseToSpawn;
    }

    private int ChooseRecourseType()
    {
        float totalRand = 0;

        for (int i = 0; i < RecourseSpawnChance.Length; i++)
        {
            totalRand += RecourseSpawnChance[i];
        }

        float randVal = Random.Range(0, totalRand);

        for (int i = 0; i < RecourseSpawnChance.Length; i++)
        {
            if (randVal < RecourseSpawnChance[i])
            {
                return i;
            }
            randVal -= RecourseSpawnChance[i];
        }

        return -1;
    }
}
