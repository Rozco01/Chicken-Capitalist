using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{

    [Header("Jugador")]
    public PlayerController playerController;


    private int eggsPrice = 1;
    private int mayoPrice = 5;
    private int milkPrice = 10;
    private int cheesePrice = 20;

    private int totalSell = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                totalSell = (eggsPrice * playerController.eggs) + (mayoPrice * playerController.mayo) + (milkPrice * playerController.milk) + (cheesePrice * playerController.cheese);          
                playerController.cash += totalSell;
                totalSell = 0;

                Debug.Log("Dinero del jugador" + playerController.cash);
            }
        }
    }
}
