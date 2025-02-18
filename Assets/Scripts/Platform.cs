using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    #region atributos
    public float startWaitTime;
    public float waitedTime;
    private PlatformEffector2D effector;

    #endregion

    #region funciones y métodos
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }


    void Update()
    {


        if(Input.GetKey("s") || Input.GetKey("down"))
        {

            if(waitedTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitedTime = startWaitTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }

        if(Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space"))
        {
            effector.rotationalOffset = 0;

        }
    }

    #endregion
}
