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
        Gizmos.DrawRay(transform.position, Vector2.left * 1.4f);
    }
}
