using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip getcoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        { 
            audiosource.PlayOneShot(getcoint);
            PlayerManager.numberOfCoins++;
            PlayerPrefs.SetInt("NumberOfCoins",PlayerManager.numberOfCoins);
            Destroy(gameObject); 
        }
    }
}   
       