using UnityEngine;

public sealed class HashCodesAnimator : MonoBehaviour
{
    public static readonly int correndoAnim = Animator.StringToHash("correndo");
    public static readonly int atacandoAnim = Animator.StringToHash("atacando");
    public static readonly int dashAnim = Animator.StringToHash("dash");
    public static readonly int danoAnim = Animator.StringToHash("dano");
}
