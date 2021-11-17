using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public float speed;

    Vector3 targetPos;
    Vector3 myPos;

    Vector3 newPos;
    // Start is called before the first frame update
    private void Awake()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� rigidbody2D�� �Ҵ�
        rigidbody2D = GetComponent<Rigidbody2D>();
        targetPos = GameObject.Find("Player").transform.position;
        myPos = transform.position;
    }

    private void Start()
    {
        newPos = (targetPos - myPos) * 0.01f;
        rigidbody2D.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        transform.position = transform.position + newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();
            // �������κ��� PlayerController ������Ʈ�� �����Ӵٸ�
            if (playerController != null)
            {
                // ���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.Die();
            }
        }
    }
}
