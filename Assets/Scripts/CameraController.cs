using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player GameObject.
    public GameObject player;

    // The distance between the camera and the player.
    private Vector3 offset;

    // Start is called before the first frame update.
    void Start()
    {
        // Asegurarse de que el jugador está asignado antes de calcular el offset.
        if (player != null)
        {
            offset = transform.position - player.transform.position; 
        }
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        // 🛑 CORRECCIÓN: Comprobar si el objeto 'player' no ha sido destruido.
        if (player != null) 
        {
            // Maintain the same offset between the camera and player throughout the game.
            transform.position = player.transform.position + offset;  
        }
        // Si el jugador es null (destruido), la cámara simplemente deja de intentar seguirlo.
    }
}