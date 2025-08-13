using UnityEngine;

[RequireComponent(typeof(ControleJogador))]
public sealed class MovimentacaoJogador : MonoBehaviour
{
    [SerializeField] private ControleJogador jogador;

    void FixedUpdate()
    {
        DetectorChao();
        Movimentacao();
        Pulo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jogador.EstaPulando)
        {
            jogador.PodePular = true;
        }
    }

    private void Movimentacao()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        jogador.Rig.linearVelocityX = dirX * jogador.Velocidade;

        if (dirX > 0)
        {
            jogador.Spr.flipX = false;
        }
        else if (dirX < 0)
        {
            jogador.Spr.flipX = true;
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

    private void DetectorChao()
    {
        jogador.DetectorChao = Physics2D.BoxCast(jogador.Box.bounds.center, jogador.Box.bounds.size, 0f, Vector2.down, .1f,LayerMask.GetMask("Chao"));

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
