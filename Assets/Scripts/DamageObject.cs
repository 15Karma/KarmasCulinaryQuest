using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    #region funciones y métodos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerDamage>().PlayerTakeHit(collision.GetContact(0).normal);
        }
    }
    #endregion
}
