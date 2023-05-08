using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class controlPlayerVFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            Debug.Log("Shift Pressed");
        }else if(Input.GetKeyUp(KeyCode.LeftShift)){
            Debug.Log("Shift Released");
        }
    }
}
