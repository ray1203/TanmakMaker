using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCodeUpdate : MonoBehaviour
{
    public GameObject MapUploadTab;
    private Transform image;
    private MapUpload mapUpload;
    // Start is called before the first frame update
    void Start()
    {
        image = transform.Find("Image");
        mapUpload = MapUploadTab.GetComponent<MapUpload>();
    }

    // Update is called once per frame
    void Update()
    {
        image.Find("InputField").GetComponent<InputField>().text = mapUpload.mapCode.ToString();
        image.Find("Text (1)").GetComponent<Text>().text = mapUpload.mapName + "의 맵코드는";
    }
}
