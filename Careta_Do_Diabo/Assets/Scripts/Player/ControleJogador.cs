using UnityEngine;

public sealed class ControleJogador : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private BoxCollider2D box;
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private Animator anim;

    [Header("Atributos")]
    [SerializeField] private int vida;

    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    [SerializeField] private float tempoAvanco;

    //Atrributos de controle
    private bool estaPulando;
    private bool podePular;
    private bool jogadorAtacando;
    private bool avanco;
    private bool podeAvancar;
    private bool podeAtacar = true;

    //Constantes
    public const float tamanhoAtaque = 2.5f;

    //Atributos de fisica
    private RaycastHit2D detectorChao;
    private RaycastHit2D hitInimigo;

    //-----------------------------------------------------------------------------------------

    //Propriedades dos Componentes
    public BoxCollider2D Box { get => box; }
    public Animator Anim { get => anim; }
    public Rigidbody2D Rig { get => rig; set => rig = value; }
    public SpriteRenderer Spr { get => spr; set => spr = value; }

    //Propriedade dos atributos
    public int Vida { get => vida; set => vida = value; }

    public float Velocidade { get => velocidade; }
    public float ForcaPulo { get => forcaPulo; }
    public float TempoAvanco { get => tempoAvanco; }

    //Propriedade de Controle
    public bool EstaPulando { get => estaPulando; set => estaPulando = value; }
    public bool PodePular { get => podePular; set => podePular = value; }
    public bool JogadorAtacando { get => jogadorAtacando; set => jogadorAtacando = value; }
    public bool Avanco { get => avanco; set => avanco = value; }
    public bool PodeAvancar { get => podeAvancar; set => podeAvancar = value; }
    public bool PodeAtacar { get => podeAtacar; set => podeAtacar = value; }

    //Propriedades de Física
    public RaycastHit2D DetectorChao { get => detectorChao; set => detectorChao = value; }
    public RaycastHit2D HitInimigo { get => hitInimigo; set => hitInimigo = value; }
}
