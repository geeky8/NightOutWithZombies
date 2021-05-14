using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.AI;
public class NPC : MonoBehaviour
{   
    GameObject player; 
    public Transform nps;
    NavMeshAgent enemy;
    public Animator anim;
    float range = 350f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        nps = GetComponent<Transform>();
        if(player == null)
        {
           Debug.Log("Fuck");  
		}
        enemy = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Vector3.Distance(player.transform.position,nps.position) <= range)
        { 
              anim.SetBool("isIdle",false); 
              if(player != null)
              {
                  if(enemy.remainingDistance != Mathf.Infinity && enemy.remainingDistance <= enemy.stoppingDistance)
                  {
                      enemy.destination = player.transform.position;
                      anim.SetBool("isRunning",false);
                      anim.SetBool("isAttacking",true);
                  }
                  else
                  {
                      anim.SetBool("isRunning",true);
                      anim.SetBool("isAttacking",false);
                      enemy.destination = player.transform.position;  
		          }
		      }
		}
        else
        {
              anim.SetBool("isIdle",true);  
		}
     }
    
}
