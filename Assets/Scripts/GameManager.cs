using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas
using UnityEngine.UI; // Necesario para referenciar elementos de UI

public class GameManager : MonoBehaviour
{
    // Referencia al Panel completo del menú (asegúrate de arrastrarlo desde el Inspector)
    public GameObject gameOverPanel; 
    
    // Opcional: Referencia al objeto del Jugador para pausarlo
    public GameObject playerObject; 

    // Se llama cuando el enemigo pilla al jugador
    public void PlayerCaught()
    {
        // 1. Mostrar el menú
        gameOverPanel.SetActive(true); 

        // 2. Opcional: Pausar el juego
        Time.timeScale = 0f; 

        // 3. Opcional: Desactivar el movimiento del jugador
        if (playerObject != null)
        {
            // Dependerá de cómo tengas el script de movimiento, 
            // pero podrías desactivar el script o el Rigidbody.
            // Ejemplo: playerObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    // Se llama cuando se presiona el botón "Continuar"
    public void ContinueGame()
    {
        // 1. Ocultar el menú
        gameOverPanel.SetActive(false); 

        // 2. Reanudar el juego
        Time.timeScale = 1f; 

        // 3. Reiniciar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    // Se llama cuando se presiona el botón "Salir"
    public void QuitGame()
    {
        // Si estás en el editor de Unity, usa esto
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        // Si es una compilación para la aplicación, usa esto
        #else
            Application.Quit();
        #endif
    }
}