using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public float speed;

    // 내가 2d로 추가.
    Vector3 targetPos;
    Vector3 myPos;
    Vector3 newPos;
    // Start is called before the first frame update
    private void Awake()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 rigidbody2D에 할당
        rigidbody2D = GetComponent<Rigidbody2D>();
        targetPos = GameObject.Find("Player").transform.position;

    }

    private void Start()
    {      
        myPos = transform.position;
        // 2d로 추가.
        newPos = (targetPos - myPos) * 0.01f * speed * Time.deltaTime;

        //rigidbody2D.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }
    // 내가 2d로 수정
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
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            Debug.Log("oh no");
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
