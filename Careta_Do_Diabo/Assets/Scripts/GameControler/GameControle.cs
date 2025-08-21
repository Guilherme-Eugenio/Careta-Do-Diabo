using UnityEngine;

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


}
