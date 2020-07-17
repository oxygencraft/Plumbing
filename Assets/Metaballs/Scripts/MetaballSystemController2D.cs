using UnityEngine;

public class MetaballSystemController2D : MonoBehaviour
{
    public MetaballSystem2D metaballSystem;
    public MetaballManager metaballManager;

    void Awake()
    {
        metaballSystem = MetaballSystem2D.GetInstance();
    }
}
