using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public EnemyStatsSO EnemyStatsSO;
    public int currentHealth;

    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    float remainingTime = 0;
    public EnemyPool pool;

    private string IsDead = "Dead";

    public UnityEvent<int> UpdateScore;

    private void OnEnable()
    {
        remainingTime = 3;
    }
    private void OnDisable()
    {
        if(pool != null)
        {
            pool.AddToQueue(this);
        }
    }
    public void SetPool(EnemyPool ep)
    {
        pool = ep;
    }
    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = EnemyStatsSO.startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * EnemyStatsSO.sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger (IsDead);

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }
    IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive (false);
    }

    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        UpdateScore?.Invoke(EnemyStatsSO.scoreValue);
        StartCoroutine(DisableEnemy());

    }
}
