using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action<KeyCode> KeyDownEvent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            KeyDownEvent?.Invoke(KeyCode.Z);
        }
		if (Input.GetKeyDown(KeyCode.X))
        {
            KeyDownEvent?.Invoke(KeyCode.X);
        }
		if (Input.GetKeyDown(KeyCode.C))
        {
            KeyDownEvent?.Invoke(KeyCode.C);
        }
    }
}
