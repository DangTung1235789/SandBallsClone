using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigMapAuto : MonoBehaviour
{
    [Header("Config Properties")]
    [SerializeField] int heightDestrictibleTerrain = 0;

    [Header("Component")]
    [SerializeField] DestructibleTerrain destructibleTerrain;
    [SerializeField] GameObject quad;

    
    [Button]
    private void StartConfig() 
    {
        destructibleTerrain.resolutionY = heightDestrictibleTerrain - 5;
        quad.transform.localScale = new Vector3(quad.transform.localScale.x, heightDestrictibleTerrain, quad.transform.localScale.z);

    }
}
