using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{

    Animator animator;
    public CoinsManager coinsManager;
    public EndLevelManager endLevelManager;
    

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Activar");
            coinsManager.SavePlayerCoins();
            
            coinsManager.ResetCoins();
            //Scenes.Highscores();
            endLevelManager.EndLevel();

           
        }  
    }
   
}
