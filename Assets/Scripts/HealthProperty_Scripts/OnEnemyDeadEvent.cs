using UnityEngine;

public class OnEnemyDeadEvent : OnDeadEvent
{
    void Awake()
    {
        _health = GetComponent<HealthProperty>();
        
        GameObject systems = GameObject.FindGameObjectWithTag("Systems");
        ScoreSystem scoreSystem = systems.GetComponent<ScoreSystem>();
        
        OnDead += scoreSystem.IncreaseEnemiesKilledNumber;
    }
}
