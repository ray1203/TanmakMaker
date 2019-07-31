using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchDataUpdate : MonoBehaviour
{
    public GameObject searchBtn;
    public GameObject mapTitle;
    public GameObject mapDescription;
    private Text mapTitleText;
    private Text mapDescriptionText;
    private MapDownload map;
    void Awake() {
        mapTitleText = mapTitle.GetComponent<Text>();
        mapDescriptionText = mapDescription.GetComponent<Text>();
        map = searchBtn.GetComponent<MapDownload>();
    }
    void Update()
    {
        if (map.mapDescription != null && map.mapName != null) {
            if (mapTitleText.text != map.mapName && mapDescriptionText.text != map.mapDescription) {
                mapTitleText.text = map.mapName;
                mapDescriptionText.text = map.mapDescription;
                mapDescription.transform.position = new Vector3(0f, mapDescription.GetComponent<RectTransform>().rect.height * -1, 0f);
            }

        }

    }
}
