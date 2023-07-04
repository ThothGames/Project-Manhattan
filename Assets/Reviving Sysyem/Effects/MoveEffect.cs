using UnityEngine;

class MoveEffect : LifeStateChangeEffect
{
    private enum MovementType
    {
        Target, //global
        Shift,  //local
    }

    //Settings nie zmienia się w trakcie gry. Settings nie może zmienić się sam ale inny obiekt może je zmieniać.
    [Header("Settings")]
    [SerializeField] private MovementType movementType;
    [SerializeField] private Vector3 positionShift;
    [SerializeField] private float speed;

    //State - stan obiektu - może zmieniać się w trakcie działania gry.
    [Header("State")]
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isRevivingEffect;
    private Vector3 initialPosition;

    private void Update()
    {
        if (isMoving)
        {
            MoveObject();                                // move object by step(one frame one step).
            if (transform.position == targetPosition)
                isMoving = false;
        }
    }

    public override void EffectAfterReviving()
    {
        if (movementType == MovementType.Target)
        {
            targetPosition = positionShift;
        }
        else
        {
            targetPosition = transform.position + positionShift;
        }

        isMoving = true;
        isRevivingEffect = true;
        initialPosition = transform.position;
    }

    public override void EffectAfterKilling()
    {
        if (movementType == MovementType.Target)
        {
            targetPosition = initialPosition;
        }
        else
        {
            targetPosition = transform.position - positionShift;
        }

        isMoving = true;
        isRevivingEffect = false;
    }

    private void MoveObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (isRevivingEffect)
            OnRevivingEffectEnded?.Invoke();
        else
            OnKillingEffectEnded?.Invoke();
    }
}