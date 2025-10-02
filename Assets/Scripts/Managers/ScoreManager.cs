using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScoreManager : MonoBehaviour
{
    public static int score;


    [SerializeField] Text text;


    void Awake ()
    {
        score = 0;
    }

    public void AddScore(int addedScore)
    {
        score += addedScore;
    }
    void Update ()
    {
        text.text = "Score: " + score;
    }
}
