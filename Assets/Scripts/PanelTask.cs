using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PanelTask : MonoBehaviour
{
    public TextMeshProUGUI display;
    public TextMeshProUGUI papel;

    public AudioClip approved;
    public AudioClip denied;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        GenerateAnio(); 
        
    }

  
    public void AddNumber(string number)
    {
        display.color = Color.white;
        //Para que pueda ingresar solo 4 numeros
        if (display.text.Length >= 4) 
        {
            return;
        }
        display.text += number;
    }
    //Metodo para borrar la pantalla
    public void EraseDisplay()
    {
        display.text = "";
    }

    public void GenerateAnio()
    {
        papel.text = "1963";
     
    }

    //Funcion para validar el anio
    public void CheckAnio()
    {
        if (display.text.Equals(papel.text)) //Compara el texto del papel con el ingresado
        {
            
            audioSource.PlayOneShot(approved);//Mostrara este texto si esta bien
            display.color= Color.cyan;
            display.text = "Granted";//Mostrara este texto si esta bien
            Destroy(gameObject, 1.0f);
        }
        else
        {
            audioSource.PlayOneShot(denied);
            display.color = Color.red;
            display.text = "Denied";
        }
    }
}
