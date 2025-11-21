using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections; // Ya incluida, ¡perfecto!

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; 
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public float jumpForce = 7f; 
    private bool isGrounded; 
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject restartPanel; // Debe ser asignado al panel de "Volver a Intentar / Salir"
    public string nextSceneName = "escenario2"; // Asegúrate de que este nombre sea exacto

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        isGrounded = true; 
        if (restartPanel != null)
        {
            // Oculta el panel de reinicio al inicio
            restartPanel.SetActive(false); 
        }
    }
    
    // ... (OnMove, OnJump, FixedUpdate, OnTriggerEnter sin cambios) ...

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isGrounded = false;
        }
    }

    private void FixedUpdate() 
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "¡GANASTE! Siguiente mapa en 3s ";
            
            // 1. Destruye el enemigo inmediatamente.
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (enemy != null)
            {
                Destroy(enemy);
            }

            // 2. Comienza la corrutina para esperar y cargar la siguiente escena.
            StartCoroutine(LoadNextLevelAfterDelay(3f)); // Espera 3 segundos
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject); // El jugador muere
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "¡PERDISTE!";
            
            // ACTIVA el panel del menú de "Volver a intentar / Salir"
            if (restartPanel != null)
            {
                restartPanel.SetActive(true);
            }
        }
    }
    
    // ... (OnCollisionStay, OnCollisionExit sin cambios) ...

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("PickUp") && !collision.gameObject.CompareTag("Enemy"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadNextLevelAfterDelay(float delay)
    {
        // Detiene el movimiento del jugador mientras espera
        rb.linearVelocity = Vector3.zero; // Corregido: usando rb.velocity
        rb.angularVelocity = Vector3.zero;

        // Espera el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Carga la siguiente escena usando el nombre definido
        SceneManager.LoadScene(nextSceneName);
    }
    
    // Función para salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del Juego...");
        
        Application.Quit();

        #if UNITY_EDITOR
            // Esto es solo para detener el juego en el editor de Unity.
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}