using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MiniCtrl : MonoBehaviour {
    public GameObject player; 
    public void normal()
    {
        if(player!=null)
        player.GetComponent<PlayerCtrl>().NormalSpeed();
    }
    public void slow()
    {
        if (player != null)
           player.GetComponent<PlayerCtrl>().SlowSpeed();
    }
}
