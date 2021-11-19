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
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        // Vector2 �ӵ��� (xSpeed, ySpeed)�� ����
        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);

        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody2D.velocity = newVelocity;
    }
    public void Die()
    {
        // �ڽ��� ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
