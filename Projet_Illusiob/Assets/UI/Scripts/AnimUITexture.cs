using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimUITexture : MonoBehaviour
{
    [SerializeField] List<Texture2D> images = new();
    [SerializeField] RawImage heart = null;
    [SerializeField] float timeBeforeSwitchImage = 0.1f;
    [SerializeField] float currentTime = 0.0f;
    [SerializeField] int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeBeforeSwitchImage)
        {
            ChangeImage();
            currentTime = 0.0f;
        }
    }

    void Init()
    {
        heart = GetComponent<RawImage>();
    }

    void ChangeImage()
    {
        index = index == images.Count - 1 ? 0 : index + 1;
        heart.texture = images[index];
    }
}
