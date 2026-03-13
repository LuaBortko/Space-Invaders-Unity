using UnityEngine;

public class Bunker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D coll){
        if (coll.CompareTag("Bullet") || coll.CompareTag("Raio")){
            Destroy(coll.gameObject); 
            Destroy(gameObject);      
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
