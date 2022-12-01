using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;

    //Para la colision
    public LayerMask solidObjectsLayer;

    //PAra animacion de movimiento
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    //Start
    public VectorValue startingPosition;
    private void Start()
    {
            transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMovementActive())
        {
            if (!isMoving)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                if (input.x != 0) input.y = 0;//Para que no se mueva en diagonal

                if (input != Vector2.zero)
                {
                    animator.SetFloat("moveX", input.x);
                    animator.SetFloat("moveY", input.y);

                    var targetPos = transform.position;  //Saber la posicion del jugador
                    targetPos.x += input.x; //Se movera al siguiente cuadro horizontalmente
                    targetPos.y += input.y;

                    if (IsWalkable(targetPos))
                        StartCoroutine(Move(targetPos));
                }
            }

            //Cuando se mueve 
            animator.SetBool("isMoving", isMoving);
        }
       

    }
    // Crea el movimiento del personaje en la grilla
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    //Preguntar si puedo caminar por donde esta el objeto
    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.005f, solidObjectsLayer)!= null)
        {
            return false;
        }
        return true;
    }
    
    //Funcion que devolvera true si no hay una tarea en la escena
    bool isMovementActive()
    {
        return !GameObject.FindWithTag("Task");
    }

}