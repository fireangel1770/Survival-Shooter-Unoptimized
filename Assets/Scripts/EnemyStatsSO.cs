using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatsSO", menuName = "Scriptable Objects/EnemyStatsSO")]
public class EnemyStatsSO : ScriptableObject
{
    //Enemy HP Vals
    public int startingHealth = 100;
 

    //Score Vals
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;

    //Attacking Vals
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
}
