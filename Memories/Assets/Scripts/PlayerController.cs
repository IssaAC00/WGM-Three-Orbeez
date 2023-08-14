using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EstadoPersonaje
{
    Normal,
    Transformado
}

public class PlayerController : MonoBehaviour
{


    public float speed; //velocidad del personaje
    public float jumpForce; //capacidad de salto del personaje
    bool p_isGrounded;
    public EstadoPersonaje estado; //estado de personaje: monstruo - persona

    public GameObject modeloNormal; //modelo del player en estado normal
    public GameObject modeloTransformado; //modelo del plater en estado transformado
    public GameObject modeloActual; //modelo actual
    
    private Rigidbody rb;

    public int cantJumps;

    private AudioSource salto;




    // Start is called before the first frame update
    void Start()
    {
        //se inicializan ambos modelos para el player como inexistentes
        modeloNormal.SetActive(false);
        modeloTransformado.SetActive(false);

        rb = GetComponent<Rigidbody>(); //rb
        estado = EstadoPersonaje.Normal; //estadoNormal


        //se inicializa al jugador en estado normal con el modelo asignado
        modeloActual = modeloNormal; // Modelo inicial
        modeloActual.SetActive(true);

        // sonido de salto

        salto = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(estado)
        {
            case EstadoPersonaje.Normal:
                //se ponen todas las caracteristicas y poderes el player en modo normal
                speed = 10;
                jumpForce = 6;
                cantJumps = 2;
                break;
            case EstadoPersonaje.Transformado:
                //se ponen todas las caracteristicas y poderes del player en modo transformado
                speed = 5;
                jumpForce = 11;
                cantJumps = 1;
                break;
        }

        //MOVIMIENTO EN X - Z
        //obtener que boton estoy presionando en mi teclado :P
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * Time.deltaTime * speed;
        // Calcula la posición potencial después del movimiento
        Vector3 newPosition = transform.position + movement;

        transform.Translate(movement);
    

        // Rotación del modelo según la dirección de movimiento
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            modeloActual.transform.rotation = Quaternion.Lerp(modeloActual.transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        //SALTO

        if (Input.GetButtonDown("Jump") && p_isGrounded == true )
        {
            p_isGrounded = false;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            salto.Play();
        }
        

        /*if (Input.GetKeyDown(KeyCode.F))
        {
            if(estado == EstadoPersonaje.Normal)
            {
                CambiarEstado(EstadoPersonaje.Transformado);
            }
            else
            {
                CambiarEstado(EstadoPersonaje.Normal);
            }
        }*/
    }
    
    private void CambiarModelo()
    {
        if (modeloActual != null)
        {
            modeloActual.SetActive(false);
        }

        if (estado == EstadoPersonaje.Normal)
        {
            modeloActual = modeloNormal;
        }
        else if (estado == EstadoPersonaje.Transformado)
        {
            modeloActual = modeloTransformado;
        }

        if (modeloActual != null)
        {
            modeloActual.SetActive(true);
        }
    }
    public void CambiarEstado(EstadoPersonaje estadoP) //cambiar el estado del personaje
    {
        estado = estadoP;
        CambiarModelo();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            p_isGrounded = true;
        }
    }

}
