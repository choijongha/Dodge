using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            // 위쪽 방향키 입력이 감지된 경우 y 방향 힘 주기
            playerRigidbody2D.AddForce(new Vector2(0, speed));
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            // 아래 방향키 입력이 감지된 경우 -y 방향 힘 주기
            playerRigidbody2D.AddForce(new Vector2(0, -speed)); ;
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            // 우측 방향키 입력이 감지된 경우 x 방향 힘 주기
            playerRigidbody2D.AddForce(new Vector2(speed, 0)); ;
        }

        if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // 왼 방향키 입력이 감지된 경우 -x 방향 힘 주기
            playerRigidbody2D.AddForce(new Vector2(-speed, 0)); ;
        }
    }
}
