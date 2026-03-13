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
    public GameObject Boss;
    public List<GameObject> inimigos = new List<GameObject>();
    public static int lado = 1;
    public float limiteDireita = 8.3f;
    public float limiteEsquerda = -8.3f;
    public static int pontuacao = 0;
    public static int pontAnterior = 0;
    public static int pontMaior = 0;
    PlayerControl player;
    float lastChange = 0f;
    float delay = 0.3f;
    int cont;
    public static int vida = 5;
    bool novaFase = false;
    float proximoBoss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerControl>();
        addLista();
        fase();
        cont = 0;
        vida = 5;
        proximoBoss = Time.time + Random.Range(30f, 50f);
    }

    void OnGUI () {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(Screen.width - 200, 20, 200, 100), "Vida: " + vida, style);
        GUI.Label(new Rect(50, 20, 200, 100), "Pontuação: " + pontuacao, style);
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
        float startY = 2.5f;   // altura da primeira linha
        float spacing = 0.1f; // pequeno espaço entre bricks 
        float inimigoWidth = inimigo.GetComponent<SpriteRenderer>().bounds.size.x;
        float screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        for (int i = 0; i < rows; i++)
        {
            int a = Random.Range(0, inimigos.Count);
            float y = startY - i * 1f;
            float x = screenLeft + inimigoWidth / 2 + 1f;
            while (x < screenRight - 2f)
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
            e.transform.position += Vector3.down * 0.2f;
        }
    }

    public void perde(){
        if(pontuacao > pontMaior){
            pontMaior = pontuacao;
        }
        pontAnterior = pontuacao;
        pontuacao = 0;
        vida = 5;
        SceneManager.LoadScene("Fim");
    }

    // Update is called once per frame
    void Update()
    {
        EnemyControl[] enemies = FindObjectsByType<EnemyControl>(FindObjectsSortMode.None);

        if(enemies.Length == 1 && cont == 0){
            EnemyControl.speed += 2.4f;
            cont = 1;
        }
        if(enemies.Length == 0 && !novaFase){
            novaFase = true;
            fase();
            cont = 0;
        }
        if(enemies.Length > 0){
            novaFase = false;
        }
        float maxX = -Mathf.Infinity;
        float minX = Mathf.Infinity;

        foreach (EnemyControl e in enemies)
        {
            float x = e.transform.position.x;
            if (x > maxX) maxX = x;
            if (x < minX) minX = x;
        }

        if ((maxX > limiteDireita || minX < limiteEsquerda) && Time.time - lastChange > delay)
        {
            InverterDirecao();
            lastChange = Time.time;
        }

        if(Time.time >= proximoBoss)
        {
            Instantiate(Boss, new Vector3(-10f, 3.7f, 0), Quaternion.identity);
            proximoBoss = Time.time + Random.Range(30f, 50f);
        }
    }
}
