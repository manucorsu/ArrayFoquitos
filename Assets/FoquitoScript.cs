/* TAREA
 * Consigna 2: La empresa fabricante de estos foquitos multicolores nos pide que la vida útil de los mismos termine luego de que se hayan 
 * encendido 3 veces todos los colores, es decir, después de que se hayan cunplido tres ciclos de encendido. 
 * Una vez llegado a ese límite el foquito debe destruirse. Programar esa funcionalidad.
 */




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoquitoScript : MonoBehaviour
{
    [SerializeField] GameObject[] colors; //SerializeField se usa para poder ver la variable en el Inspector sin que sea pública.
    public int currentLightIndex = -1;
    int count; //cuenta cuántas luces se tienen que prender

    void Start()
    {
        count = colors.Length * 3; // empieza en length*3 porque cada luz se prende 3 veces.
                                    //cada vez que se prende una luz se le resta 1
                                    //cuando es = 0 se empiezan a destruir las luces.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateNextLight()
    {
        if(count > 0)
        {
            //EN EL EXAMEN PROBABLEMENTE NOS HAGA IMPLEMENTAR ESTA FUNCIÓN (adaptada al ejercicio)
            currentLightIndex++; //empieza en -1, así que cuando hacemos esto ya pasa al 1er elemento de la lista [0]
            if (currentLightIndex >= colors.Length) //siempre hay que chequear que el índice sea válido
            {
                currentLightIndex = 0;
            }
            DeactivateAllLights();
            colors[currentLightIndex].SetActive(true);
            count--;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*ignorar*/ public void ActivatePreviousLight()
    {
        currentLightIndex--;
        if (currentLightIndex < 0)
        {
            currentLightIndex = colors.Length - 1;
        }
        DeactivateAllLights();
        colors[currentLightIndex].SetActive(true);
    }

    void DeactivateAllLights()
    {
        //foreach (GameObject g in colors)
        //{
        //    g.SetActive(false);
        //} // Esto es un foreach. Es hermoso pero en el examen solo vamos a poder usar for:

        for (int i = 0; i < colors.Length; i++)
        {
            colors[i].SetActive(false);
        }
    }

    public void ActivateRepeating(float t)
    {
        InvokeRepeating(nameof(ActivateNextLight),0,t);
    }
}
