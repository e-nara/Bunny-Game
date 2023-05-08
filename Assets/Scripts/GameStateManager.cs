using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    ParticleSystem part;
    public int score;
    public bool win;

    public bool kirbyIsFriend;
    public bool kangarooIsFriend;

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
        part = GameObject.Find("Confetti").GetComponent<ParticleSystem>();
        score = 0;
        kirbyIsFriend = false;
        kangarooIsFriend = false;
        win = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(kirbyIsFriend && kangarooIsFriend){
            win = true;
        }

        if (win){
            part.Play();
        }
    }
}
