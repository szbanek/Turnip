using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    public Vector2 Position { get; private set; }

    private Coroutine lockCoroutine = null;

    private void Start()
    {
        LockCursor();
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lockCoroutine ??= StartCoroutine(LockCursorCoroutine());
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StopCoroutine(lockCoroutine);
        lockCoroutine = null;
    }

    public void Move(Vector2 deltaPos)
    {
        Position += deltaPos;
    }

    private IEnumerator LockCursorCoroutine()
    {
        while (true)
        {
            Position = Vector2.zero;
            yield return null;
        }
    }
}
