using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Movement : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");  // Eje X
        float moveY = Input.GetAxis("Vertical");    // Eje Y

        // Calcular el vector de movimiento
        Vector3 movement = new Vector3(moveX, 0f, moveY) * speed * Time.deltaTime;

        // Mover el objeto en función del vector de movimiento
        transform.Translate(movement);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene("Victoria");
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Derrota");
        }
    }
   
}

