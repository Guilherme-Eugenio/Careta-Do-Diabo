using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameControle : MonoBehaviour
{
    private bool jogoPausado;
    private bool comecarJogo;
    private bool carregouFase;

    public static GameControle game;

    public ControleUI ui;

    private void Awake()
    {
        if (game == null)
        {
            game = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        ComecarJogo();
        PausarJogo();
        PrimeiraFase();

        if (Input.GetKeyDown(KeyCode.Escape) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            SceneManager.LoadScene(0);
        }
    }


    private void PausarJogo()
    {
        if (comecarJogo)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                jogoPausado = !jogoPausado;

                ui.pauseGameUI.SetActive(jogoPausado);

                if (jogoPausado)
                {
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }
        }
    }

    private void ComecarJogo()
    {
        if (!comecarJogo)
        {
            Scene menuInicial = SceneManager.GetSceneByBuildIndex(0);

            if (menuInicial.isLoaded && Input.GetKeyDown(KeyCode.Escape))
            {
                comecarJogo = true;

                //SceneManager.LoadScene(1);
                SceneManager.LoadSceneAsync(1);
            }
        }
    }

    private void PrimeiraFase()
    {
        if (comecarJogo)
        {
            if (!carregouFase)
            {
                Scene primeiraFase = SceneManager.GetSceneByBuildIndex(1);
                
                if (primeiraFase.isLoaded)
                {
                    ui = GameObject.FindGameObjectWithTag("ConUI").GetComponent<ControleUI>();
                    carregouFase = true;
                    Debug.Log("AA");
                }
            }
        }

    }

}
