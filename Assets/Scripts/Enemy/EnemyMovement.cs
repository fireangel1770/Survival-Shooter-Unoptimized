using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    void Update ()
    {
        if (GetComponent<EnemyHealth>().currentHealth > 0 && player.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            GetComponent<NavMeshAgent>().SetDestination (player.position);
        }
        else
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
