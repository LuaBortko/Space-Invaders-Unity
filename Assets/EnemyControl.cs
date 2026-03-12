using UnityEngine;
public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    //private float timer = 0.0f;
    //private float waitTime = 1.0f;
    private float speed = 0.5f;
    public int vida;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        vida = 0;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("Wall"))
        {
            FindFirstObjectByType<GameManager>().InverterDirecao();
        }

    }

    void OnTriggerEnter2D (Collider2D coll){
        if (coll.CompareTag("Bullet")){
            
            Destroy(coll.gameObject);
            if(vida == 0){
                Destroy(gameObject);
            }else{
                vida -= 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = new Vector2(GameManager.lado * speed, 0);
        /*timer += Time.deltaTime;
        if (timer >= waitTime){
            ChangeState();
            timer = 0.0f;
        }*/
    }
}
