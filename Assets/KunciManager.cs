using UnityEngine;

public class KunciManager : MonoBehaviour
{
    public static KunciManager instance;

    public int totalKunci = 10;
    private int kunciTerkumpul = 0;

    public GameObject sangkar;
    public float naikSejauh = 2f;
    public float kecepatanNaik = 2f;

    public Camera mainCamera;
    public float cameraMoveSpeed = 2f;

    private bool sangkarNaik = false;
    private Vector3 targetPos;

    private bool kameraMenujuSangkar = false;
    private Vector3 cameraTargetPos;

    void Awake()
    {
        instance = this;
    }

    public void TambahKunci()
    {
        kunciTerkumpul++;

        if (kunciTerkumpul >= totalKunci && sangkar != null)
        {
            // Gerakkan Sangkar naik
            targetPos = sangkar.transform.position + Vector3.up * naikSejauh;
            sangkarNaik = true;

            // Kamera pindah ke Sangkar
            if (mainCamera != null)
            {
                kameraMenujuSangkar = true;
                cameraTargetPos = new Vector3(
                    sangkar.transform.position.x,
                    sangkar.transform.position.y,
                    mainCamera.transform.position.z
                );

                // Matikan CameraFollow sementara
                if (mainCamera.GetComponent<CameraFollow>() != null)
                {
                    mainCamera.GetComponent<CameraFollow>().enabled = false;
                }
            }
        }
    }

    void Update()
    {
        // Gerakkan Sangkar ke atas
        if (sangkarNaik && sangkar != null)
        {
            sangkar.transform.position = Vector3.MoveTowards(
                sangkar.transform.position,
                targetPos,
                kecepatanNaik * Time.deltaTime
            );

            if (Vector3.Distance(sangkar.transform.position, targetPos) < 0.01f)
            {
                sangkarNaik = false;
            }
        }

        // Gerakkan kamera ke Sangkar
        if (kameraMenujuSangkar && mainCamera != null)
        {
            mainCamera.transform.position = Vector3.MoveTowards(
                mainCamera.transform.position,
                cameraTargetPos,
                cameraMoveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(mainCamera.transform.position, cameraTargetPos) < 0.05f)
            {
                kameraMenujuSangkar = false;

                // Aktifkan kembali CameraFollow
                if (mainCamera.GetComponent<CameraFollow>() != null)
                {
                    mainCamera.GetComponent<CameraFollow>().enabled = true;
                }
            }
        }
    }
}
