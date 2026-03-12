using UnityEngine;
public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Colidiu com " + coll.collider.name);
        if(coll.collider.CompareTag("Wall"))
        {
            FindObjectOfType<GameManager>().InverterDirecao();
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
