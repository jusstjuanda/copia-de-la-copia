using Unity.Mathematics;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float speed = 60f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Vertical") * speed;
        float y = Input.GetAxis("Horizontal") * speed;

        Quaternion rotx = Quaternion.AngleAxis(x * Time.deltaTime, Vector3.right);
        Quaternion roty = Quaternion.AngleAxis(y * Time.deltaTime, Vector3.up);

        transform.rotation = rotx * roty * transform.rotation;

    }
}
