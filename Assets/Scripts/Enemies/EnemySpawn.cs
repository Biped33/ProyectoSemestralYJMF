using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    float time = 1f;
    public float randomX;
    public float randomY;
    void Start()
    {
    }
    void Update()
    {
        SpawnEnemy1();
        SpawnEnemy2();
    }
    private void SpawnEnemy1()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            randomX = Random.Range(12, 15);
            randomY = Random.Range(-4, 4);
            Vector3 enemySpawn = new Vector3(randomX, randomY, 0);
            Instantiate(enemy1, enemySpawn, transform.rotation);
            time = 1f;
        }
    }
    private void SpawnEnemy2()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            randomX = Random.Range(12, 15);
            randomY = Random.Range(-4, 4);
            Vector3 enemySpawn = new Vector3(randomX, randomY, 0);
            Instantiate(enemy1, enemySpawn, transform.rotation);
            time = 1f;
        }
    }



}
