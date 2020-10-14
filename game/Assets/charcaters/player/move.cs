using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{   float speed = 6;
    float rotspeed = 80;
    float rot = 0f;
    float gravity = 8;
    float lookSpeed= 2.0f;
    float lookXLimit= 45.0f;

    public Camera playerCamera;

    Vector3 movedir = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    CharacterController controller;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
        anim = GetComponent<Animator> ();
        rotation.y = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        GetInput();
    }
    void movement()
    {
       if(controller.isGrounded)
       {
            if(Input.GetKey(KeyCode.W))
            {   if(anim.GetBool("attack") == true)
                {
                   return;        
				}
                else if(anim.GetBool("attack") == false)
                {
                    anim.SetBool("run",true);
                    anim.SetInteger("conditon", 1);
                    movedir = new Vector3(0,0,1);
                    movedir *= speed;
                    movedir = transform.TransformDirection (movedir);   
                    if(anim.GetBool("run")==true)
                    {           
                         rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
                         rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
                         rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
                         playerCamera.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
                         transform.eulerAngles = new Vector2(0, rotation.y);  
		            }
				}
			}
            if(Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("run",false);
                anim.SetInteger("conditon", 0);
                movedir = new Vector3(0,0,0);
			}
	    }
        rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0,rot,0);
        movedir.y -= gravity * Time.deltaTime;
        controller.Move(movedir * Time.deltaTime);
       
	}
    void GetInput()
    {
        if(controller.isGrounded)
        {
           if(Input.GetMouseButtonDown(0))
           {
              if(anim.GetBool("run") == true)
              {
                  anim.SetBool("run",false); 
                  anim.SetInteger("conditon",0);
			  }
              if(anim.GetBool("run") == false)
              {
                  attacking();     
			  }
		   }
		}
	}
    void attacking()
    {
        StartCoroutine(AttackRoutine());
	}
    IEnumerator AttackRoutine()
    {
        anim.SetBool("attack",true);
        anim.SetInteger("conditon",2);
        yield return new WaitForSeconds(1);
        anim.SetInteger("conditon",0);
        anim.SetBool("attack",false);
	}
}
