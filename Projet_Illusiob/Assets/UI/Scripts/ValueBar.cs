using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour
{
    public Action<float, float> onValueChanged = null;

    [SerializeField] Slider slider = null;
    [SerializeField] TextMeshProUGUI text = null;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        slider = GetComponent<Slider>();
        text = GetComponent<TextMeshProUGUI>();
        onValueChanged += UpdateValue;
    }

    void UpdateValue(float _current,float _max)
    {
        float _percent = _max / _current;
        slider.value = _percent;

        string _newText = (slider.value * 100.0f).ToString();
        text.SetText(_newText);
    }
}
