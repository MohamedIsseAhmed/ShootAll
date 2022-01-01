using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorGenerator : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer skinnedMesh;
    public Color  GetBodyColor { get { return skinnedMesh.sharedMaterial.color; } }
    void Awake()
    {
        skinnedMesh.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Color GetColor()
    {
        return skinnedMesh.sharedMaterial.color;
    }
}
