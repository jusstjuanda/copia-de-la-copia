using UnityEngine;

public class Slerp : MonoBehaviour
{

    public Transform target;
    public float orbitSpeed = 10f;
    public float distance = 10f;
    public float selfRotationSpeed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = target.position + new Vector3(distance, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);

        Quaternion axisRotation = Quaternion.Euler(0, selfRotationSpeed * Time.deltaTime, 0);

        
        transform.rotation = transform.rotation * axisRotation;
    }
}
