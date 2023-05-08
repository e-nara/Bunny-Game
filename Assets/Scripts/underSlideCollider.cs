using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underSlideCollider : MonoBehaviour
{

    private GameStateManager gsm;
    public bool underSlideEntered;

    // Start is called before the first frame update
    void Start()
    {
        gsm = GameObject.Find("GameState").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            underSlideEntered = true;
        }
    }
}