using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MetaballSystem2D
{
    private static MetaballSystem2D instance;

    [Range(0f, 1f), Tooltip("Outline size.")]
    public float outlineSize = 1.0f;

    [Tooltip("Inner color.")]
    public Color innerColor = Color.white;

    [Tooltip("Outline color.")]
    public Color outlineColor = Color.black;

    internal bool updated = false;

    private MetaballSystem2D()
    {
        
    }

    public static MetaballSystem2D GetInstance()
    {
        if (instance == null)
        {
            instance = new MetaballSystem2D();
        }
        return instance;
    }

    public static void Add(Metaball2D metaball)
    {
        MetaballManager.AddMetaball(metaball);
    }

    public static List<Metaball2D> Get()
    {
        return MetaballManager.GetMetaballs();
    }

    public static void Remove(Metaball2D metaball)
    {
        MetaballManager.RemoveMetaball(metaball);
    }
}
