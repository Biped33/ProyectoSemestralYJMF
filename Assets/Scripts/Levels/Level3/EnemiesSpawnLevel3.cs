using UnityEngine;

public class EnemiesSpawnLevel3 : MonoBehaviour
{
    public GameObject enemy1, enemy2, enemy3, enemy4;
    private float randomX;
    private float randomY;
    private float time1 = 1f, time2 = 1f, time3 = 5f, time4 = 10f;

    void Update()
    {
        SpawnEnemy1();
        SpawnEnemy2();
        SpawnEnemy3();
        SpawnEnemy4();
    }

    private void SpawnEnemy1()
    {

        time1 -= Time.deltaTime;
        if (time1 <= 0)
        {
            randomX = Random.Range(16, 18);
            randomY = Random.Range(8, -8);
            Vector3 enemySpawn = new Vector3(randomX, randomY, 0);
            Instantiate(enemy1, enemySpawn, transform.rotation);
            time1 = 1.5f;
        }
    }

    private void SpawnEnemy2()
    {
        time2 -= Time.deltaTime;
        if (time2 <= 0)
        {
            randomX = Random.Range(16, 18);
            randomY = Random.Range(8, -8);
            Vector3 enemySpawn = new Vector3(randomX, randomY, 0);
            Instantiate(enemy2, enemySpawn, transform.rotation);
            time2 = 1.5f;
        }
    }

    private void SpawnEnemy3()
    {
        time3 -= Time.deltaTime;
        if (time3 <= 0)
        {
            randomX = Random.Range(16, 18);
            randomY = Random.Range(8, -8);
            Vector3 enemySpawn = new Vector3(randomX, randomY, 0);
            Instantiate(enemy3, enemySpawn, Quaternion.identity);
            time3 = 2f;
        }
    }

    private void SpawnEnemy4()
    {
        time4 -= Time.deltaTime;
        if (time4 <= 0)
        {
            randomX = Random.Range(14, 16);
            randomY = Random.Range(8, -8);
            Vector3 enemySpawn = new Vector3(randomX, randomY, 0);
            Instantiate(enemy4, enemySpawn, Quaternion.identity);
            time4 = 10f;
        }
    }
}
