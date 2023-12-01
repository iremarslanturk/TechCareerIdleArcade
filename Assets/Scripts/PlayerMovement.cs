using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Klavye giri�inden hareket vekt�r�n� al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket vekt�r�n� olu�tur
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Hareket vekt�r�n� d�nya koordinatlar�na d�n��t�r ve hareket h�z�n� ekleyerek pozisyonu g�ncelle
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Y�r�me animasyonunu kontrol et
        bool isMoving = moveDirection.magnitude > 0;
        animator.SetBool("isMoving", isMoving);
    }
}
