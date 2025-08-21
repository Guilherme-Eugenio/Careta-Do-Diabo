using UnityEngine;

public sealed class AcoesJogador : MonoBehaviour
{
    [SerializeField] private ControleJogador jogador;

    public void JogadorRecebeDano()
    {
        if (jogador.Vida > 0)
        {
            jogador.Vida--;

            GameControle.game.ui.PerderCoracaoHUD(jogador.Vida);
        }
    }

    public void JogadorCura()
    {
        if (jogador.Vida > 0 && jogador.Vida < 10)
        {
            jogador.Vida++;

            GameControle.game.ui.GanharCoracaoHUD(jogador.Vida);
        }
    }


}
