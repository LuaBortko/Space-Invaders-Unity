using UnityEngine;

public class BossControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public static float speed = 1f;
    public int vida = 3;
    public int pont = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-10f, 3.7f, transform.position.z);
    }

    void OnTriggerEnter2D (Collider2D coll){
        if (coll.CompareTag("Bullet")){
            Destroy(coll.gameObject);
            if(vida == 0){
                GameManager.pontuacao += pont;
                Destroy(gameObject);
            }else{
                vida -= 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = new Vector2(speed, 0);
        var pos = transform.position;
        if(pos.x > 10f){
            Destroy(gameObject);
        }
    }
}
