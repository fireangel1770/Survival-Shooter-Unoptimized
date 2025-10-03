using UnityEngine;

[CreateAssetMenu(fileName = "HpOS", menuName = "Scriptable Objects/HpOS")]
public class HpOS : ScriptableObject
{

    public int StartingPlayerHealth = 100;
    public int currentPlayerHealth;

}
