using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class ControleUI : MonoBehaviour
{
    public GameObject pauseGameUI;

    // 0 - coracao cheio, 1 - coracao pela metade, 2 - coracao vazio
    [SerializeField] private Sprite[] coracaoIma = new Sprite[3];

    [SerializeField] private Image[] coracoesAtual = new Image[5];

    [SerializeField] private TextMeshProUGUI textoTeste;

    private int indexCoracao;

    public void PerderCoracaoHUD(int vida) // Atualiaza os corações na HUD do jogado fazendo ele perder
    {
        if (indexCoracao < coracoesAtual.Length)
        {
            textoTeste.text = string.Concat("Vida Jogador: ", vida.ToString());

            if (coracoesAtual[indexCoracao].sprite == coracaoIma[0])
            {
                coracoesAtual[indexCoracao].sprite = coracaoIma[1];
            }
            else if (coracoesAtual[indexCoracao].sprite == coracaoIma[1])
            {
                coracoesAtual[indexCoracao].sprite = coracaoIma[2];

                indexCoracao++;
            }
        }
    }

    public void GanharCoracaoHUD(int vida)
    {
        if (indexCoracao > 0)
        {
            textoTeste.text = string.Concat("Vida Jogador: ", vida.ToString());

            if (coracoesAtual[indexCoracao].sprite == coracaoIma[2])
            {
                coracoesAtual[indexCoracao].sprite = coracaoIma[1];
            }
            else if (coracoesAtual[indexCoracao].sprite == coracaoIma[1])
            {
                coracoesAtual[indexCoracao].sprite = coracaoIma[0];

                indexCoracao--;
            }
        }
        else if (indexCoracao == 0)
        {
            textoTeste.text = string.Concat("Vida Jogador: ", vida.ToString());

            if (coracoesAtual[indexCoracao].sprite == coracaoIma[2])
            {
                coracoesAtual[indexCoracao].sprite = coracaoIma[1];
            }
            else if (coracoesAtual[indexCoracao].sprite == coracaoIma[1])
            {
                coracoesAtual[indexCoracao].sprite = coracaoIma[0];
            }
        }
    }
}
