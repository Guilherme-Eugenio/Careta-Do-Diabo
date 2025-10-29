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
            jogador.JogadorAtacando = false;
            jogador.PodeAtacar = false;

            jogador.Anim.SetBool(HashCodesAnimator.correndoAnim, false);

            DetectarInimigo();

            yield return new WaitForSeconds(.22f);

            jogador.Anim.SetBool(HashCodesAnimator.atacandoAnim, false);
            jogador.Anim.SetBool(HashCodesAnimator.atacandoBaixoAnim, false);
            

            jogador.PodeAtacar = true;
        }
    }

    private void DirecaoAtaque()
    {
        if (jogador.EstaPulando && Input.GetKey(KeyCode.S))
        {
            jogador.Anim.SetBool(HashCodesAnimator.atacandoBaixoAnim, true);
            jogador.Anim.SetBool(HashCodesAnimator.puloAnim, false);

            jogador.HitInimigo = Physics2D.Raycast(transform.position, Vector2.down, ControleJogador.tamanhoAtaque, LayerMask.GetMask("Inimigo"));
        }
        else
        {
            if (!jogador.Spr.flipX)
            {
                jogador.Anim.SetBool(HashCodesAnimator.atacandoAnim, true);

                jogador.HitInimigo = Physics2D.Raycast(transform.position, Vector2.right, ControleJogador.tamanhoAtaque, LayerMask.GetMask("Inimigo"));
            }
            else
            {
                jogador.Anim.SetBool(HashCodesAnimator.atacandoAnim, true);

                jogador.HitInimigo = Physics2D.Raycast(transform.position, Vector2.left, ControleJogador.tamanhoAtaque, LayerMask.GetMask("Inimigo"));
            }
        }
    }

    private void DetectarInimigo()
    {
        DirecaoAtaque();

        if (jogador.HitInimigo.collider != null)
        {
            jogador.HitInimigo.collider.GetComponent<Inimigo>().DanoRecebido();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        if (jogador.EstaPulando && Input.GetKey(KeyCode.S))
        {
            Gizmos.DrawRay(transform.position, Vector2.down * ControleJogador.tamanhoAtaque);
        }
        else
        {
            if (!jogador.Spr.flipX)
            {               
                Gizmos.DrawRay(transform.position, Vector2.right * ControleJogador.tamanhoAtaque);
            }
            else
            {                
                Gizmos.DrawRay(transform.position, Vector2.left * ControleJogador.tamanhoAtaque);
            }
        }
    }
}
