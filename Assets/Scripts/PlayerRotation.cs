//using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Camera viewCamera;

    [SerializeField]
    private Transform forwardProvider;

    private void Update()
    {
        Vector3 screenPosition = viewCamera.WorldToScreenPoint(transform.position);
        Vector3 relativeMousePosition = Mouse.current.position.ReadValue() - (Vector2)screenPosition;
        relativeMousePosition.z = 0;

        Quaternion relativeRotation = Quaternion.FromToRotation(relativeMousePosition, Vector3.right);
        Vector3 relativeRotationEuler = relativeRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, forwardProvider.eulerAngles.y + relativeRotationEuler.z + 90, 0);
    }

}
