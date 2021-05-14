using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Over")
        {
            SceneManager.LoadScene(3);
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
