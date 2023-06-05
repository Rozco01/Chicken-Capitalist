using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public int rotationScale = 10;
    public float anguloDiaInicio = 180f;
    public float anguloDiaFin = 270f;
    public float anguloNocheInicio = -90f;
    public float anguloNocheFin = 0f;

    // Update is called once per frame
    void Update()
    {

    transform.Rotate(rotationScale * Time.deltaTime, 0, 0);

    // Obtén la rotación en el eje X de la Directional Light
    float rotacionX = transform.rotation.eulerAngles.x;

    // Comprueba si está en el rango del día
    if (rotacionX >= anguloDiaInicio && rotacionX <= anguloDiaFin){
        // Es de día
       
    }
    else{
        Debug.Log("Es de noche");  
        // Es de noche
    }

    }
}
