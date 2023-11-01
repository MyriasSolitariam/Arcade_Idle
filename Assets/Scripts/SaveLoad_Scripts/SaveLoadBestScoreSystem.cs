using System.IO;

public class SaveLoadBestScoreSystem : SaveLoadSystem
{
    public override void Awake()
    {
        GetComponent<GameOverSystem>().OnGameOver += Save;

        base.Awake();
    }

    public override void Save()
    {
        base.Save();
        
        Load();
    }
}
