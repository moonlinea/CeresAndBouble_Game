using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls; // Oyuncu kontrollerini tutmak i�in PlayerControls nesnesi
   
    int PanelIndex; // Panel indeksi (muhtemelen ba�ka bir yerde kullan�l�yor)
    float direction = 0; // Yatay y�nde oyuncunun hareket y�n� (-1: sola, 0: hareketsiz, 1: sa�a)
    [SerializeField] private float speed = 400; // Oyuncunun hareket h�z�
    [SerializeField] private bool isFacingRight = true; // Oyuncunun sa�a do�ru d�n�k olup olmad���n� belirten bir bayrak

    [SerializeField] private Rigidbody2D playerRB; // Oyuncunun Rigidbody bile�eni
    [SerializeField] private Animator animator; // Oyuncunun Animator bile�eni

    private void Awake()
    {
        controls = new PlayerControls(); // PlayerControls nesnesini olu�tur
        controls.Enable(); // Oyuncu kontrollerini etkinle�tir

        // Land alt�nda yer alan Move eylemi ger�ekle�ti�inde (hareket giri�i),
        // yatay y�nde hareket y�n�n� g�ncelle
        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
        
    }

    void FixedUpdate()
    {
        // Hareket y�n�ne g�re oyuncunun h�z�n� g�ncelle
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);

        // Animator'a oyuncunun h�z de�erini vererek hareket animasyonunu kontrol et
        animator.SetFloat("speed", Mathf.Abs(direction));

        // Oyuncu sa�a d�n�kse ve y�n sola do�ru ise veya
        // oyuncu sola d�n�kse ve y�n sa�a do�ru ise, oyuncuyu �evir
        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();

    }

    void Flip()
    {
        // Oyuncunun y�n�n� tersine �evir
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }



}
