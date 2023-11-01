using UnityEngine;

public class OnPlayerDeadEvent : OnDeadEvent
{
    void Awake()
    {
        _health = GetComponent<HealthProperty>();
        
        GameObject systems = GameObject.FindGameObjectWithTag("Systems");
        GameOverSystem gameOverSystem = systems.GetComponent<GameOverSystem>();
        
        OnDead += gameOverSystem.SetGameOver;
    }
}
