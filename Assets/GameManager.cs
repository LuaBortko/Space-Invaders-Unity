using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public GameObject inimigo;
    public GameObject inimigo2;
    public GameObject inimigo3;
    public GameObject inimigo4;
    public GameObject inimigo5;
    public GameObject inimigo6;
    public GameObject inimigo7;
    public GameObject inimigo8;
    public GameObject inimigo9;
    public GameObject inimigo10;
    public List<GameObject> inimigos = new List<GameObject>();
    public static int lado = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        addLista();
        fase();
    }

    void addLista(){
        inimigos.Add(inimigo);
        inimigos.Add(inimigo2);
        inimigos.Add(inimigo3);
        inimigos.Add(inimigo4);
        inimigos.Add(inimigo5);
        inimigos.Add(inimigo6);
        inimigos.Add(inimigo7);
        inimigos.Add(inimigo8);
        inimigos.Add(inimigo9);
        inimigos.Add(inimigo10);
    }

    void fase(){
        int rows = 5;
        float startY = 4f;   // altura da primeira linha
        float spacing = 0.1f; // pequeno espaço entre bricks 
        float inimigoWidth = inimigo.GetComponent<SpriteRenderer>().bounds.size.x;
        float screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        for (int i = 0; i < rows; i++)
        {
            int a = Random.Range(0, inimigos.Count);
            float y = startY - i * 1f;
            float x = screenLeft + inimigoWidth / 2 + 1f;
            while (x < screenRight - 4f)
            {
                Instantiate(inimigos[a], new Vector3(x, y, 0), Quaternion.identity);
                x += inimigoWidth + spacing;
            }
        }
    }

    public void InverterDirecao()
    {
        lado *= -1;
        EnemyControl[] enemies = FindObjectsByType<EnemyControl>(FindObjectsSortMode.None);
        foreach (EnemyControl e in enemies)
        {
            e.transform.position += Vector3.down * 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
