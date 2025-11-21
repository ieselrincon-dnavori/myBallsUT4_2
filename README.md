🕹️ myBallsUT4_2: Juego de Bola Rodante con Enemigos

📝 Resumen del Proyecto

Este proyecto es una implementación de un juego sencillo de bola rodante (Roll-a-Ball) creado en Unity. El objetivo principal es que el jugador controle una esfera para recoger todos los objetos "PickUp" mientras evita ser atrapado por un enemigo que lo persigue activamente.

Este proyecto fue diseñado para enseñar los principios fundamentales de Unity, cubriendo desde la gestión de la física hasta la navegación de IA y la programación de UI avanzada.

✨ Objetivos de Aprendizaje

El proyecto se enfoca en demostrar y enseñar los siguientes conceptos clave de Unity:

    Game Objects & Components: Uso fundamental de Rigidbody, Mesh Renderer, y Collider.

    Física: Implementación del movimiento del jugador mediante fuerzas (AddForce) en el componente Rigidbody.

    Scripting: Gestión de la entrada del usuario (Input System), control de estado del juego (puntuación, victoria, derrota), y detección de colisiones (OnTriggerEnter).

    IA & Navegación: Configuración de la Malla de Navegación (Nav Mesh Agent) para permitir que el enemigo siga al jugador de manera inteligente en el entorno.

    Estructura de Escena: Gestión de múltiples escenarios (SceneManager) para crear un juego con progresión de niveles.

    Interfaz de Usuario (UI): Creación y gestión de elementos de la interfaz de usuario con TextMeshPro y paneles de menú.

🎲 Características del Juego

Característica	Descripción
Control de Jugador	La bola se mueve utilizando fuerzas físicas y tiene capacidad de salto.
Recolección	El jugador debe recoger 12 objetos etiquetados como "PickUp".
Enemigo (IA)	Un enemigo con Nav Mesh Agent persigue al jugador. El contacto resulta en Game Over.
Victoria	Al recoger todos los PickUps, el jugador avanza automáticamente a la siguiente escena (escenario2) después de un breve mensaje de "¡GANASTE!".
Derrota (Game Over)	Al ser atrapado por el enemigo, aparece un menú de derrota con dos opciones.

🛑 Funcionalidad de Menú (Game Over)

El sistema de menú de derrota implementado garantiza una experiencia fluida al perder:
Botón	Función	Script que lo ejecuta
Volver a intentar	Recarga la escena actual (SceneManager.LoadScene(SceneManager.GetActiveScene().name)).	GameManager.cs
Salir	Cierra la aplicación (Application.Quit()).	GameManager.cs

    Nota: Las funciones de control de juego (RestartGame y QuitGame) fueron movidas del PlayerController a un objeto persistente, GameManager, para evitar errores de referencias perdidas (MissingReferenceException) cuando el objeto del jugador es destruido.

📋 Requisitos de Configuración

Para garantizar que el juego funcione correctamente, las siguientes configuraciones deben estar activas en Unity:

    Build Settings: Las escenas deben estar añadidas en File > Build Settings... (o Build Profiles). La escena de inicio debe tener el Índice 0, y el segundo nivel (escenario2) debe tener el Índice 1.

    Nav Mesh: La superficie de juego (Ground) debe estar marcada como Navigation Static, y la Malla de Navegación debe estar Generada (Baked) para que el enemigo (EnemyBody) pueda moverse.

    Etiquetas (Tags): Los objetos deben tener las etiquetas correctas: PickUp, Enemy, y Player.
