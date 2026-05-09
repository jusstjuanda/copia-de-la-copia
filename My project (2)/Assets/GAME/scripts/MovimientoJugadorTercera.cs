using UnityEngine;

public class MovimientoJugadorTercera : MonoBehaviour
{
    private CharacterController controller;

    public static float velocidadMovimiento = 2f;
    public float velocidadRotacion = 10f;

    public float x, z;

    [SerializeField] 
    private Camera followCamera;

    private Vector3 velocidadJugador;
    public Transform checkPiso;
    public float distanciaPiso = 0.4f;
    public LayerMask piso;
    public float gravedad = -9.81f;
    public float salto = 1f;

    bool enPiso;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        enPiso = Physics.CheckSphere(checkPiso.position, distanciaPiso, piso);

        if (enPiso && velocidadJugador.y < 0)
        {
            velocidadJugador.y = -2f;
        }

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Vector3 moveInput= Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(x, 0, z);

        Vector3 moveDireccion = moveInput.normalized;

        controller.Move(moveDireccion * velocidadMovimiento * Time.deltaTime);

        if(moveDireccion != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(moveDireccion, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, velocidadRotacion * Time.deltaTime);
        }
        if(Input.GetButtonDown("Jump") && enPiso)
        {
            velocidadJugador.y = Mathf.Sqrt(salto * -2f * gravedad);
        }
        // Aplicar gravedad
        velocidadJugador.y += gravedad * Time.deltaTime;
        controller.Move(velocidadJugador * Time.deltaTime);
    }
}
