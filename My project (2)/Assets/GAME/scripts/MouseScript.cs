using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public float mouseSensitivity = 10f;

    public Transform cuerpoJugador;

    float xRotation = 0f;
    void Start()
    {
        //bloqueamos la posición del mouse y lo desaparecemos de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //capturamos los valores de movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //rotamos nuestra camra en el eje X, se usa el - para evitar lo conocido como inverted axis
        xRotation -= mouseY;

        //restriccion de rotacion de la camara entre 90 y -90 grados
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //asignamos los valores resultantes de rotacion a la camara al objeto como tal
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        cuerpoJugador.rotation *= Quaternion.Euler(0f, mouseX, 0f);


    }
}
