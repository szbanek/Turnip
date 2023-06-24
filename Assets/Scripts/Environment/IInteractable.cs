using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact();

    public void Select();

    public void Unselect();

    public Vector3 Position { get; }
}
