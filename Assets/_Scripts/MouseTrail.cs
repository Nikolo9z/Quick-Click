using UnityEngine;

public class MouseTrail : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition; // Obtiene la posición del mouse en la pantalla
        mousePos.z = 0f; // Establece la distancia al plano de recorte cercano de la cámara
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos); // Convierte la posición del mouse a coordenadas del mundo
        transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z); // Actualiza la posición del objeto a la posición del mouse


        
    }
}
