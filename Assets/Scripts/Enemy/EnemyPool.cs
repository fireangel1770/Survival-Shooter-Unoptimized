using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyPool : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] int enemyAmount;

    Queue<EnemyMovement> remainingEnemies = new Queue<EnemyMovement>();

    // Start is called once
    void Start()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            var b = Instantiate(enemyPrefab);
            b.SetPool(this);
            b.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
