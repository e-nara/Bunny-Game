using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameStateManager : MonoBehaviour
{

    ParticleSystem part;
    public int score;
    public bool win;

    public GameObject WinScreen;

    public GameObject kirbyTick;
    public GameObject kangarooTick;
    public GameObject teddyDogTick;
    public GameObject hattieTick;
    public GameObject giraffeTick;
    public GameObject scruffyTick;

    public bool kirbyIsFriend;
    public bool kangarooIsFriend;
    public bool teddyDogIsFriend;
    public bool hattieIsFriend;
    public bool giraffeIsFriend;
    public bool scruffyIsFriend;

    public bool hattieTalkedTo; //store in the gsm to pass between NPCs
    public bool teddyDogTalkedTo;
    public bool kirbyTalkedTo;
    public bool kangarooTalkedTo; 
    //only stored for quest-giving npcs
    //doesnt apply to characters who you can befriend through dialogue alone
    //this is to avoid 

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
        //Debug.Log("Score is " + score); //no longer needed; handled by UI
    }


    // Start is called before the first frame update
    void Start()
    {
        part = GameObject.Find("Confetti").GetComponent<ParticleSystem>();
        score = 0;
        kirbyIsFriend = false;
        kangarooIsFriend = false;
        teddyDogIsFriend = false;
        hattieIsFriend = false;
        giraffeIsFriend = false;
        scruffyIsFriend = false;

        win = false;

        hattieTalkedTo = false;
        teddyDogTalkedTo = false;
        kirbyTalkedTo = false;
        kangarooTalkedTo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(giraffeIsFriend){
            giraffeTick.SetActive(true);
        }
        if(kirbyIsFriend){
            kirbyTick.SetActive(true);
        }
        if(kangarooIsFriend){
            kangarooTick.SetActive(true);
        }
        if(scruffyIsFriend){
            scruffyTick.SetActive(true);
        }
        if(teddyDogIsFriend){
            teddyDogTick.SetActive(true);
        }
        if(hattieIsFriend){
            hattieTick.SetActive(true);
        }

        if(kirbyIsFriend && kangarooIsFriend && giraffeIsFriend && teddyDogIsFriend && hattieIsFriend && scruffyIsFriend){
            win = true;
        }

        if (win){
            WinScreen.SetActive(true);
            part.Play();
        }
    }
}
