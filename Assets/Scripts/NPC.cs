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
            /*
          Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position); //chatbackground position
          Pos.y += 100; //make it above the character
          ChatBackGround.position = Pos; //set position
          */

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
                gsm.kirbyTalkedTo = true;
                if(score >= 5) { //Collect all other art kirbys to complete teddys quest
                    questCompleted = true;
                    gsm.kirbyIsFriend = true;
                }
            }
            
            if (this.gameObject.tag == "Kangaroo") {
                gsm.kangarooTalkedTo = true;
                if(underSlideEntered){ //go under the slide to complete teddys quest
                    questCompleted = true;
                    gsm.kangarooIsFriend = true;
                }
            }

            
            if (this.gameObject.tag == "Hat Girl") {
                if (gsm.teddyDogTalkedTo){
                    gsm.hattieTalkedTo = true; //true if you talk to her at least once after talking to teddydog;
                }
                if(gsm.teddyDogIsFriend){
                    questCompleted = true; //she will be friends with you if you're friends with teddy dog
                    gsm.hattieIsFriend = true;
                }
            }

            
            if (this.gameObject.tag == "Teddy Dog") {
                gsm.teddyDogTalkedTo = true;
                if (gsm.hattieTalkedTo){ //talk to hattie to complete teddys quest
                    questCompleted = true;
                    gsm.teddyDogIsFriend = true;
                }
            }

            if (this.gameObject.tag == "Giraffe") {
                gsm.giraffeIsFriend = true;
            }

            if (this.gameObject.tag == "Scruffy Dog") {
                gsm.scruffyIsFriend = true;
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