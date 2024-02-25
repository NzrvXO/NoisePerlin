using UnityEngine;

public class ShowTexture : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    void Start()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = new Vector3(0, 0, 0); // Устанавливаем позицию плоскости
        plane.transform.localScale = new Vector3(5, 1, 5); // Устанавливаем размер плоскости

        Renderer renderer = plane.GetComponent<Renderer>();
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
                float sample = Mathf.PerlinNoise(xCoord, yCoord);

                colors[y * width + x] = new Color(sample, sample, sample);
            }
        }

        texture.SetPixels(colors);
        texture.Apply();

        return texture;
    }
}