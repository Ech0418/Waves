using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EraseMe : MonoBehaviour
{
    public float brushSize;
    public float brushStrength;
    private float percentage;

    private Texture2D texture;
    private SpriteRenderer sr;  
    private Color[] originalPixelColors;
    private Color[] newPixelColors;
    
    Vector2 mousePos;
    Vector2 localPos;

    float newAlpha;
    private Color pixelColor;
    private int index;

    public Slider slider;

    public int erasedCount;
    public AudioSource eraseSound;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        Texture2D sourceTexture = sr.sprite.texture;
        texture = Instantiate(sourceTexture);
        texture.Apply();

        originalPixelColors = sourceTexture.GetPixels();
        newPixelColors = texture.GetPixels();

        sr.sprite = Sprite.Create(texture, sr.sprite.rect, new Vector2(0.5f, 0.5f));
    }

    public float GetErasedPercentage(float alphaThreshold = 0.1f)
    {
        erasedCount = 0;
        int totalPixels = newPixelColors.Length;

        for (int i = 0; i < totalPixels; i++)
        {
            if (newPixelColors[i].a < alphaThreshold)
            {
                erasedCount++;
            }
        }
        return (float)erasedCount;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            GetTextureCoordinates();          
        }

        slider.value = GetErasedPercentage();

        if (erasedCount >= percentage)
        {
            Debug.Log("win");
            SceneManager.LoadScene(1);
        }
    }

    public void GetTextureCoordinates()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        localPos = transform.InverseTransformPoint(mousePos);
        
        Vector2 pivot = sr.sprite.pivot;
        float pixelsPerUnit = sr.sprite.pixelsPerUnit;

        int px = Mathf.RoundToInt(pivot.x + localPos.x * sr.sprite.pixelsPerUnit);
        int py = Mathf.RoundToInt(pivot.y + localPos.y * sr.sprite.pixelsPerUnit);

        Draw(px, py);
    }
    public void Draw(int centerx, int centery)
    {
        eraseSound.Play();
        int radius = Mathf.CeilToInt(brushSize/2);

        for(int y = -radius; y <= radius; y++)
        {
            int py = centery + y;
            if (py < 0 || py >= texture.height) continue;

            for (int x = -radius; x <= radius; x++)
            {
                int px = centerx + x;
                if(px < 0 || px >= texture.width) continue;
                
                float distance = Mathf.Sqrt(x * x + y * y);
                if (distance > radius) continue;
               
                index = py * texture.width + px;
                pixelColor = newPixelColors[index];

                newAlpha = Mathf.Max(pixelColor.a - brushStrength, 0f);
                if (newAlpha != pixelColor.a)
                {
                    pixelColor.a = newAlpha;
                    newPixelColors[index] = pixelColor;
                }
            }
        }

        texture.SetPixels(newPixelColors);
        texture.Apply();
    }
}
