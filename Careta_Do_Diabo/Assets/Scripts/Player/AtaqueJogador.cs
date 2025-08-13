using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ControleJogador))]
public sealed class AtaqueJogador : MonoBehaviour
{
    [SerializeField] private ControleJogador jogador;

    void FixedUpdate()
    {
        StartCoroutine(TempoAtaque());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && jogador.PodeAtacar)
        {
            jogador.JogadorAtacando = true;    
        }
    }

    private IEnumerator TempoAtaque()
    {
        if (jogador.JogadorAtacando)
        {
            Debug.Log("jogado Atacando");
            jogador.JogadorAtacando = false;
            jogador.PodeAtacar = false;

            DetectarInimigo();

            yield return new WaitForSeconds(.5f);

            jogador.PodeAtacar = true;
        }
    }

    private void DirecaoAtaque()
    {
        if (jogador.EstaPulando && Input.GetKey(KeyCode.S))
        {
            jogador.HitInimigo = Physics2D.Raycast(transform.position, Vector2.down, jogador.TamanhoAtaque, LayerMask.GetMask("Inimigo"));
        }
        else
        {
            if (!jogador.Spr.flipX)
            {
                jogador.HitInimigo = Physics2D.Raycast(transform.position, Vector2.right, jogador.TamanhoAtaque, LayerMask.GetMask("Inimigo"));
            }
            else
            {
                jogador.HitInimigo = Physics2D.Raycast(transform.position, Vector2.left, jogador.TamanhoAtaque, LayerMask.GetMask("Inimigo"));
            }
        }
    }

    private void DetectarInimigo()
    {
        DirecaoAtaque();

        if (jogador.HitInimigo.collider != null)
        {
            Debug.Log(jogador.HitInimigo.collider.gameObject.name);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        if (jogador.EstaPulando && Input.GetKey(KeyCode.S))
        {
            Gizmos.DrawRay(transform.position, Vector2.down * jogador.TamanhoAtaque);
        }
        else
        {
            if (!jogador.Spr.flipX)
            {               
                Gizmos.DrawRay(transform.position, Vector2.right * jogador.TamanhoAtaque);
            }
            else
            {                
                Gizmos.DrawRay(transform.position, Vector2.left * jogador.TamanhoAtaque);
            }
        }
    }
}
