using UnityEngine;

public abstract class LifeChangeStateEffect : MonoBehaviour
{
    public abstract void EffectAfterReviving();
    public abstract void EffectAfterKilling();
}
