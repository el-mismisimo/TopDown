using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour

{
    public float tiempoVida = 3f; // Tiempo de vida del proyectil en segundos

    void Start()
    {
        // Destruir el proyectil después de un tiempo determinado
        Destroy(gameObject, tiempoVida);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
