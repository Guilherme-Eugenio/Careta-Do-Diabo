using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameControle : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

}
