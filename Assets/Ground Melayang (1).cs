using UnityEngine;

public class GroundMelayang_1 : MonoBehaviour
{
    public float amplitude = 4f;  // Jarak gerak atas-bawah
    public float speed = 1.3f;      // Kecepatan gerakan

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector3(0f, yOffset, 0f);
    }
}
