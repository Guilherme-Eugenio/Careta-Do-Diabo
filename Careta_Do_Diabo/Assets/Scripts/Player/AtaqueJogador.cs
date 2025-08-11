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

            jogador.DetectorInimigo = Physics2D.Raycast(transform.position, Vector2.right, 1.4f, LayerMask.GetMask("Inimigo"));

            if (jogador.DetectorInimigo.collider != null)
            {
                Debug.Log(jogador.DetectorInimigo.collider.gameObject.name);
            }

            yield return new WaitForSeconds(.5f);

            jogador.PodeAtacar = true;
        }
    }

    void OnDrawGizmos()
    {
        if(jogador.estaPulando && Input.GetKey(KeyCode.S))
        {
            jogador.DetectorInimigo = Physics2D.Raycast(transform.position, Vector2.down, 1.4f, LayerMask.GetMask("Inimigo"));
        }
        else
        {
            if(!jogador.Spr.flipX)
            {
                jogador.DetectorInimigo = Physics2D.Raycast(transform.position, Vector2.right, 1.4f, LayerMask.GetMask("Inimigo"));
            }
            else
            {
                jogador.DetectorInimigo = Physics2D.Raycast(transform.position, Vector2.left, 1.4f, LayerMask.GetMask("Inimigo"));
            }            
        }
    }

}
