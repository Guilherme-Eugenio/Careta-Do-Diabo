using System.Collections;
using UnityEngine;

public sealed class AcoesJogador : MonoBehaviour
{
    [SerializeField] private ControleJogador jogador;

    public void JogadorRecebeDano()
    {
        StartCoroutine(ControleDano());
    }

    private IEnumerator ControleDano()
    {
        if (jogador.Vida > 0)
        {
            jogador.Vida--;

            jogador.Anim.SetBool(HashCodesAnimator.danoAnim, true);

            GameControle.game.ui.PerderCoracaoHUD(jogador.Vida);

            yield return new WaitForSeconds(.65f);

            jogador.Anim.SetBool(HashCodesAnimator.danoAnim, false);
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
