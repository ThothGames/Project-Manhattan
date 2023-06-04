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
    [SerializeField] private bool isAlive;
    public bool IsAlive  => isAlive;

    [SerializeField] private MeshRenderer meshRenderer;



    public void Revive()
    {
        isAlive = true;
        meshRenderer.materials[2].EnableKeyword("_EMISSION");   // tutaj event(abstrakcjê) do obiektu, który ma mieæ konkretne zachowanie
    }

    public void Kill()
    {
        isAlive = false;
        meshRenderer.materials[2].DisableKeyword("_EMISSION");   // tutaj event(abstrakcjê) do obiektu, który ma mieæ konkretne zachowanie
    }
}

