using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoopController : MonoBehaviour
{
    [Header ("Numero En letrero")]
    public TMP_Text NumberEggs;

    [Header ("Nivel del gallinero")]
    public int coopLevel = 1;

    [Header ("Cantidad de huevos del gallinero")]
    public int unitPerSecond = 1;
    public int currentValueEggs = 0;

    //Intervalos de generacion
    private float timer = 0f;
    private float interval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentValueEggs = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval){
            IncrementValue();
            timer = 0f;
        }

        UpdateValueText();
    }

    private void IncrementValue()
    {
        switch (coopLevel)
        {
            case 1:
                currentValueEggs += unitPerSecond;
                break;
            case 2:
                currentValueEggs += unitPerSecond * 3;
                break;
            case 3:
                currentValueEggs += unitPerSecond * 5;
                break;
        }
    }

    private void UpdateValueText()
    {
        NumberEggs.text = currentValueEggs.ToString(); // Actualizar el valor en el Text del UI
    }
}
