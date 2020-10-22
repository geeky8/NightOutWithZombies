using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial : MonoBehaviour
{   float speed = 4;
    float gravity = 8;
    
    public Camera playerCamera;

    Vector3 movedir = Vector3.zero;
    

    CharacterController controller;

    public static Trial instance;
 
    private void Awake()
    {
        instance = this;
	}
    
    void Start()
    {
        controller = GetComponent<CharacterController> ();
        Pb.BarValue = 100;
    }

    void Update()
    {
        movement();
    }
    void movement()
    {
       if(controller.isGrounded)
       {
            if(Input.GetKey(KeyCode.W))
            { 
                    movedir = new Vector3(0,0,1);
                    movedir *= speed;
                    movedir = transform.TransformDirection (movedir);
                    Stamina.instance.UseStamina(5);
                    Debug.Log(movedir);
			}
            if(Input.GetKeyUp(KeyCode.W))
            {
                //anim.SetBool("run",false);
                //anim.SetInteger("conditon", 0);
                movedir = new Vector3(0,0,0);
			}
	    }
        //rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0,rot,0);
        movedir.y -= gravity * Time.deltaTime;
        controller.Move(movedir * Time.deltaTime);  
	}
    public void LessStamina()
    {
        movedir = new Vector3(0,0,1);
        movedir *= (speed /2);
        movedir = transform.TransformDirection (movedir);
        Debug.Log(movedir);
	}

    public GameObject BloodEffect;
    
    public ProgressBar Pb;
    public float damage = 5f;
    private float MinHealth;
    public float Delay = 10f;

    //private void Start()
    //{
        //Pb.BarValue = 100;
    //}

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            BloodEffect.SetActive(true);
            StartCoroutine(SetFalse());
            Pb.BarValue -= damage;
            MinHealth = Pb.BarValue;
            Debug.Log(MinHealth);

            if(MinHealth == 0)
            {
                Debug.Log("GameOver");    
			}
		}
    }

    IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(Delay);
        BloodEffect.SetActive(false);
	}
}