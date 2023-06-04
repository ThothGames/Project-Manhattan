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
        meshRenderer.materials[2].EnableKeyword("_EMISSION");   // tutaj event(abstrakcj�) do obiektu, kt�ry ma mie� konkretne zachowanie
    }

    public void Kill()
    {
        isAlive = false;
        meshRenderer.materials[2].DisableKeyword("_EMISSION");   // tutaj event(abstrakcj�) do obiektu, kt�ry ma mie� konkretne zachowanie
    }
}

