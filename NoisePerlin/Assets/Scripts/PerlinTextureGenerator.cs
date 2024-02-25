using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTextureGenerator : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    public Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        Color[] colors = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float xCoord = (float)x / width * scale;
                float yCoord = (float)y / height * scale;
                float sample = PerlinNoise.Noise(xCoord, yCoord, 0);

                colors[y * width + x] = new Color(sample, sample, sample);
            }
        }

        texture.SetPixels(colors);
        texture.Apply();

        return texture;
    }
}
