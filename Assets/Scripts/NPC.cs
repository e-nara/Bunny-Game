using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour {

    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    private GameStateManager gsm;

    public string Name;

    public int score; //for kirby collection
    public bool underSlideEntered;

    [TextArea(5, 10)]
    public string[] sentences;
    public string[] sentencesConditional;

    public bool questCompleted;

    void Start () {
        gsm = GameObject.Find("GameState").GetComponent<GameStateManager>();
        dialogueSystem = FindObjectOfType<DialogueSystem>(); //find the dialogueSystem
        questCompleted = false;
    }
	
	void Update () {
          Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position); //chatbackground position
          Pos.y += 175; //make it above the character
          ChatBackGround.position = Pos; //set position

          score = gsm.score; //pass the score from gsm to here
          underSlideEntered = GameObject.Find("UnderSlideTrigger").GetComponent<underSlideCollider>().underSlideEntered;

          

    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true; //call our script and enable it
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F)) //if player enters the action key - F
        {
            this.gameObject.GetComponent<NPC>().enabled = true; //enable script (make everything active)
            
            //code that handles quest state
            if(this.gameObject.tag == "Heart Kirby"){
                // Heart Kirby's Quest requires a collection minigame
                if(score >= 5) {
                    questCompleted = true;
                    gsm.kirbyIsFriend = true;
                }
            }
            
            if (this.gameObject.tag == "Kangaroo") {
                if(underSlideEntered){
                    questCompleted = true;
                    gsm.kangarooIsFriend = true;
                }
            }

            dialogueSystem.Names = Name; //the name in the dialogueSystem is the name of the NPC

            //assign the right dialogue based on condition
            if (questCompleted){
                dialogueSystem.dialogueLines = sentencesConditional; //sentences if the quest is completed
                
            } else {
                dialogueSystem.dialogueLines = sentences; //default dialogue
            }
            

            FindObjectOfType<DialogueSystem>().NPCName(); //set the name (function from dialoguesystem script)
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false; //turn script off once out of range
    }
}