using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    [SerializeField] List<AnimUITexture> allHearts = new();

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
        allHearts = GetComponentsInChildren<AnimUITexture>().ToList();
    }

    public void RemoveHeart()
    {
        if (allHearts.Count < 1) return;

        AnimUITexture _heart = allHearts[allHearts.Count - 1];

        allHearts.Remove(_heart);
        Destroy(_heart.gameObject);

    }
}
