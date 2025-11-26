using UnityEngine;

public sealed class Inimigo : InimigoControle
{
    void FixedUpdate()
    {
        Movimentacao();
        PercepcaoInimigo();

        if (!Spr.flipX)
        {
            StartCoroutine(Ataque(1));
        }
        else
        {
            StartCoroutine(Ataque(-1));
        }
    }

    void Update()
    {
        ModoPerseguicao();
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, 3.8f);
        Gizmos.DrawRay(raioDeAtaquePos.position, Vector2.left * 2.1f);
        Gizmos.DrawRay(posR.position, Vector2.down * .6f);
    }
}
