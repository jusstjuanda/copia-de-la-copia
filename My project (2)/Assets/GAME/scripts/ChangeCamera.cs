using Unity.Cinemachine;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{

    public CinemachineCamera activeCam;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 10;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 0;
        }
    }


}
