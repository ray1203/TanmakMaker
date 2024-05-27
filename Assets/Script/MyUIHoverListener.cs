using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyUIHoverListener: MonoBehaviour
{
    public bool isUIOverride { get; private set; }
    private bool clickAvailable = true;

    public bool ClickAvailable {
        get {
            return clickAvailable;
        }

        set {
            clickAvailable = value;
        }
    }
    void Update() {
        isUIOverride = EventSystem.current.IsPointerOverGameObject();
    }

    
}
