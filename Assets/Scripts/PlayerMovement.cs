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
        // Klavye giriþinden hareket vektörünü al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket vektörünü oluþtur
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Hareket vektörünü dünya koordinatlarýna dönüþtür ve hareket hýzýný ekleyerek pozisyonu güncelle
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Yürüme animasyonunu kontrol et
        bool isMoving = moveDirection.magnitude > 0;
        animator.SetBool("isMoving", isMoving);
    }
}
