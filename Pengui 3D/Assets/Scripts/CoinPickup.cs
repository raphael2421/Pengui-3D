using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value;
    public AudioSource Eggaudio;
    public GameObject coinEffect;

    public void Awake()
    {
        
    }
    void Start()
    {
        //Eggaudio =  GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Eggaudio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Eggaudio.Play();
            GameManager.instance.AddCoins(value);
            Instantiate(coinEffect, transform.position, transform.rotation);
            Destroy(gameObject);


        }
    }
}
