using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScallingEffect : LifeStateChangeEffect
{
    [Header("State")]
    [SerializeField] private float waitingTimer;
    [SerializeField] private float scalingTimer;
    [SerializeField] private float timeToSwitch;
    [SerializeField] private float scalingDuration;
    [SerializeField] private float size;


    private Vector3 startScale;
    private Vector3 targetScale;

    private bool isScaling;
    private bool isScalingStartPos;

    private void Start()
    {
        startScale = transform.localScale;
    }

    private void Update()
    {
        waitingTimer += Time.deltaTime;
        if (waitingTimer > timeToSwitch)
        {
            if (isScaling)
            {
                scalingTimer += Time.deltaTime;
                ChangeObjectScale();
            }

            if (isScalingStartPos)
            {
                scalingTimer += Time.deltaTime;
                SetStartScale();
            }
        }
    }

    private void ChangeObjectScale()
    {
        targetScale = new Vector3(size, size, size);
        transform.localScale = Vector3.Lerp(startScale, targetScale, scalingTimer / scalingDuration);
        if (scalingTimer >= scalingDuration)
        {
            isScaling = false;
            OnRevivingEffectEnded?.Invoke();
            scalingTimer = 0f;

        }
    }

    private void SetStartScale()
    {
        transform.localScale = Vector3.Lerp(targetScale, startScale, scalingTimer / scalingDuration);
        if (scalingTimer >= scalingDuration)
        {
            isScalingStartPos = false;
            OnKillingEffectEnded?.Invoke();
            scalingTimer = 0f;
        }
    }

    public override void EffectAfterReviving()
    {
        if (isScaling) return;
        waitingTimer = 0f;
        isScaling = true;
    }

    public override void EffectAfterKilling()
    {
        if (isScalingStartPos) return;
        waitingTimer = 0f;
        isScalingStartPos = true;
    }
}