using System.Collections;
using UnityEngine;

public class InimigoControle : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform posL;
    [SerializeField] private Transform posR;
    private Transform posicaoJogador;

    [Header("Attibutes")]
    [SerializeField] private int vida;
    [SerializeField] private float velocidade;
    [SerializeField] private float velocidadePerseguicao;

    private bool andando;
    private bool mudanoMovimentacao;
    private bool perseguicao;
    private bool prepararAtaque;
    private bool atacando;
    private bool danoRecebido;

    //Raycast2D
    private RaycastHit2D chaoDetector;
    private RaycastHit2D deteccaoJogador;
    private RaycastHit2D deteccaoAtaque;

    //----------------------------------------------------------------------------
    //Propriedades
    public SpriteRenderer Spr { get => spr; }

    public void Movimentacao()
    {
        StartCoroutine(ParadoOuAndando());

        if (andando && !perseguicao && !atacando && !danoRecebido)
        {
            transform.Translate(Time.deltaTime * velocidade * Vector2.right);

            //anim.SetBool(HashCodesAnimator.correndoAnim, true);

            if (!spr.flipX)
            {
                chaoDetector = Physics2D.Raycast(posR.position, Vector2.down, .1f, LayerMask.GetMask("Chao"));

                if (chaoDetector.collider == null)
                {
                    spr.flipX = true;

                    velocidade *= -1;
                }
            }
            else
            {
                chaoDetector = Physics2D.Raycast(posL.position, Vector2.down, .1f, LayerMask.GetMask("Chao"));

                if (chaoDetector.collider == null)
                {
                    spr.flipX = false;

                    velocidade *= -1;
                }
            }
        }
    }

    public IEnumerator ParadoOuAndando()
    {
        if (!mudanoMovimentacao)
        {
            mudanoMovimentacao = true;

            float tempoParado = Random.Range(1f, 4.5f);
            float tempoAndando = Random.Range(1f, 4.5f);

            andando = false;

            anim.SetBool(HashCodesAnimator.correndoAnim, false);

            yield return new WaitForSeconds(tempoParado);

            andando = true;

            anim.SetBool(HashCodesAnimator.correndoAnim, true);

            yield return new WaitForSeconds(tempoAndando);

            mudanoMovimentacao = false;
        }

    }

    public void PercepcaoInimigo()
    {
        deteccaoJogador = Physics2D.CircleCast(transform.position, 3.8f, Vector2.zero, 0f, LayerMask.GetMask("Player"));

        if (deteccaoJogador.collider != null)
        {
            perseguicao = true;

            posicaoJogador = deteccaoJogador.transform;
        }


    }

    public void ModoPerseguicao()
    {
        if (perseguicao && !atacando && !danoRecebido)
        {
            StopCoroutine(ParadoOuAndando());

            Vector2 distancia = transform.position - posicaoJogador.position;

            anim.SetBool(HashCodesAnimator.correndoAnim, true);

            transform.position = Vector2.MoveTowards(transform.position, new(posicaoJogador.position.x, transform.position.y), velocidadePerseguicao * Time.deltaTime);

            if (distancia.x > 0)
            {
                spr.flipX = true;

                prepararAtaque = true;
            }
            else
            {
                spr.flipX = false;

                prepararAtaque = true;
            }
        }
    }

    public IEnumerator Ataque(int direcao)
    {
        if (prepararAtaque && !danoRecebido)
        {
            deteccaoAtaque = Physics2D.Raycast(transform.position, new(direcao, 0), 1.4f, LayerMask.GetMask("Player"));

            if (deteccaoAtaque.collider != null)
            {
                prepararAtaque = false;
                atacando = true;

                anim.SetBool(HashCodesAnimator.correndoAnim, false);
                anim.SetBool(HashCodesAnimator.atacandoAnim, true);

                yield return new WaitForSeconds(.65f);

                deteccaoAtaque = Physics2D.Raycast(transform.position, new(direcao, 0), 1.4f, LayerMask.GetMask("Player"));

                if (deteccaoAtaque.collider != null)
                {
                    deteccaoAtaque.collider.GetComponent<AcoesJogador>().JogadorRecebeDano();

                    anim.SetBool(HashCodesAnimator.atacandoAnim, false);

                    spr.flipX = false;

                    atacando = false;
                    perseguicao = false;
                }
                else
                {
                    anim.SetBool(HashCodesAnimator.atacandoAnim, false);

                    spr.flipX = false;

                    atacando = false;
                    perseguicao = false;
                }
            }
            else
            {
                atacando = false;
            }
        }
    }

    public void DanoRecebido()
    {
        StartCoroutine(DanoControler());
    }

    private IEnumerator DanoControler()
    {
        vida--;

        if (vida > 0)
        {
            danoRecebido = true;

            anim.SetBool(HashCodesAnimator.danoAnim, true);
            anim.SetBool(HashCodesAnimator.atacandoAnim, false);

            yield return new WaitForSeconds(.53f);

            danoRecebido = false;

            anim.SetBool(HashCodesAnimator.danoAnim, false);
        }
        else if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
