using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponent : MonoBehaviour
{
    public List<GameObject> materials = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMaterial(GameObject material) 
    {
        if (!materials.Contains(material))
        {
            materials.Add(material);
            Debug.Log("Added material: " + material.name);
        }
    }
}
