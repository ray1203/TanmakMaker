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
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        value = (int)Mathf.Floor(this.transform.GetComponent<Slider>().value);
        enemy.GetComponent<ShowEnemyByTime>().show(value);
        inputField.text = value.ToString();

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
}
