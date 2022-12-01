using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    //Boton jugar

   public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    //Boton Salir
    public void Salir()
    {
        Debug.Log("SAlir...");
        Application.Quit();
    }
}
