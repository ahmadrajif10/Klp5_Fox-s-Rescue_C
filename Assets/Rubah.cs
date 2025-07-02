using UnityEngine;

public class Rubah : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gayaTerbang = 4f;
    public int batasTerbang = 2;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private Vector3 initialScale;
    private int jumlahTerbang = 0;

    // Untuk ikut pergerakan platform
    private Vector3 lastPlatformPos;
    private bool diPlatform = false;
    private Transform platformTransform;

    // Simpan posisi awal
    private Vector3 posisiAwal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        initialScale = transform.localScale;
        posisiAwal = transform.position; // simpan posisi awal

        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void Update()
    {
        // Gerakan horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Balik arah sprite
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(initialScale.x), initialScale.y, initialScale.z);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(initialScale.x), initialScale.y, initialScale.z);
        }

        // Terbang maksimal 2x
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumlahTerbang < batasTerbang)
        {
            rb.AddForce(Vector2.up * gayaTerbang, ForceMode2D.Impulse);
            jumlahTerbang++;
        }

        // Animasi Attack saat tombol A ditekan
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Attack");
        }

        // Ikut gerak platform jika di atasnya
        if (diPlatform && platformTransform != null)
        {
            Vector3 delta = platformTransform.position - lastPlatformPos;
            transform.position += delta;
            lastPlatformPos = platformTransform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jumlah terbang jika Rubah mendarat dari atas
        if (collision.contacts[0].normal.y > 0.5f)
        {
            jumlahTerbang = 0;
        }

        // Deteksi jika menginjak platform
        if (collision.gameObject.name == "Ground Melayang (4)" || collision.gameObject.name == "Ground Melayang (1)")
        {
            platformTransform = collision.transform;
            lastPlatformPos = platformTransform.position;
            diPlatform = true;
        }

        // Jika menabrak Beruang
        if (collision.gameObject.name == "Beruang" || collision.gameObject.name == "Beruang (1)")
        {
            transform.position = posisiAwal;
            rb.velocity = Vector2.zero; // reset kecepatan agar tidak terpental
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground Melayang (4)" || collision.gameObject.name == "Ground Melayang (1)")
        {
            diPlatform = false;
            platformTransform = null;
        }
    }
}
