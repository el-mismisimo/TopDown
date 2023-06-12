using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject proyectilPrefab; // Prefab del proyectil
    public Transform puntoDisparo; // Punto de origen del proyectil
    public float fuerzaDisparo = 10f; // Fuerza con la que se dispara el proyectil

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DispararProyectil();
        }
    }

    void DispararProyectil()
    {
        // Crear una instancia del proyectil
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Obtener el componente Rigidbody del proyectil
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();

        // Obtener la dirección de disparo basada en la entrada del jugador
        Vector3 direccionDisparo = ObtenerDireccionDisparo();

        // Aplicar la fuerza al proyectil en la dirección de disparo
        rb.AddForce(direccionDisparo * fuerzaDisparo, ForceMode.Impulse);
    }

    Vector3 ObtenerDireccionDisparo()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Determinar la dirección de disparo en función de las entradas de movimiento del jugador
        if (vertical > 0)
        {
            return Vector3.forward;
        }
        else if (vertical < 0)
        {
            return Vector3.back;
        }
        else if (horizontal > 0)
        {
            return Vector3.right;
        }
        else if (horizontal < 0)
        {
            return Vector3.left;
        }
        else
        {
            // Si no hay entrada de movimiento, disparar hacia adelante por defecto
            return Vector3.forward;
        }
    }
}
