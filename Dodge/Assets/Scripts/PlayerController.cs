using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody2D;
    public float speed = 8f;
    // Start is called before the first frame update

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        // Vector2 속도를 (xSpeed, ySpeed)로 생성
        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);

        // 리지드바디의 속도를 newVelocity 할당
        playerRigidbody2D.velocity = newVelocity;
    }
    public void Die()
    {
        // 자신의 게임 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}
