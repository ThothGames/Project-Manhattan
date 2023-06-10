using UnityEngine;

class PumpkinLifeChangeStateEffect : LifeChangeStateEffect
{
    [SerializeField] private MeshRenderer meshRenderer;

    public override void EffectAfterReviving()
    {
        meshRenderer.materials[2].EnableKeyword("_EMISSION");
    }

    public override void EffectAfterKilling()
    {
        meshRenderer.materials[2].DisableKeyword("_EMISSION");
    }
}
