using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public float speed;

    // ���� 2d�� �߰�.
    Vector3 targetPos;
    Vector3 myPos;
    Vector3 newPos;
    // Start is called before the first frame update
    private void Awake()
    {
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� rigidbody2D�� �Ҵ�
        rigidbody2D = GetComponent<Rigidbody2D>();
        targetPos = GameObject.Find("Player").transform.position;

    }

    private void Start()
    {      
        myPos = transform.position;
        // 2d�� �߰�.
        newPos = (targetPos - myPos) * 0.01f * speed * Time.deltaTime;

        //rigidbody2D.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }
    // ���� 2d�� ����
    private void Update()
    {
        transform.position = transform.position + newPos ;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        // �浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "Player")
        {
            Debug.Log("oh no");
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
