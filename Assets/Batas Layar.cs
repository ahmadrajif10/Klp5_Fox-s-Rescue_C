using UnityEngine;

public class BatasLayar : MonoBehaviour
{
    private float batasKiri;
    private float batasKanan;

    [Header("Pengaturan Batas")]
    public float padding = 0.7f;        // jarak aman dalam layar
    public float lebarEkstra = 2f;      // tambahan batas di luar layar

    void Start()
    {
        float jarakZ = transform.position.z - Camera.main.transform.position.z;
        Vector3 kiri = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, jarakZ));
        Vector3 kanan = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, jarakZ));

        batasKiri = kiri.x + padding - lebarEkstra;
        batasKanan = kanan.x - padding + lebarEkstra;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, batasKiri, batasKanan);
        transform.position = pos;
    }
}
