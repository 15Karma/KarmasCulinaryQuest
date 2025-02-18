using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    #region atributos
    public SpriteRenderer spriteRenderer;
    public float health;
    public GameObject destroyParticle;
    public float coolDownAttack;

    private Animator animator;
    private bool canAttack = true;

    #endregion
    #region funciones y métodos

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckLife();
    }

    /// <summary>
    /// Method that takes 1 life form the enemy when the player hits them
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        health -= damage;
        animator.SetTrigger("Hit");

    }

    /// <summary>
    /// Method that checks if the enemy is still alive
    /// </summary>
    public void CheckLife()
    {
        if (health <= 0)
        {
            destroyParticle.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("Death", 0.2f);
        }
    }

    /// <summary>
    /// Method that destroys the enemy object
    /// </summary>
    private void Death()
    {
        Destroy(gameObject);
        //animator.SetTrigger("Death");
    }

    /// <summary>
    /// Meyhod that takes 1 life from the player when they collides with the enemy
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!canAttack) return;

            canAttack = false;

            collision.transform.GetComponent<PlayerDamage>().PlayerTakeHit(collision.GetContact(0).normal);

            Invoke("ActivateAttack", coolDownAttack);
        }
    }

    void ActivateAttack()
    {
        canAttack = true;
    }

    #endregion
}
