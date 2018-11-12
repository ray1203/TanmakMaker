using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIclose : MonoBehaviour {

	public void close()
    {
        for (int i = 0; i <this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
    public void open()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
        this.gameObject.SetActive(true);
    }
}
