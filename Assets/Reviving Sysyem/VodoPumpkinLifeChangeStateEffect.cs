using UnityEngine;

class VodoPumpkinLifeChangeStateEffect : LifeChangeStateEffect
{
    private enum MovementType
    {
        Target,
        Shift,
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
    private Vector3 initialPosition;

    private void Start()
    {
        Application.targetFrameRate = 100;
    }


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
    }

    private void MoveObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}