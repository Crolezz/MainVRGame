using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNCloseDoor : MonoBehaviour
{
    Animator anim;
    bool closed = true;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O) && closed == true)
        {
            anim.SetBool("Closed", false);
            anim.SetBool("Opened",true);
            closed = false;
        }
        else if (Input.GetKeyDown(KeyCode.O) && closed == false)
        {
            anim.SetBool("Opened", false);
            anim.SetBool("Closed", true);
            closed = true;
        }
    }
}
