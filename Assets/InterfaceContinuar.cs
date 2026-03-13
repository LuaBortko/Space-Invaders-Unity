using UnityEngine;
using UnityEngine.SceneManagement;
public class InterfaceContinuar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnGUI()
    {
        GUIStyle titleStyle = new GUIStyle();
        titleStyle.fontSize = 100;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.normal.textColor = Color.white;

        GUIStyle textStyle = new GUIStyle();
        textStyle.fontSize = 50;
        textStyle.alignment = TextAnchor.MiddleCenter;
        textStyle.normal.textColor = Color.white;

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 30;

        float centerX = Screen.width / 2;
        float centerY = Screen.height / 2;

        // Texto principal

        GUI.Label(new Rect(centerX - 200, centerY - 100, 400, 60), "CONTINUAR?", titleStyle);

        // Texto secundário
        GUI.Label(new Rect(centerX - 200, centerY + 200, 400, 40), "Pontuação Atual: "+ GameManager.pontuacao, textStyle);
        GUI.Label(new Rect(centerX - 200, centerY + 300, 400, 40), "Maior Pontuação Registrada: "+ GameManager.pontMaior, textStyle);

        // Botão
        float buttonWidth = 300;
        float buttonHeight = 80;
        float spacing = 20; // espaço entre os botões

        float totalWidth = buttonWidth * 2 + spacing;
        float startX = centerX - totalWidth / 2;

        if (GUI.Button(new Rect(startX, centerY + 50, buttonWidth, buttonHeight), "SIM", buttonStyle))
        {
            SceneManager.LoadScene("Fase");
        }

        if (GUI.Button(new Rect(startX + buttonWidth + spacing, centerY + 50, buttonWidth, buttonHeight), "NÃO", buttonStyle))
        {
            //FindFirstObjectByType<GameManager>().perde();
            SceneManager.LoadScene("Fim");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
