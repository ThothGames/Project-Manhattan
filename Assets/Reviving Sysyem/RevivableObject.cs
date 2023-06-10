using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRevivable
{
    void Revive();
}

public class RevivableObject : MonoBehaviour, IRevivable
{
    [SerializeField] private LifeChangeStateEffect lifeChangeEffect;
    [SerializeField] private bool isAlive;
    public bool IsAlive  => isAlive;


    public void Revive()
    {
        isAlive = true;
        lifeChangeEffect.EffectAfterReviving();
    }

    public void Kill()
    {
        isAlive = false;
        lifeChangeEffect.EffectAfterKilling();
    }
}
