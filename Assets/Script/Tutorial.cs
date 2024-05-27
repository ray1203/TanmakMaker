using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Images;
    public int page;
    private int pageMax;
    // Start is called before the first frame update
    void Start()
    {
        pageMax = Images.transform.childCount;
        for(int i = 0; i < pageMax; i++) {
            Images.transform.GetChild(i).gameObject.SetActive(false);
        }
        Images.transform.GetChild(0).gameObject.SetActive(true);
        page = 0;
    }

    public void next() {
        if (page+1 < pageMax) {
            Images.transform.GetChild(page).gameObject.SetActive(false);
            page += 1;
            Images.transform.GetChild(page).gameObject.SetActive(true);
        }
    }
    public void back() {
        if (page - 1 >= 0) {
            Images.transform.GetChild(page).gameObject.SetActive(false);
            page -= 1;
            Images.transform.GetChild(page).gameObject.SetActive(true);
        }
    }
}
