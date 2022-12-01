using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public GameObject task;
    bool playerClose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Comprobara si la tarea esta activa y si a pulsado la tecla E y se instancia la tarea
        if(isTaskActive() && Input.GetKeyDown(KeyCode.E)) 
        {
            Instantiate(task);
        }
    }

    //Para conocer si el jugador se acerco a la actividad
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose=true;
        }
    }
    //Para conocer si el jugador se alejo
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerClose = false;
        }
    }

    //Para comprobar si la tarea esta activa
    private bool isTaskActive() 
    {
        return playerClose && !GameObject.FindWithTag("Task"); 
    }
}
