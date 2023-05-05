using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class NPC : MonoBehaviour {

    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

    void Start () {
        dialogueSystem = FindObjectOfType<DialogueSystem>(); //find the dialogueSystem
    }
	
	void Update () {
          Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position); //chatbackground position
          Pos.y += 175; //make it above the character
          ChatBackGround.position = Pos; //set position
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true; //call our script and enable it
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F)) //if player enters the action key - F
        {
            this.gameObject.GetComponent<NPC>().enabled = true; //enable script (make everything active)
            dialogueSystem.Names = Name; //the name in the dialogueSystem is the name of the NPC
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName(); //set the name (function from dialoguesystem script)
        }
    }

    public void OnTriggerExit()
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false; //turn script off once out of range
    }
}