using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlScript : MonoBehaviour
{

    [Header("Letrero")]
    public Image imagenCanvas;
    public TMP_Text Tittle;
    public TMP_Text Texto;
    public TMP_Text Texto2;

    [Header("Script jugador")]
    public GameObject objetoConScript;
    private MonoBehaviour script;

    // Start is called before the first frame update
    void Start()
    {
        script = objetoConScript.GetComponent<MonoBehaviour>();
        script.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            script.enabled = true;
            imagenCanvas.enabled = false;
            Tittle.enabled = false;
            Texto.enabled = false;
            Texto2.enabled = false;
            gameObject.SetActive(false);
        }
        
    }
}
