using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy1, enemy2;
    private float randomX;
    private float randomY;
    private float time = 1f;
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
            randomX = Random.Range(16, 18);
            randomY = Random.Range(8, -8);
            Vector3 enemySpawn = new Vector3(randomX, randomY, 0);
            Instantiate(enemy1, enemySpawn, transform.rotation);
            time = 1.5f;
        }
    }   private void SpawnEnemy2()
    {
       
        time -= Time.deltaTime;
        if (time <= 0)
        {
            randomX = Random.Range(16, 18);
            randomY = Random.Range(3, -8);
            Vector3 enemySpawn = new Vector3(randomX, randomY, 0);
            Instantiate(enemy2, enemySpawn, Quaternion.identity);
            time = 1.5f;
        }
    }
}
