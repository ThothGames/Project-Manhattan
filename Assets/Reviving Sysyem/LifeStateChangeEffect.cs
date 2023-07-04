using UnityEngine;
using System;

public abstract class LifeStateChangeEffect : MonoBehaviour
{
    public Action OnRevivingEffectEnded;
    public Action OnKillingEffectEnded;

    public abstract void EffectAfterReviving();
    public abstract void EffectAfterKilling();
}
