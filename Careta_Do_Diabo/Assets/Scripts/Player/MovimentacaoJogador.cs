using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ControleJogador))]
public sealed class MovimentacaoJogador : MonoBehaviour
{
    [SerializeField] private ControleJogador jogador;

    void FixedUpdate()
    {
        DetectorChao();
        Movimentacao();
        Avanco();
        Pulo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jogador.EstaPulando)
        {
            jogador.PodePular = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !jogador.Avanco)
        {
            jogador.PodeAvancar = true;
        }
    }

    private void Movimentacao()
    {
        if (!jogador.Avanco && !jogador.JogadorAtacando)
        {
            float dirX = Input.GetAxisRaw("Horizontal");

            jogador.Rig.linearVelocityX = dirX * jogador.Velocidade;

            if (dirX > 0)
            {
                jogador.Spr.flipX = false;

                jogador.Anim.SetBool(HashCodesAnimator.correndoAnim, true);
            }
            else if (dirX < 0)
            {
                jogador.Spr.flipX = true;

                jogador.Anim.SetBool(HashCodesAnimator.correndoAnim, true);
            }
            else
            {
                jogador.Anim.SetBool(HashCodesAnimator.correndoAnim, false);                
            }
        }
    }

    private void Pulo()
    {
        if (jogador.PodePular)
        {
            jogador.PodePular = false;

            jogador.Rig.AddForce(Vector2.up * jogador.ForcaPulo, ForceMode2D.Impulse);
        }
    }

    private void Avanco()
    {
        if (jogador.PodeAvancar)
        {
            Debug.Log("Aa");
            jogador.PodeAvancar = false;
            jogador.Avanco = true;

            jogador.Anim.SetBool(HashCodesAnimator.dashAnim, true);

            StartCoroutine(TempoAvancoControle());

            if (!jogador.Spr.flipX)
            {
                jogador.Rig.linearVelocityX += 10;
            }
            else
            {
                jogador.Rig.linearVelocityX -= 10;
            }
        }

    }

    private IEnumerator TempoAvancoControle()
    {
        yield return new WaitForSeconds(jogador.TempoAvanco);

        jogador.Anim.SetBool(HashCodesAnimator.dashAnim, false);

        jogador.Avanco = false;
    }

    private void DetectorChao()
    {
        jogador.DetectorChao = Physics2D.BoxCast(jogador.Box.bounds.center, jogador.Box.bounds.size, 0f, Vector2.down, .1f, LayerMask.GetMask("Chao"));

        if (jogador.DetectorChao.collider == null)
        {
            jogador.EstaPulando = true;
        }
        else
        {
            jogador.EstaPulando = false;
        }
    }
}
