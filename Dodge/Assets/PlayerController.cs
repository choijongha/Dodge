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
            // ���� ����Ű �Է��� ������ ��� y ���� �� �ֱ�
            playerRigidbody2D.AddForce(new Vector2(0, speed));
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            // �Ʒ� ����Ű �Է��� ������ ��� -y ���� �� �ֱ�
            playerRigidbody2D.AddForce(new Vector2(0, -speed)); ;
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ��� x ���� �� �ֱ�
            playerRigidbody2D.AddForce(new Vector2(speed, 0)); ;
        }

        if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // �� ����Ű �Է��� ������ ��� -x ���� �� �ֱ�
            playerRigidbody2D.AddForce(new Vector2(-speed, 0)); ;
        }
    }
}
