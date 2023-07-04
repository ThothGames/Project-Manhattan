using UnityEngine;

class EmissionEffect : LifeStateChangeEffect
{
    [Header("Settings")]
    [SerializeField] private MeshRenderer meshRenderer;

    public override void EffectAfterReviving()
    {
        meshRenderer.materials[2].EnableKeyword("_EMISSION");
        OnRevivingEffectEnded?.Invoke();
    }

    public override void EffectAfterKilling()
    {
        meshRenderer.materials[2].DisableKeyword("_EMISSION");
        OnKillingEffectEnded?.Invoke();
    }
}
