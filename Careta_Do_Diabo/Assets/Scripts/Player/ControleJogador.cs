using UnityEngine;

public sealed class ControleJogador : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private SpriteRenderer spr;

    [Header("Atributos")]
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;

    //Atrributos de controle
    private bool estaPulando;
    private bool podePular;
    private bool jogadorAtacando;
    private bool podeAtacar = true;

    //Constantes
    [SerializeField] private float tamanhoAtaque;

    //Atributos de fisica
    private RaycastHit2D detectorChao;
    private RaycastHit2D hitInimigo;

    //-----------------------------------------------------------------------------------------

    //Propriedades dos Componentes
    public Rigidbody2D Rig { get => rig; set => rig = value; }
    public BoxCollider2D Box { get => box; }
    public SpriteRenderer Spr { get => spr; set => spr = value; }

    //Propriedade dos atributos
    public float Velocidade { get => velocidade; }
    public float ForcaPulo { get => forcaPulo; }

    //Propriedade de Controle
    public bool EstaPulando { get => estaPulando; set => estaPulando = value; }
    public bool PodePular { get => podePular; set => podePular = value; }
    public bool JogadorAtacando { get => jogadorAtacando; set => jogadorAtacando = value; }
    public bool PodeAtacar { get => podeAtacar; set => podeAtacar = value; }

    //Propriedades de Física
    public RaycastHit2D DetectorChao { get => detectorChao; set => detectorChao = value; }
    public RaycastHit2D HitInimigo { get => hitInimigo; set => hitInimigo = value; }

    //Propriedades constantes
    public float TamanhoAtaque { get => tamanhoAtaque; }
}
