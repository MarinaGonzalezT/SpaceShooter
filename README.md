# Space Shooter

Proyecto desarrollado en Unity para la asignatura **Desarrollo de Videojuegos I** del Máster en Diseño y Desarrollo de Videojuegos.

El proyecto parte de un prototipo base de *Space Shooter* realizado en clase, al que se han añadido nuevas mecánicas, sistemas de juego, enemigos, interfaz, progresión de dificultad y un jefe final.

## Descripción del juego

Space Shooter es un juego arcade 2D en el que el jugador controla una nave espacial y debe sobrevivir a oleadas de enemigos mientras acumula puntuación. 

A medida que avanza la partida, la dificultad aumenta progresivamente, permitiendo que aparezcan más enemigos simultáneamente.

El objetivo principal es resistir el mayor tiempo posible, eliminar enemigos, recoger power-ups de vida y derrotar al jefe final.

## Enlace al juego

El juego está disponible en itch.io:

https://shiro-gt.itch.io/space-shooter

## Implementaciones principales

### Sistema de vida

Se ha implementado un sistema de vida basado en tres corazones divididos en mitades, dando un total de seis puntos de vida. Cada impacto recibido reduce la vida del jugador en función del tipo de enemigo o proyectil recibido.

La interfaz de vida se actualiza visualmente activando y desactivando las partes visibles de cada corazón. También se permite recuperar vida mediante power-ups.

### Sistema de puntuación y récord

El jugador obtiene puntos al eliminar enemigos mediante sus disparos. Cada tipo de enemigo puede otorgar una puntuación diferente.

Además, se ha implementado un sistema de récord utilizando `PlayerPrefs`, de forma que la mejor puntuación se mantiene entre partidas. Las pantallas de derrota y victoria muestran la puntuación obtenida y modifican su contenido si se alcanza un nuevo récord.

### Enemigos

Se han añadido distintos tipos de enemigos, cada uno con su propio comportamiento:

- **Enemy Space Ship Blue**: enemigo con movimiento horizontal de ida y vuelta dentro de unos límites definidos.
- **Enemy Space Ship Red**: enemigo que avanza de derecha a izquierda disparando proyectiles durante su trayectoria.
- **Enemy Boss**: jefe final que aparece tras un tiempo determinado, se mueve verticalmente y dispara desde dos puntos alternos.

Cada enemigo dispone de su propio script, permitiendo configurar su velocidad, daño, puntuación y comportamiento.

### Generador de enemigos

El sistema de generación de enemigos se ha ampliado respecto al prototipo inicial. Ahora permite trabajar con un array de prefabs de enemigos y un array de tiempos de aparición, de forma que cada tipo de enemigo puede generarse con una frecuencia distinta.

También se limita el número máximo de enemigos en escena para controlar la dificultad y evitar una acumulación excesiva de objetos.

### Progresión de dificultad

La dificultad aumenta de forma progresiva durante la partida. Cada cierto tiempo, el generador permite que haya un enemigo adicional en escena, haciendo que el juego se vuelva más exigente.

Cuando se alcanza el límite máximo de dificultad, se detiene la generación de enemigos normales y aparece el jefe final.

### Boss final

El jefe final entra en escena desde el lado derecho de la pantalla. Una vez alcanza su posición, deja de desplazarse horizontalmente y comienza un movimiento vertical.

El boss dispara proyectiles alternando entre dos puntos de disparo. A diferencia de los enemigos normales, necesita recibir varios impactos antes de ser destruido. Al derrotarlo, se muestra la pantalla de victoria.

### Power-ups

Se ha implementado un sistema de power-ups de vida. Tras eliminar un número determinado de enemigos, aparece un corazón en la posición del enemigo destruido. Al recogerlo, el jugador recupera un corazón completo.

La aparición de estos power-ups se vuelve progresivamente menos frecuente, aumentando el número de enemigos necesarios para generar el siguiente.

### Menú de pausa

Se ha añadido un menú de pausa activado mediante el Input System. El menú permite detener la partida usando `Time.timeScale`, reanudar el juego o salir.

