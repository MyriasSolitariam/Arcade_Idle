using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _enemyTargets;
    
    public float TimeDelayBetweenSpawns;

    public void Spawn(int numberOfEnemies)
    {
        StartCoroutine(SpawnEnemies(numberOfEnemies));
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        MoveBehaviour moveBehaviour = enemy.GetComponent<MoveBehaviour>();
        moveBehaviour.DefaultTarget = _enemyTargets[Random.Range(0, _enemyTargets.Length)];
    }
    
    private IEnumerator SpawnEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(TimeDelayBetweenSpawns);
        }
    }
}
