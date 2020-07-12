using UnityEngine;

public class MetaballSystemController2D : MonoBehaviour
{
    public MetaballSystem2D metaballSystem;

    void Awake()
    {
        metaballSystem = MetaballSystem2D.GetInstance();
    }
}
