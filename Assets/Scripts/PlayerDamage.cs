using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    #region atributos
    public GameObject[] hearts;
    public int health = 3;
    public AudioSource clip;

    private PlayerMove playerMove;
    [SerializeField]
    private float loseControlTime;
    private Animator animator;
    private CoinsManager coinsManager;

    #endregion

    #region funciones y métodos
    void Start()
    {
        coinsManager = FindAnyObjectByType<CoinsManager>();
        playerMove = GetComponent<PlayerMove>();
        animator = GetComponent<Animator>();
        health = hearts.Length;
    }

    public void DisableHeart(int index)
    {
        Destroy(hearts[index].gameObject);
    }

    public void PlayerTakeHit(Vector2 position)
    {
        health-=1;

        DisableHeart(health);
        animator.SetTrigger("Hit");

        StartCoroutine(LoseControl());

        playerMove.OnKnockback(position);

        clip.Play();

        if (health <= 0)
        {
            //The level is restarted
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            //We restart the coins to 0 
            coinsManager.ResetCoins();
        }
    }



    public IEnumerator LoseControl()
    {
        playerMove.canMove = false;
        yield return new WaitForSeconds(loseControlTime);
        playerMove.canMove = true;
    }
    #endregion
}
