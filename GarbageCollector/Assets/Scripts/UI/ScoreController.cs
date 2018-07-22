using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreField;
    private const int SCORE_INCREASE = 10; 
    private int _score;
    
    void Start()
    {
        DestroyerController.GarbageDestroyerObserver += RecalculateScore;
    }

    private void RecalculateScore(bool value)
    {
        if (value)
        {
            ChangeScore(SCORE_INCREASE);
        }
        else
        {
            ChangeScore(-SCORE_INCREASE);
        }
    }

    private void ChangeScore(int increase)
    {
        _score += increase;
        scoreField.text = _score.ToString();
    }

    public int Score
    {
        get
        {
            return _score;
        }
    }
}
