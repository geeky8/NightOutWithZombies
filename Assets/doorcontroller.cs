using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorcontroller : MonoBehaviour
{
    public GameObject instructions;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {

            Animator anim = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.E))
                anim.SetBool("opendoor", true);
            else if (Input.GetKeyDown(KeyCode.T))
                anim.SetBool("opendoor", false);
        }
    }
}
