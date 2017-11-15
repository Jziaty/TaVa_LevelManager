using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Texture2D map;

    public ColorToPrefab[] colorMappings;

    
    /// <summary>
    /// This class reads out every pixel on the grid of the image. It compares it's colour to the one
    /// set in the inspector. When they match the prefab that is also set in the inspector will be placed.
    /// <author>Jamel Ziaty</author>
    /// </summary>
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for(int x = 0; x < map.width; x++)
        {
            for(int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if(pixelColor.a == 0)
        {
            // The pixel is transparent
            return;
        }

        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                //The position one mapping will be placed
                Vector3 position = new Vector3(x,0, y);
                //It currently uses it's current rotation which is 0,0,0 and transform is what becomes the parent.
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
