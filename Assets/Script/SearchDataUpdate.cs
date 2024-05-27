using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchDataUpdate : MonoBehaviour
{

    public GameObject successFalseTab;
    public GameObject wifiTab;
    public GameObject searchBtn;
    public GameObject mapTitle;
    public GameObject mapDescription;
    public GameObject mapAccessCount;
    private Text mapTitleText;
    private Text mapDescriptionText;
    private Text mapAccessCountText;
    private MapDownload map;
    void Awake() {
        mapTitleText = mapTitle.GetComponent<Text>();
        mapDescriptionText = mapDescription.GetComponent<Text>();
        mapAccessCountText = mapAccessCount.GetComponent<Text>();
        map = searchBtn.GetComponent<MapDownload>();
    }
    void Update()
    {
        if (map.mapDescription != "" && map.mapName != "") {
            if (mapTitleText.text != map.mapName || mapDescriptionText.text != map.mapDescription||mapDescriptionText.text!= "이 맵의 방문횟수: " + map.mapAccessCount&&map.mapAccessCount!="") {
                mapTitleText.text = map.mapName;
                mapDescriptionText.text = map.mapDescription;
                mapAccessCountText.text = "이 맵의 방문횟수: "+map.mapAccessCount;
                mapDescription.transform.position = new Vector3(0f, mapDescription.GetComponent<RectTransform>().rect.height * -1, 0f);
            }

        }
        if (map.searchFlag == 1) {
            if (Application.internetReachability == NetworkReachability.NotReachable) {
                wifiTab.SetActive(true);
                for (int i = 0; i < wifiTab.transform.childCount; i++) wifiTab.transform.GetChild(i).gameObject.SetActive(true);
            } else {
                successFalseTab.SetActive(true);
                for (int i = 0; i < successFalseTab.transform.childCount; i++) successFalseTab.transform.GetChild(i).gameObject.SetActive(true);
            }
                map.searchFlag = 0;
        }

    }
}
