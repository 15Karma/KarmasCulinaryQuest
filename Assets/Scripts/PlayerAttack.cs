using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region atributos
    public Animator animator;

    [SerializeField]
    private Transform attackController;
    [SerializeField]
    private float hitRadio;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float timeBetweenAttacks;
    [SerializeField]
    private float timeNextAttack;
    [SerializeField]
    private LayerMask enemyLayers; // Añadir LayerMask para enemigos
    #endregion

    #region funciones y métodos

    private void Update()
    {

        if(timeNextAttack > 0)
        {
            timeNextAttack -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && timeNextAttack <= 0)
        {
            Attack();
            timeNextAttack = timeBetweenAttacks;
        }
    }

    /// <summary>
    /// Method that set the attack animation and takes 1 life from the enemy if they are in the attack range
    /// </summary>
    public void Attack()
    {
        animator.SetTrigger("Attack");
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackController.position, hitRadio, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name); // Log para verificar
            if (enemy.transform.CompareTag("Enemy"))
            {
                enemy.transform.GetComponent<EnemyDamage>().TakeDamage(damage); 
            }
        }
    }

    /// <summary>
    /// Method that draws a red circle so we can see the attack range
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, hitRadio);
    }
    #endregion
}
