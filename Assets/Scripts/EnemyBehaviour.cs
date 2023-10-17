using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int enemySpeed;

    void Start()
    {
     
    }


    void Update()
    {
        transform.Translate(Vector3.up.normalized * enemySpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
