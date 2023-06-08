using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo a generar
    public Transform[] spawnPoints; // Puntos de generación de los enemigos

    private List<GameObject> activeEnemies = new List<GameObject>(); // Lista de enemigos activos

    public int maxEnemies = 3; // Máximo de enemigos permitidos

    private void OnEnable()
    {
        // Generar los enemigos iniciales
        for (int i = 0; i < maxEnemies; i++)
        {
            GenerateEnemy();
        }
    }

    private void Update()
    {
        // Comprobar si hay menos de maxEnemies enemigos activos
        if (activeEnemies.Count < maxEnemies)
        {
            GenerateEnemy();
        }
    }

    private void GenerateEnemy()
    {
    // Comprobar si hay un punto de generación disponible
    if (spawnPoints.Length == 0)
    {
        Debug.LogWarning("No se encontraron puntos de generación de enemigos.");
        return;
    }

    // Seleccionar un punto de generación al azar
    Transform spawnPoint = GetRandomSpawnPoint();

    // Verificar si el punto de generación es nulo
    if (spawnPoint == null)
    {
        Debug.LogWarning("No se encontró un punto de generación válido.");
        return;
    }

    // Generar el enemigo en el punto de generación
    GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    // Añadir el enemigo a la lista de enemigos activos
    activeEnemies.Add(enemy);

        // Configurar el generador de enemigos en el enemigo generado
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.enemySpawner = this;
        }
    }


    private Transform GetRandomSpawnPoint()
        {
    List<Transform> availableSpawnPoints = new List<Transform>();

    // Obtener los puntos de generación que no están ocupados por enemigos
    foreach (Transform spawnPoint in spawnPoints)
    {
        bool isOccupied = false;

        // Verificar si el punto de generación está ocupado por un enemigo activo
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = activeEnemies[i];

            if (enemy == null)
            {
                // El enemigo ha sido destruido, así que lo eliminamos de la lista
                activeEnemies.RemoveAt(i);
            }
            else if (enemy.transform.position == spawnPoint.position)
            {
                isOccupied = true;
                break;
            }
        }

        if (!isOccupied)
        {
            availableSpawnPoints.Add(spawnPoint);
        }
    }

    // Seleccionar un punto de generación al azar de los disponibles
    int randomIndex = Random.Range(0, availableSpawnPoints.Count);
    return availableSpawnPoints[randomIndex];
}


    public void RemoveEnemy(GameObject enemy)
    {
        // Eliminar el enemigo de la lista de enemigos activos
        activeEnemies.Remove(enemy);

        // Generar un nuevo enemigo si hay menos de maxEnemies enemigos activos
        if (activeEnemies.Count < maxEnemies)
        {
            GenerateEnemy();
        }
    }
}
