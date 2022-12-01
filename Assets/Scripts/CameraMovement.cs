using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //posisicon de la camara es diferente de la posicion del player
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new  Vector3 (target.position.x, target.position.y, transform.position.z);//Nueva posicion

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); 
        }
        
    }
}
