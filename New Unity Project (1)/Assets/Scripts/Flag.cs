using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] RandomColorGenerator randomColorGenerator;
    private void OnEnable()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = randomColorGenerator.GetBodyColor;
    }

   
    void Update()
    {
        
    }
}
