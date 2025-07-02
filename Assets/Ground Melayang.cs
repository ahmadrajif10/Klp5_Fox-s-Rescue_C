using UnityEngine;

public class GroundMelayang : MonoBehaviour
{
    public float jarakGerak = 0.6f;      // seberapa jauh dia bergerak ke kiri-kanan
    public float kecepatan = 0.5f;       // kecepatan gerak
    private Vector3 posisiAwal;

    void Start()
    {
        posisiAwal = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * kecepatan) * jarakGerak;
        transform.position = new Vector3(posisiAwal.x + offset, posisiAwal.y, posisiAwal.z);
    }
}
