using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objeto a seguir (el Player)
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Posición relativa de la cámara (ej: 2 unidades arriba, 5 unidades detrás)

    // LateUpdate se llama después de que todos los Updates han terminado, 
    // lo que garantiza que el jugador ya se movió en el frame actual.
    void LateUpdate()
    {
        if (target != null)
        {
            // Establece la posición de la cámara a la posición del jugador más el offset
            transform.position = target.position + offset;
        }
    }
}