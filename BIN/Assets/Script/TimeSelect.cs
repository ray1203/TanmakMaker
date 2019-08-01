using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeSelect : MonoBehaviour
{
    public InputField inputField;
    Slider slider;
    float max = 0;
    int value = 0;
    int lastvalue = 0;
    //string lastText = "";
    public GameObject enemy;
    int lastChild = 0, nowChild = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemy.GetComponent<ShowEnemyByTime>().show(value);
        inputField.text = "0";
        slider = this.gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        value = (int)Mathf.Floor(this.transform.GetComponent<Slider>().value);
        if (value != lastvalue) {
            inputField.text = value.ToString();
            enemy.GetComponent<ShowEnemyByTime>().show(value);
        }
        
        lastvalue= value;
        nowChild = enemy.transform.childCount;
        if (nowChild != lastChild) {
            enemy.GetComponent<ShowEnemyByTime>().show(value);

        }
        lastChild = nowChild;

    }
    public void MaxSummonTime(float t) {
        if (t > max) {
            max = t;
            this.transform.GetComponent<Slider>().maxValue = max;
        }
    }
    public void ChangeValue(int v) {
        if (v > Mathf.Floor(max)) v = (int)Mathf.Floor(max);
        if (v < 0) v = 0;
        value = v;
    }
    public int GetValue() {
        return value;
    }
    public void GetText() {
        if(int.Parse(inputField.text)<int.MaxValue&& int.Parse(inputField.text)>=0)
        this.transform.GetComponent<Slider>().value = int.Parse(inputField.text);
    }
    public void resetValue() {
        this.transform.GetComponent<Slider>().value = 0;
        this.transform.GetComponent<Slider>().maxValue = 0;
        inputField.text = "0";
        max = 0;
        value = 0;
        lastvalue = 0;

    }
}
