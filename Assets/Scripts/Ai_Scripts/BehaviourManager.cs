using System.Collections.Generic;
using UnityEngine;

public class BehaviourManager : MonoBehaviour
{
    public List<MonoBehaviour> Behaviours;

    public IBehaviour ActiveBehaviour;
    
    void Update()
    {
        EvaluateActiveBehaviour();
        UseActiveBehaviour();
    }

    void EvaluateActiveBehaviour()
    {
        float highScore = float.MinValue;
        
        foreach (var item in Behaviours)
        {
            if (item is IBehaviour behaviour)
            {
                float currentScore = behaviour.Evaluate();

                if (currentScore > highScore)
                {
                    highScore = currentScore;
                    ActiveBehaviour = behaviour;
                }
            }
        }
    }

    void UseActiveBehaviour()
    {
        ActiveBehaviour?.Behave();
    }
}
