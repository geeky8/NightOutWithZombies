using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
	public AudioMixer audioMixer;
    public GameObject m_audio;

    void Start()
    {
        DontDestroyOnLoad(m_audio);
    }

    public void PlayGame () 
    {
        SceneManager.LoadScene(4);
    }


    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
	}
   
}
