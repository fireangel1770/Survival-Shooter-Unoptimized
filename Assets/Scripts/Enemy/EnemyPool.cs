using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyPool : MonoBehaviour
{
    [SerializeField] EnemyHealth enemyPrefab;
    [SerializeField] int enemyAmount;

    Queue<EnemyHealth> remainingEnemies = new Queue<EnemyHealth>();

    // Start is called once
    void Awake()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            var b = Instantiate(enemyPrefab);
            b.SetPool(this);
            b.gameObject.SetActive(false);
        }
    }
    public void SpawnEnemyAtLocation(Vector3 location)
    {
        if (remainingEnemies.Count > 0)
        {
            var current = remainingEnemies.Dequeue();
            current.gameObject.SetActive(true);
            current.transform.position = location;
        }
    }

    public void AddToQueue(EnemyHealth enemy)
    {
        remainingEnemies.Enqueue(enemy);
    }


}
