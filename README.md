Simulacro Parcial 2 - Agustín López

Problema 1:

Pregunta: ¿Es necesario utilizar persistencia para las clases disponibles en el gimnasio?

Si, al ser que los clientes no se adhieren a clases directamente, la persistencia permite mantener un 
régimen de estructura en las clases disponibles que contenga la información necesaria para guardar los datos
necesarios de los clientes, sin perderlos cuando se carguen los datos al sistema.

Pregunta: ¿Se debe usar un Diccionario para los miembros del gimnasio?

no xd


Problema 2:
Pregunta: ¿Es necesario aplicar encapsulamiento en la clase Mascota?

Not really, preceden de prioridad de la información con otras clases u objetos, así que puede ser todo público

Pregunta: ¿Es necesario implementar persistencia para los dueños de las mascotas?

No, ya que los datos que han de guardar y cargar sobre los dueños son poco relevantes/inexistentes


Problema 3:
Pregunta: ¿Se requiere el uso de un Enum para los tipos de cancha?

Es posible usar un enum al predecer de usar una Clase para cada tipo de cancha (dado que no se implican datos para cada
cancha específica salvo su nombre)

Pregunta: ¿Es necesario usar una colección de tipo Pila para gestionar las reservas?

No es ímplicitamente necesario ni recomendable, crear pilas para cada cancha específica sería lo más óptimo y aún así
es ineficiente, sería mejor crear una Queue, con Reservas

Problema 4:
Pregunta: ¿Deberías utilizar un Array para gestionar los libros prestados por cada usuario?
Al poder pedir varios libros a la vez, una Collection o un Array pueden servir para gestionar los libros prestados.

Pregunta: ¿Se requiere persistencia para almacenar la información de los libros disponibles en la biblioteca?
Si, para mantener una estructura de datos homogénea entre la base de datos de la biblioteca cuando se carguen datos

Bonus:
¿Cuál es la diferencia entre clase Abstracta y una Interfaz?
Una clase abstracta funciona como un molde de una Clase donde no puede ser instanciada en sí, pero puede ser utilizada por
otras Clases para formar su estructura. Un interfaz se parece a una Clase abstracta en el sentido de que no se puede acceder
a las funciones dentro de una interfaz de manera directa, sino que muestran el molde de una función para otras Clases, 
que pueden copiarlas y usarlas en el contexto de sus propias variables/características
