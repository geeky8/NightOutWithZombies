using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Slider staminaBar;

    private float maxStamina = 100;
    private float currentStamina;

    private Coroutine regen;

    public static Stamina instance;

    public GameObject gasping;

    private void Awake()
    {
        instance = this;
	}
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if(currentStamina >= 0)
        {
            currentStamina -= amount * Time.deltaTime;
            staminaBar.value = currentStamina;

            if(regen != null)
            {
                StopCoroutine(regen);     
			}

            regen = StartCoroutine(RegenStamina());
		}
        else
        {
            Trial.instance.LessStamina();
            Debug.Log("No Stamina");  
		}
	}

    void Update()
    {
        if(currentStamina <= 30)
        {
            gasping.SetActive(true);
		}
        else
        {
            gasping.SetActive(false);
        }
	}

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += (maxStamina / 300);
            staminaBar.value = currentStamina;
            yield return new WaitForSeconds(0.1f);
		}
        regen = null;
	}
}
