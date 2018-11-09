using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MiniCtrl : MonoBehaviour {
    GameObject player;
    private bool isBtnDown = false;
    private void Update()
    {
        if (isBtnDown)
        {
            player.GetComponent<PlayerCtrl>().SlowSpeed();
        }
        else
        {
            player.GetComponent<PlayerCtrl>().NormalSpeed();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }
}
