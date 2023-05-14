using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    public GameObject deathEffect;

    public int currentCoins;

    public int LevelEndMusic;

    public string LevelToLoad;

    private void Awake()
    {
        instance = this; 
    }
 
    void Start()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = PlayerController.instance.transform.position; 

        AddCoins(0);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }

    public void Respawn()
    {
       StartCoroutine("RespawnWaiter");
       HealthManager.instance.PlayerKilled();
    }

    public IEnumerator RespawnWaiter()
    {
       PlayerController.instance.gameObject.SetActive(false);

       CameraController.instance.cmBrain.enabled = false;

       UIManager.instance.fadeToBlack = true;

       Instantiate(deathEffect, PlayerController.instance.transform.position + new Vector3(0f, 1f, 0f), PlayerController.instance.transform.rotation);

       yield return new WaitForSeconds(2f);

        UIManager.instance.fadeFromBlack = true;

       CameraController.instance.cmBrain.enabled = true;

       PlayerController.instance.transform.position = respawnPosition;
       PlayerController.instance.gameObject.SetActive(true);

       HealthManager.instance.ResetHealth();
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
    }

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
        UIManager.instance.coinText.text = "" + currentCoins;
    }

    public void PauseUnPause()
    {
        if(UIManager.instance.pauseScreen.activeInHierarchy)
        {
            UIManager.instance.pauseScreen.SetActive(false);
            Time.timeScale = 1f;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else{
            UIManager.instance.pauseScreen.SetActive(true);
            UIManager.instance.CloseOptions();
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

     public IEnumerator LevelEndWaiter()
    {
       //AudioManager.instance.PlayMusic(LevelEndMusic);
       PlayerController.instance.stopMove = true;

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(LevelToLoad)
;    }
}
