# HeroEngine-SebastianZadomen
## Chapter 1 : 
En este primer capítulo, el objetivo ha sido construir la estructura base y la jerarquía de clases para los heroes del sistema.

Para cumplir con lo que se pedía, implementé una clase base abstracta de la que heredan los tres tipos de heroes:

- El Warrior, al que le añadí una protección de armadura que reduce el daño que recibe en combate y este va aumentando segun el nivel.

- El Mage, que funciona con un sistema de maná que se consume al lanzar hechizos y tiene un atributo de nivel arcano que aumenta el daño.

- El Rogue, donde programé un multiplicador de daño furtivo que depende del número de dagas que lleva ocultas para hacer mas daño.

### Juego de pruebas - Caso Normal 

| Heroe   | inputName | inputLevel | validateName | validateLevel | result |
| ------- | --------- | ---------- | ------------ | ------------- | ------ |
| Warrior | Garen     | 10         | true         | true          | **true** |
| Mage    | Lux    | 5          | true         | true          | **true** |
| Rogue   | Talon   | 3          | true         | true          | **true** |

### Juego de pruebas - Caso Límite 


| Heroe   | inputName | inputLevel | Restricción Límite | validate | result |
| ------- | --------- | ---------- | ------------------ | -------- | ------ |
| Warrior | A         | o         | Nivel mínimo (0)   | true     | **true** |
| Rogue   | V         | 5          | 0-5 Dagas ocultas    | true     | **true** |

### Juego de pruebas - Caso Error 

| Heroe   | inputName | inputLevel | validateName | validateLevel | result |
| ------- | --------- | ---------- | ------------ | ------------- | ------ |
| Mage    |  | 10         | **false** | true          | **false**|
| Warrior | Darius     | **0** | true         | **false** | **false**|
| Rogue   | Akali   | **-5** | true         | **false** | **false**|

## Chapter 2 : El Arsenal — Habilidades y Enumeradores
En este capitulo nos centramos en las habilidades que tendrian nuestros heroes , para esto creamos una clase base llamada Skills, de la cual heredan las subclases AttackSkills, SupportSkills y DefenseSkills:

* AttackSkills: Se encarga de hacer daño a otro héroe o enemigo pasándolo como objetivo a la función AbilityActivation.

* SupportSkills:Se encarga de curarnos a nosotros mismos.

* DefenseSkills:Se encarga de subir la defensa del héroe que la use (después de contrarrestar un ataque, esta defensa baja a 0).

Tambien implementamos un sistema de guardado de habilidades  el cual recorre el inventario del héroe iteración por iteración para evitar duplicados y encontrar espacios libres:

### Juego de pruebas - Caso Normal
Se intenta añadir Tajo pesado de espada al personaje :  

| i | Skills[i] | validateDuplicate | validateSpace (Es null) | result |
| :---: | :--- | :---: | :---: | :--- |
| 0 | Tajo debil | true (diferente) | false | Sigue iterando |
| 1 | Escudo | true (diferente) | false | Sigue iterando |
| 2 | null | true (no aplica) | **true** | Se guarda en Skills[2] |
| 3 | null | - | - | No se ejecuta (rompe bucle) |
| - | - | - | - | true (Equipado) |

### Juego de pruebas - Caso Límite
Se intenta añadir Corte Sangriento al personaje :  

| i | Skills[i] | validateDuplicate | validateSpace (Es null) | result |
| :---: | :--- | :---: | :---: | :--- |
| 0 | Tajo | true | false | Sigue iterando |
| 1 | Escudo | true | false | Sigue iterando |
| 2 | Curación| true | false | Sigue iterando |
| 3 | null | true | true | Se guarda en Skills[3] |
| - | - | - | - | **true (Equipado)** |

### Juego de pruebas - Caso Error
Añadimos Golpe al personaje :

| i | Skills[i] | validateDuplicate | validateSpace (Es null) | result |
| :---: | :--- | :---: | :---: | :--- |
| 0 | Escudo | true (diferente) | - | Sigue iterando |
| 1 | Golpe | **false (¡Iguales!)** | - | Error: Cancela operación |
| 2 | null | - | - | No se ejecutarse |
| 3 | null | - | - | No se ejecutarse |
| - | - | - | - | **false (Return)** |