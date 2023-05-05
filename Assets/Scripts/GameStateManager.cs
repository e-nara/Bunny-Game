using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    public int score;

    public int getScore()
    {
        return score;
    }

    public void SetScore(int s)
    {
        score = s;
    }

    public void adjustScore(int s)
    {
        score += s;
        Debug.Log("Score is " + score); //no longer needed; handled by UI
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
