using System.Collections;
using UnityEngine;

public sealed class Inimigo : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private Transform posL;
    [SerializeField] private Transform posR;

    [SerializeField] private int vida;
    [SerializeField] private float velocidade;
    private bool danoLevado;

    private RaycastHit2D chaoDetector;

    void Update()
    {
        Movimentacao();
    }

    private void Movimentacao()
    {
        transform.Translate(Time.deltaTime * velocidade * Vector2.right);

        anim.SetBool(HashCodesAnimator.correndoAnim, true);

        if (!spr.flipX)
        {
            chaoDetector = Physics2D.Raycast(posR.position, Vector2.down, .1f, LayerMask.GetMask("Chao"));

            if (chaoDetector.collider == null)
            {
                spr.flipX = true;

                velocidade *= -1f;
            }
        }
        else
        {
            chaoDetector = Physics2D.Raycast(posL.position, Vector2.down, .1f, LayerMask.GetMask("Chao"));

            if (chaoDetector.collider == null)
            {
                spr.flipX = false;

                velocidade *= -1f;
            }
        }
    }


    public void LevouDano()
    {
        if (vida > 0)
        {
            vida--;

            StartCoroutine(ControleDano());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator ControleDano()
    {
        if (!danoLevado)
        {
            danoLevado = true;

            anim.SetBool(HashCodesAnimator.danoAnim, true);

            yield return new WaitForSeconds(.53f);

            anim.SetBool(HashCodesAnimator.danoAnim, false);

            danoLevado = false;
        }
    }
}
