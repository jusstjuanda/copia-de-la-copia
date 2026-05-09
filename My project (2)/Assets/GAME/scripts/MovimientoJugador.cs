using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovimientoJugador : MonoBehaviour
{
    public CharacterController controlador;
    public float velovidadMovimiento = 2f;
    public float gravedad = -9.81f;
    public float salto = 4f;

    public Transform checkPiso;
    public float distanciaPiso = 0.4f;
    public LayerMask piso;

    bool enPiso;

    Vector3 velocidad;

    // Update is called once per frame
    void Update()
    {
        enPiso = Physics.CheckSphere(checkPiso.position, distanciaPiso, piso);

        if (enPiso && velocidad.y < 0)
        {
            velocidad.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movimiento = transform.right * x + transform.forward * z;

        controlador.Move(movimiento * velovidadMovimiento * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && enPiso)
        {
            velocidad.y = Mathf.Sqrt(salto * -2f * gravedad);
        }

        // Aplicar gravedad
        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad * Time.deltaTime);
    }
}
