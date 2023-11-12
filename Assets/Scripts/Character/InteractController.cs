using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class  Interactable : MonoBehaviour
{
    public virtual void Interact()
    {

    }
}

public class InteractController : MonoBehaviour
{
    PlayerController playerController;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] float umbralInteraccion = 1.2f;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Check();

        if (Input.GetMouseButtonDown(1) && GetDistanceInteract())
        {
            Interact();
        }
    }

    public bool GetDistanceInteract()
    {

        // Obtener la posición del personaje
        Vector3 posicionPersonaje = transform.position;

        // Obtener la posición del ratón en el mundo
        Vector3 posicionRaton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicionRaton.z = 0; // Asegúrate de que la coordenada Z sea 0 (en el plano del juego)

        // Calcular la distancia entre el personaje y el ratón
        float distancia = Vector3.Distance(posicionPersonaje, posicionRaton);

        // Si la distancia es menor a un cierto umbral, entonces el objeto puede ser interactuado
        //float umbralInteraccion = 0.65f; // Ajusta este valor según tus necesidades

        return distancia < umbralInteraccion;
    }


    /* private void Check()
     {
         Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;

         Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

         foreach (Collider2D c in colliders)
         {
             Interactable hit = c.GetComponent<Interactable>();
             if (hit != null)
             {
                 highlightController.Highlight(hit.gameObject);
                 return;
             }
         }

         highlightController.Hide();
     }*/

    private void Interact()
    {
        Vector2 position = rgbd2d.position + playerController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact();
                break;
            }
        }
    }
}
