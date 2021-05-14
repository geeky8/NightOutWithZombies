using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(xampleCoroutine());
    }

    IEnumerator xampleCoroutine()
    {
        timeController.Leaderboard();
        yield return new WaitForSeconds(35);
        SceneManager.LoadScene(0);
    }
}
