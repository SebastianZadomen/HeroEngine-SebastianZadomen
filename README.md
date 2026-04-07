# HeroEngine-SebastianZadomen
## Chapter 1 : 
En este primer capítulo, el objetivo ha sido construir la estructura base y la jerarquía de clases para los héroes del sistema.

Para cumplir con lo que se pedía, implementé una clase base abstracta de la que heredan los tres tipos de héroes:

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