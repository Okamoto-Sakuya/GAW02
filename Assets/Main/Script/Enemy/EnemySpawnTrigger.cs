using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        if (spawnPoints.Length == 0) return;

        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject enemyObj = Instantiate(enemyPrefab, point.position, point.rotation);

        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}