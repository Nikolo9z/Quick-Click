using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float minForce = 12f, maxForce = 16f;
    private float Torque = 10f;
    private float xRange = 4f, ySpawnPos = -2f;
    private GameManager gameManager; // Referencia al GameManager
    public int PointValue; // Valor de puntos al hacer clic en el objeto
    public ParticleSystem explosionParticle; // Partícula de explosión al destruir el objeto
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(ApplyUpwardForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(ApplyRandomTorque(), ApplyRandomTorque(), ApplyRandomTorque(), ForceMode.Impulse);
        transform.position = SetInitialPosition();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Busca el GameManager en la escena
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Genera un vector de fuerza vertical con magnitud aleatoria
    /// </summary>
    /// <returns>Vector tridimensional con dirección hacia arriba y magnitud aleatoria entre minForce y maxForce</returns>
    private Vector3 ApplyUpwardForce()
    {
        float randomForce = Random.Range(minForce, maxForce);
        return Vector3.up * randomForce;
    }

    /// <summary>
    /// Genera un valor aleatorio para aplicar torque en un eje
    /// </summary>
    /// <returns>Valor aleatorio entre -Torque y Torque</returns>
    private float ApplyRandomTorque()
    {
        float randomTorque = Random.Range(-Torque, Torque);
        return randomTorque;
    }

    /// <summary>
    /// Define una posición inicial aleatoria para el objeto
    /// </summary>
    /// <returns>Vector con posición X aleatoria dentro del rango definido y posición Y fija</returns>
    private Vector3 SetInitialPosition()
    {
        float randomX = Random.Range(-xRange, xRange);
        return new Vector3(randomX, ySpawnPos);
    }

    private void OnMouseDown() 
    {
        if(gameManager.currentGameState == GameManager.GameState.Playing) // Verifica si el juego está en estado "Playing"
        {
        Destroy(gameObject); // Destruye el objeto al hacer clic en él
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); // Instancia la partícula de explosión en la posición del objeto
        gameManager.UpdateScore(PointValue); // Aumenta la puntuación en 1 al hacer clic
        if (gameObject.CompareTag("Bad")){
            gameManager.GameOver(); // Llama al método GameOver del GameManager si el objeto es un objetivo malo
        }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone")) // Verifica si el objeto colisiona con el GameOver
        {
            Destroy(gameObject); // Destruye el objeto al entrar en contacto con el GameOver
            if (gameObject.CompareTag("Good")) // Verifica si el objeto es un objetivo
            {
                gameManager.UpdateScore(-PointValue); // Resta puntos al jugador
            }
        }
    }
}
