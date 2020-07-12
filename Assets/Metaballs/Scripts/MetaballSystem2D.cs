using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class MetaballSystem2D
{
    private static List<Metaball2D> metaballs;
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
        metaballs = new List<Metaball2D>();
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
        metaballs.Add(metaball);
    }

    public static List<Metaball2D> Get()
    {
        return metaballs;
    }

    public static void Remove(Metaball2D metaball)
    {
        metaballs.Remove(metaball);
    }
}
