using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls; // Oyuncu kontrollerini tutmak için PlayerControls nesnesi
   
    int PanelIndex; // Panel indeksi (muhtemelen baþka bir yerde kullanýlýyor)
    float direction = 0; // Yatay yönde oyuncunun hareket yönü (-1: sola, 0: hareketsiz, 1: saða)
    [SerializeField] private float speed = 400; // Oyuncunun hareket hýzý
    [SerializeField] private bool isFacingRight = true; // Oyuncunun saða doðru dönük olup olmadýðýný belirten bir bayrak

    [SerializeField] private Rigidbody2D playerRB; // Oyuncunun Rigidbody bileþeni
    [SerializeField] private Animator animator; // Oyuncunun Animator bileþeni

    private void Awake()
    {
        controls = new PlayerControls(); // PlayerControls nesnesini oluþtur
        controls.Enable(); // Oyuncu kontrollerini etkinleþtir

        // Land altýnda yer alan Move eylemi gerçekleþtiðinde (hareket giriþi),
        // yatay yönde hareket yönünü güncelle
        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
        
    }

    void FixedUpdate()
    {
        // Hareket yönüne göre oyuncunun hýzýný güncelle
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);

        // Animator'a oyuncunun hýz deðerini vererek hareket animasyonunu kontrol et
        animator.SetFloat("speed", Mathf.Abs(direction));

        // Oyuncu saða dönükse ve yön sola doðru ise veya
        // oyuncu sola dönükse ve yön saða doðru ise, oyuncuyu çevir
        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();

    }

    void Flip()
    {
        // Oyuncunun yönünü tersine çevir
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }



}
