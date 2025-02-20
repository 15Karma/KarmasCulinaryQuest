using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEfect : MonoBehaviour
{
    #region atributos
    public Camera cam;
    public Transform followTarget;

    Vector2 startingPosition;
    Vector2 cameraMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float startingZ;
    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    #endregion

    #region funciones y m�todos

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition * cameraMoveSinceStart * parallaxFactor;
        transform.position = new Vector3 (newPosition.x, newPosition.y, startingZ);
    }
    #endregion
}
