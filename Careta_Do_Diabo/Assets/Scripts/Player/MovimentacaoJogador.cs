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

        if (Input.GetKeyDown(KeyCode.Q) && !jogador.Avanco)
        {
            jogador.PodeAvancar = true;
        }
    }

    private void Movimentacao()
    {
        if (!jogador.Avanco)
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
        StartCoroutine(ControleAvanco());
    }

    private IEnumerator ControleAvanco()
    {
        if (jogador.PodeAvancar)
        {
            Debug.Log("Aa");
            jogador.PodeAvancar = false;
            jogador.Avanco = true;

            if (!jogador.Spr.flipX)
            {
                StartCoroutine(TempoAvancoControle());

                while (jogador.Avanco)
                {
                    Debug.Log("Avanco");
                    jogador.Rig.linearVelocityX += 10;

                    yield return new WaitForSeconds(.5f);
                }                
            }
            else
            {
                StartCoroutine(TempoAvancoControle());

                while (jogador.Avanco)
                {
                    Debug.Log("Avanco");
                    jogador.Rig.linearVelocityX -= 10;

                    yield return new WaitForSeconds(.5f);
                }   
            }
        }

    }

    private IEnumerator TempoAvancoControle()
    {
        yield return new WaitForSeconds(jogador.TempoAvanco);

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
