using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ź���� ���� ������
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    private Vector2 target; // �߻��� ���
    private float spawnRate; // ���� �ֱ�, ���� ź���� ������ ������ ��ٸ� �ð�.
    private float timeAfterSpawn; //  �ֱ� ���� �������� ���� �ð�

    private GameObject player;
    private float speed;
    private void Awake()
    {
        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        //target = FindObjectOfType<PlayerController>().transform;
        player = GameObject.Find("Player");
        target = new Vector2(player.transform.position.x, player.transform.position.y);
        speed = bulletPrefab.GetComponent<Bullet>().speed;
    }   
    // Start is called before the first frame update
    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // ź�� ���� ������ spawnRateMin �� spawnRateMax ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        // timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            // ������ �ð��� ����
            timeAfterSpawn = 0f;

            // bulletPrefab�� ��������
            // transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // ������ bullet ���� ������Ʈ�� ���� ������ target �� ���ϵ��� ȸ��
            // ���� ������ target ���� ���ؼ� y -90 90�� �Ǿ����.
            //bullet.transform.LookAt(target);
            //bullet.transform.position = Vector2.MoveTowards(transform.position, target, speed);


            // ������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
