using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] public EnemyStatsSO EnemyStatsSO;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    private string playerDead = "PlayerDead";

    [SerializeField] HpOS HpVal;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= EnemyStatsSO.timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }

        if(HpVal.currentPlayerHealth <= 0)
        {
            anim.SetTrigger (playerDead);
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(HpVal.currentPlayerHealth > 0)
        {
            playerHealth.TakeDamage (EnemyStatsSO.attackDamage);
        }
    }
}
