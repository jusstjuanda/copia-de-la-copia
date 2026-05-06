using UnityEngine;

public class MovimientoQ : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;
    public Animator anima;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 fowardMovement = transform.forward * moveVertical * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + fowardMovement);
        
        float rotation = moveHorizontal * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turn = Quaternion.AngleAxis(rotation, Vector3.up);

        rb.MoveRotation(rb.rotation * turn);

        float walkVal =  Mathf.Abs(moveVertical);
        anima.SetFloat("Walk", walkVal);

    }
}
