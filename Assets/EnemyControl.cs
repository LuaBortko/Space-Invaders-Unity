using UnityEngine;
public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    //private float timer = 0.0f;
    //private float waitTime = 1.0f;
    public static float speed;
    public int vida;
    public int pont;
    public enum TipoInimigo
    {
        Fraco,
        Medio,
        Forte
    }
    public TipoInimigo tipo;
    public GameObject Raio;
    int controle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controle = 0;
        rb2d = GetComponent<Rigidbody2D>();
        speed = 0.3f;
        switch(tipo)
        {
            case TipoInimigo.Fraco:
                vida = 0;
                pont = 10;
                break;

            case TipoInimigo.Medio:
                vida = 1;
                pont = 20;
                break;

            case TipoInimigo.Forte:
                vida = 2;
                pont = 30;
                break;
        }
    }

    void OnTriggerEnter2D (Collider2D coll){
        //Debug.Log("Colidiu com: " + coll.name);
        if (coll.CompareTag("Bullet")){
            Destroy(coll.gameObject);
            if(vida == 0){
                speed += 0.02f;
                GameManager.pontuacao += pont;
                Destroy(gameObject);
            }else{
                vida -= 1;
            }
        }
    }

    void Atirar()
    {
        Instantiate(Raio, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = new Vector2(GameManager.lado * speed, 0);
        var pos = transform.position;  
        if(pos.y < -2.1f && controle == 0){ //-3.2
            controle = 1;
            FindFirstObjectByType<GameManager>().perde();
        }
        
        if(Random.value < 0.00003f)
            {
                Atirar();
            }
        /*timer += Time.deltaTime;
        if (timer >= waitTime){
            timer = 0.0f;
        }*/
    }
}
