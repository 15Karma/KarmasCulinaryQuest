using Dan.Enums;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;

public class EnemyMove : MonoBehaviour
{
    #region atributos
    public SpriteRenderer spriteRenderer;
    public float speed = 10f;
    public float startWaitTime = 2;
    public float startWaitTimeHit = 1;
    public Transform[] moveSpots;

    private Animator animator;
    private float waitTime;
    private int wayPoints = 0;
    private Vector2 actualPos;
   
    #endregion

    #region funciones y métodos

    void Start()
    {
        waitTime = startWaitTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position=Vector2.MoveTowards(transform.position, moveSpots[wayPoints].transform.position, speed * Time.deltaTime);

        
        if(Vector2.Distance(transform.position, moveSpots[wayPoints].transform.position) < 0.1f)
        {
            //Si el enemigo se ha quedado parado un tiempo ya
            if(waitTime <= 0)
            {
                //va al punto 2 del recorrido 
                if (moveSpots[wayPoints]!= moveSpots[moveSpots.Length-1])
                {
                    wayPoints++;
                    waitTime = startWaitTime;
                }
                else //Vuelve al punto 1 del recorrido
                {
                    wayPoints = 0;
                    waitTime = startWaitTime;

                }
            }
            else //Empieza a quedarse un tiempo quieto
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(1f);

        if(transform.position.x > actualPos.x) 
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Idle", false);
        }
        else if(transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Idle", false);
        }
        else if(transform.position.x == actualPos.x)
        {
            animator.SetBool("Idle", true);
        }
    }



    #endregion
}
