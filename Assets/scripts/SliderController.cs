using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public float targert;
    public float currentValue;
    public float speed;
    public Slider slider;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        currentValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (targert > currentValue)
        {
            currentValue += speed * Time.deltaTime;
            slider.value = currentValue;
            text.text = (((currentValue>targert)?slider.value:currentValue)*100 / slider.maxValue).ToString("0.0")+"%";
        }
       
    }
    public void setSlideTarget(int x)
    {
        targert += x;
    }
}
