# Whack-an-animal
## Introducción
Nuestro objetivo de prototipo cómo trabajo final para la asignatura de Interfaces Inteligentes era el de llevar a cabo un juego para realidad virtual y funcionalidad de cardboard. Este juego se trata de un mapa en el que usuario se situa en el centro del mismo y a su alrededor podrá ver una serie de agujeros, de los cuales saldran de manera aleatoria animales, los cuales el usuario deberá eliminar usando un martillo el cual aparece tras vizualizar por unos segundos al animal mediante la reticula. 

El juego dispone de un tiempo límite en el que jugador deberá conseguir el máximo de puntos posibles, a la vez de que cuenta con la posibilidad de interactuar de la misma manera con una serie de objetos denominados "Power up" los cuales agilizan el tiempo que se tarda en destruir dichos animales.

## Cuestiones importantes para el uso
De cara al uso del programa es necesario que el usuario pueda instalar el apk del mismo en su móvil o cualquier otro dispositivo que vaya a conectar con unas gafas VR para poder utilizar de la mejor manera posible el juego. Por otro lado es necesario que a la hora de jugarlo este disponga del suficiente espacio físico para poder girar su cuerpo (No es necesario moverse) y evitar cualquier posible contratiempo debido a la falta de visión con el exterior.

## Hitos de programación logrados relacionándolos con los contenidos que se han impartido
De cara a poder realizar este proyecto utilizamos utilizamos muchos de los contenidos adquiridos por las prácticas cómo fueron los siguientes:

**Manejo de assets y prefabs:** Cómo se puede ver a simple vista, el proyecto cuenta con diferentes objetos cómo son los propios animales, el martillo, el mundo o los propios agujeros, los cuales son objetos "prefab" generados por nosotros a partir de los componentes de algunos assets. Otro punto a comentar es que a la hora de eliminar a los distintos animales estos cambian su animación y activan un sistema de particulas el cual también corresponde a un asset.

**Físicas y colliders:** A la hora de poder llevar a cabo que el martillo fuese capaz de golpear a los animales fue necesario establecerles una serie de colliders para poder asegurar que estos podían colisionar entre sí. Y de esta manera garantizar que no hubiese problemas al no detectar a los mismos.

**Delegados y Eventos:** Otro punto que cumplimentamos fue el de usar eventos y delegados. A la hora de gestionar las distintas acciones con el martillo, este activa un delegado al cual los distintos objetos se suscriben. De esta manera se permiten hacer acciones cómo que el martillo sea capaz de indicarle a un objeto animal cuando activar el evento que gestiona su cambio de animación y destrucción. Que sea posible que la UI sea capaz de recibir actualización de la puntuación. Al igual de que sea posible activar un powerup, o que en el momento en el que se acaba el tiempo se lance un evento que finalize la ejecución del juego.

**Uso de UI:** A simple vista otro de los puntos que implementamos fue el de hacer uso de interfaz de usuario (UI) la cual indica en todo momento los puntos del jugador, así cómo su tiempo restante de partida. Además de una pantalla para indicar cuando finaliza el juego. 

**Manejo de sonido:** De manera adicional otro detalle que añadimos, fue el hecho de que el juego contase con una música de fondo, la cual se ejecuta en bucle durante toda la partida, además de tambíen los animales hacen un sonido en el momento en el que son golpeados.

**Manejo del Cardboard:** Finalmente, de cara al proyecto implementamos el manejo de carboard, en el cual recae el peso de juego y gestiona todo lo antes mencionado dando lugar al prototipo final. 

## Aspectos que destacarías en la aplicación. 
De cara a aspectos a destacar, consideramos que la aplicación es un juego entretenido, además de que se usa una gran cantidad de eventos que permiten hacer que el juego funcione, gestionandolo todo con un sistema de cardboard que se complementa con nuestro objetivo inicial del prototipo.


## Especificar si se han incluido sensores de los que se han trabajado en interfaces multimodales.
PENDIENTE
## Gif animado de ejecución
PENDIENTE
## Acta de los acuerdos del grupo respecto al trabajo en equipo: reparto de tareas, tareas desarrolladas individualmente, tareas desarrolladas en grupo, etc.
PENDIENTE