El sistema se ha integrado en el controlador del jugador mediante una acción específica de pausa.

### Pantallas de Game Over y Victoria

El juego cuenta con dos pantallas finales:

- **Game Over**: aparece cuando la vida del jugador llega a cero.
- **Victory**: aparece al derrotar al jefe final.

Ambas pantallas permiten reiniciar la partida o salir del juego, y muestran información sobre la puntuación y el récord.

### Fondo y música

Se ha añadido un fondo espacial con desplazamiento horizontal para reforzar la sensación de movimiento. Este sistema está gestionado mediante un script de parallax.

También se ha incorporado música de fondo mediante un `MusicManager`, manteniendo la ambientación durante la partida.

## Controles

- **Movimiento**: WASD / Joystick
- **Disparo**: MB1 / Cuadrado del mando
- **Pausa**: P / Escape / Botón Start del mando

## Tecnologías utilizadas

- Unity 6000.3.9f1
- C#
- Input System
- TextMeshPro
- PlayerPrefs
- Itch.io

## Estructura del proyecto

El proyecto está organizado principalmente en:

- `Assets/Scripts`: scripts principales del juego
- `Assets/Prefabs`: prefabs de jugador, enemigos, proyectiles y power-ups
- `Assets/Scenes`: escena principal del juego
- `Assets/Fonts`: fuentes utilizadas en la interfaz
- `Assets/Sounds`: música y sonidos del proyecto

## Scripts principales

- `SpaceShipController`: controla el movimiento, disparo y pausa del jugador.
- `SpaceShipLife`: gestiona la vida del jugador y su representación visual.
- `SpaceShipScore`: controla la puntuación actual.
- `EnemyGenerator`: gestiona la aparición de enemigos, progresión de dificultad y aparición del boss.
- `EnemySpaceShipBlue`: comportamiento del enemigo azul.
- `EnemySpaceShipRed`: comportamiento del enemigo rojo con disparo.
- `EnemyBoss`: comportamiento del jefe final.
- `EnemyShot`: comportamiento de los proyectiles enemigos.
- `PlayerShot`: comportamiento de los disparos del jugador.
- `LifeDropGenerator`: controla cuándo aparecen power-ups de vida.
- `LifePowerUp`: gestiona el movimiento y recogida del power-up.
- `PauseMenu`: controla el menú de pausa.
- `GameOverMenu`: gestiona la pantalla de derrota y el récord.
- `VictoryMenu`: gestiona la pantalla de victoria.
- `MusicManager`: controla la música de fondo.
- `SpaceBackgroundParallax`: gestiona el movimiento del fondo.

## Desarrollo

Durante el desarrollo se ha seguido una estructura modular, separando la lógica del juego en diferentes scripts. Esta organización permite modificar o ampliar sistemas concretos sin afectar al resto del proyecto.

Algunas decisiones importantes del desarrollo fueron:

- Separar la vida, puntuación y menús en scripts independientes.
- Usar prefabs para enemigos, proyectiles y power-ups.
- Gestionar la dificultad desde el generador de enemigos.
- Utilizar `PlayerPrefs` para mantener el récord entre partidas.
- Mantener el sistema de entrada mediante Input System, evitando detección directa de teclas en `Update`.

## Problemas encontrados

Durante el desarrollo surgieron algunos problemas relacionados con la configuración de colisiones entre objetos, especialmente entre balas, enemigos, límites y power-ups. Estos problemas se resolvieron ajustando tags, colliders y condiciones dentro de `OnCollisionEnter2D`.

## Posibles mejoras futuras

Algunas mejoras que podrían añadirse en futuras versiones son:

- Animaciones de explosión para enemigos.
- Más tipos de power-ups.
- Nuevos patrones de disparo para el boss.
- Efectos de sonido para disparos, daño y recogida de objetos.
- Sistema de tienda o mejoras usando la puntuación.
- Mayor variedad de niveles o fases.

## Autora

Proyecto desarrollado por **Marina González Torres**.