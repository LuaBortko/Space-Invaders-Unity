using UnityEngine;

public class RaioControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = new Vector2(0, -speed);
        var pos = transform.position; 
        if(pos.y < -5.3f){
            Destroy(gameObject);
        }
    }


}
