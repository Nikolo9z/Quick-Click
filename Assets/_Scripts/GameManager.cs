using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public enum GameState { Loading, Playing, GameOver } // Definición de estados del juego
    public List<GameObject> targetPrefabs; // Lista de prefabs de objetivos
    public float spawnRate = 1f; // Tasa de aparición de objetivos
    public TextMeshProUGUI scoreText; // Texto para mostrar la puntuación
    private int score ; // Puntuación del jugador
    public TextMeshProUGUI gameOverText; // Texto de Game Over
    public GameState currentGameState; // Estado actual del juego

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGameState= GameState.Playing;
        StartCoroutine(SpawnTarget()); // Inicia la corrutina para instanciar objetivos
        UpdateScore(0); // Inicializa la puntuación en 0
        gameOverText.gameObject.SetActive(false); // Desactiva el texto de Game Over al inicio
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {

        while (currentGameState== GameState.Playing) // Mientras el juego esté en estado "Playing"
        {
            yield return new WaitForSeconds(spawnRate); // Espera 1 segundo antes de instanciar el siguiente objetivo
            int index = Random.Range(0, targetPrefabs.Count); // Selecciona un prefab aleatorio de la lista
            Instantiate(targetPrefabs[index]); // Instancia el prefab seleccionado
        }
    }

    /// <summary>
    /// Actualiza la puntuación del juego añadiendo los puntos especificados.
    /// </summary>
    /// <param name="points">Los puntos a añadir a la puntuación actual.</param>
    /// <remarks>
    /// Este método incrementa el contador de puntuación y actualiza el texto mostrado en la interfaz de usuario.
    /// </remarks>
    public void UpdateScore(int points)
    {
        score += points; // Aumenta la puntuación
        scoreText.text = "Score: " + score; // Actualiza el texto de la puntuación
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // Activa el texto de Game Over
        currentGameState = GameState.GameOver; // Cambia el estado del juego a "GameOver"
    }
}
