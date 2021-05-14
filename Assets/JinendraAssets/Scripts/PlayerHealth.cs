using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
    public Slider staminaBar;
    public float health=100;
    public float regen = 2;
    public float currenthealth;
    public float damage = 20;
    public int medkitCount = 0;

    private void Start()
    {
        currenthealth = health;
        staminaBar.maxValue = health;
        staminaBar.value = health;
    }

    private void Update()
    {
        if (currenthealth < 100)
        {
            currenthealth += regen * Time.deltaTime;
            staminaBar.value = currenthealth;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            currenthealth = currenthealth - damage;
            staminaBar.value = currenthealth;
		}
        if (currenthealth > 0)
        {
            StartCoroutine(Wait());
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
	}
}
