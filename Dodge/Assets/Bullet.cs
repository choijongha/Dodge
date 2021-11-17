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
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 rigidbody2D에 할당
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
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();
            // 상대방으로부터 PlayerController 컴포넌트를 가져왓다면
            if (playerController != null)
            {
                // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
