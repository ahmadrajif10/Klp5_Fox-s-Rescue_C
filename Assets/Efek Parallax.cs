using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxSpeed = 0.5f;     // Semakin kecil = semakin jauh
    private Transform cam;                 // Kamera utama
    private Vector3 prevCamPos;            // Posisi kamera sebelumnya

    void Start()
    {
        cam = Camera.main.transform;
        prevCamPos = cam.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cam.position - prevCamPos;
        transform.position += new Vector3(delta.x * parallaxSpeed, delta.y * parallaxSpeed, 0);
        prevCamPos = cam.position;
    }
}
