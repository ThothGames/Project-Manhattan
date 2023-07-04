using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEffect : LifeStateChangeEffect
{
    [Header("Settings")]
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private float timer;
    [SerializeField] private Color firstColor = Color.red;
    [SerializeField] private Color secondColor = Color.yellow;

    private Color currentColor;
    private bool isAlive;

    [SerializeField] private float timeToSwitch;

    private void Update()
    {
        if (isAlive)
        {
            timer += Time.deltaTime;
            if (timer >= timeToSwitch)
            {
                SwitchColor();
                timer = 0;
            }
        }
    }

    public override void EffectAfterReviving()
    {
        isAlive = true;
        OnRevivingEffectEnded?.Invoke();
    }

    private void SwitchColor()
    {
        if (meshRenderer.materials[1].color == firstColor)
        {
            meshRenderer.materials[1].color = secondColor;
            currentColor = secondColor;
        }
        else
        {
            meshRenderer.materials[1].color = firstColor;
            currentColor = firstColor;
        }
    }

    public override void EffectAfterKilling()
    {
        isAlive = false;
        meshRenderer.materials[1].color = currentColor;
        OnKillingEffectEnded?.Invoke();
    }
}
