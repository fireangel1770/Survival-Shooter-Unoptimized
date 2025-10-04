using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    [SerializeField] HpOS playerHpVal;

    [SerializeField] EnemyPool pool;
    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Spawn ()
    {
        if(playerHpVal.currentPlayerHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        pool.SpawnEnemyAtLocation(spawnPoints[spawnPointIndex].position);
    }
}
