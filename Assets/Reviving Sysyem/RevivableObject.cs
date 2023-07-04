using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRevivable
{
    bool IsAlive { get; }
    void Revive();
    void Kill();
}

public class RevivableObject : MonoBehaviour, IRevivable
{
    [SerializeField] private LifeStateChangeEffect lifeChangeEffect;
    [SerializeField] private bool isAlive;
    public bool IsAlive  => isAlive;

    public void Revive()
    {
        if (isAlive) return;
        lifeChangeEffect.EffectAfterReviving();
    }

    public void Kill()
    {
        if (isAlive == false) return;
        lifeChangeEffect.EffectAfterKilling();
    }

    private void SetAlive()
    {
        isAlive = true;
    }

    private void SetNotAlive()
    {
        isAlive = false;
    }

    private void OnEnable()
    {
        lifeChangeEffect.OnRevivingEffectEnded += SetAlive;
        lifeChangeEffect.OnKillingEffectEnded += SetNotAlive;
    }

    private void OnDisable()
    {
        lifeChangeEffect.OnRevivingEffectEnded -= SetAlive;
        lifeChangeEffect.OnKillingEffectEnded -= SetNotAlive;
    }
}
