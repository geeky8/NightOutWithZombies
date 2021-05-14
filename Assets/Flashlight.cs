using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public TextMeshProUGUI text;
    //Flashlight Object
    public Light flashlight;
    //Flashlight power variables
    public float power = 100.0f;
    private float maxPower = 100.0f;
    private float minPower = 0.0f;
    //Battery charge variable
    private float batteryCharge = 100.0f;
    //Number of batteries currently possesed by the player
    public int batteryCount = 0;
    //Power Drain controls how fast the battery life decreases
    public float powerDrain = 1.0f;
    //Boolean that tells whether or not the flashlight is able to be used based off of current power
    private bool usable = true;
    public Slider BatteryBar;
    public float currentbat;

    void Start()
    {
        currentbat = power;
        BatteryBar.maxValue = power;
        BatteryBar.value = power;
    }
    void Update()
    {
        //If the F key is pressed and the power is greater than zero, then the flashlight will toggle between on and off
        if (Input.GetKeyDown(KeyCode.F) && usable)
        {
            flashlight.enabled = !flashlight.enabled;
        }
        //While the flashlight is off, the power will drain
        if (flashlight.enabled)
        {
            power -= Time.deltaTime * powerDrain;
            currentbat = power;
            BatteryBar.value = currentbat;
        }
        //This is to ensure that the power will never go over 100
        if (power > maxPower)
        {
            power = maxPower;
        }
        //This is to disable to flashlight and make sure it can't be used until the player uses a battery to recharge the flashlight
        if (power < minPower)
        {
            power = minPower;
            flashlight.enabled = false;
            usable = false;
        }
        //After you replace the batteries, it allows you to use the flashlight again
        if (power > minPower)
        {
            usable = true;
        }
        //This says that if the player has at least one battery, and if they press R, then the flashlight will be fully charged
        if (Input.GetKeyDown(KeyCode.R) && batteryCount > 0)
        {
            power += batteryCharge;
            batteryCount -= 1;
        }
        text.text = "X" + batteryCount.ToString();
    }
    }
