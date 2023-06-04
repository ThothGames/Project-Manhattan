using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bipolar.RaycastSystem;

public class RevivingController : MonoBehaviour
{
    [SerializeField] private RevivableObject revivableObject;
    [SerializeField] private int reviveStack;
    [SerializeField] private bool isCollision;

    [SerializeField] private RaycastController raycast;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ReviveObject();
        }

        if (Input.GetMouseButtonDown(1))
        {
            KillObject();
        }
    }

    private void ReviveObject()
    {
        if (CheckReviveCondition())
        {
            revivableObject.Revive();
            reviveStack--;
        }
    }

    private void KillObject()
    {
        if (CheckKillCondition())
        {
            revivableObject.Kill();
            reviveStack++;
        }
    }

    private bool CheckReviveCondition()
    {
        if (reviveStack <= 0)
            return false;

        var target = raycast.Target;
        if (target == null)
            return false;

        revivableObject = target.GetComponent<RevivableObject>();           // do refaktoryzacji !!!
        if (revivableObject == null)
            return false;

        if (revivableObject.IsAlive)
            return false;
        return true;
    }

    private bool CheckKillCondition()
    {
        var target = raycast.Target;
        if (target == null)
            return false;

        revivableObject = target.GetComponent<RevivableObject>();           // do refaktoryzacji !!!
        if (revivableObject == null)
            return false;

        if (!revivableObject.IsAlive)
            return false;
        return true;
    }
}
