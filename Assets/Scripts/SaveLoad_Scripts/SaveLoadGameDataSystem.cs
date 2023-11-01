using System.IO;

public class SaveLoadGameDataSystem : SaveLoadSystem
{
    public override void Awake()
    {
        base.Awake();

        GetComponent<WaveSystem>().OnWaveStart += Save;
        GetComponent<GameOverSystem>().OnGameOver += DeleteSaveFile;
    }
}
