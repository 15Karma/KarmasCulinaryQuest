using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollected : MonoBehaviour
{

    #region atributos

    [SerializeField]
    private int valor = 1;
    [SerializeField]
    private CoinsManager coinsManager;

    public AudioSource clip;

    #endregion

    #region funciones y métodos
    /// <summary>
    /// Method that adds a coin when the player collides it
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){

            //We add the coins in the HUD
            coinsManager.AddCoins(valor);

            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f );

            //Coin collected sound
            clip.Play();
        }
    }
   
 
    #endregion
}

