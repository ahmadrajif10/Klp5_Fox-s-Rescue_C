using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // objek yang diikuti (misalnya Rubah)
    public Vector3 offset = new Vector3(0, 0, -10); // jarak kamera dari target
    public float smoothSpeed = 5f;   // kehalusan gerakan kamera

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothPosition;
        }
    }
}
