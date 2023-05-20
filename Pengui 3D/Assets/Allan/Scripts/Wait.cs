using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
    public float wait_time = 5f;
    public int sceneID;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait_For_Intro());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Wait_For_Intro()
    {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(sceneID);
    }
}
