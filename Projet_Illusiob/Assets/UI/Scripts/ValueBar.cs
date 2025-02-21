using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour
{
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
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateValue(float _current,float _max)
    {
        float _percent = _current / _max;
        slider.value = _percent;

        int _textValue = (int)(slider.value * 100.0f);
        string _newText = (_textValue).ToString();
        text.SetText(_newText);
    }
}
