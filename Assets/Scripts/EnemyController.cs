using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public int vida = 1000;
    private bool isAttacking = false;
    private Transform player;

    
    public float velocidadMovimiento = 3f;
    public float rangoAtaque = 2f;

    private int damage = 100;

    [Header("Jugador")]
    public PlayerController playerController;
    public EnemySpawner enemySpawner;


    private void Start()
    {
        animator.SetBool("IsWalking", true); // Inicia con la animación de caminar
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia <= rangoAtaque && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        else if (!isAttacking)
        {
            MoveTowardsPlayer();
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("IsWalking", false); // Detiene la animación de caminar
        animator.SetBool("IsAttacking", true); // Activa la animación de atacar
        Debug.Log("¡Di mi ataque!");
        playerController.cash -= damage;

        // Espera a que termine la animación de atacar
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        animator.SetBool("IsAttacking", false); // Desactiva la animación de atacar
        animator.SetBool("IsWalking", true); // Vuelve a la animación de caminar
        isAttacking = false;
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // No cambia la posición en el eje Y
        direction.Normalize(); // Normaliza el vector dirección

        transform.Translate(direction * velocidadMovimiento * Time.deltaTime, Space.World);
        transform.LookAt(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
                Debug.Log("¡Me dieron!");
                vida -= 10;
                if (vida <= 0)
                {
                    Destroy(gameObject);
                }
        }
    }
}