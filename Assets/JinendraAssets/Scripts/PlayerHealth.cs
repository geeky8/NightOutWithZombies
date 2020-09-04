using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
    public GameObject BloodEffect;
    
    public ProgressBar Pb;
    public float damage = 5f;
    private float MinHealth;
    public float Delay = 10f;

    private void Start()
    {
        Pb.BarValue = 100;
    }

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
