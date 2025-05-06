using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float minForce = 12f, maxForce = 16f;
    private float Torque = 10f;
    private float xRange = 4f, ySpawnPos = -6f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(ApplyUpwardForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(ApplyRandomTorque(), ApplyRandomTorque(), ApplyRandomTorque(), ForceMode.Impulse);
        transform.position = SetInitialPosition();
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
}
