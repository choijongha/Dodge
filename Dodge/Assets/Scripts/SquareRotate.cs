using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SquareRotate : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public float rotateSpeed;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( 0, 0, rotateSpeed * Time.deltaTime );
    }
}
