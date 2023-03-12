using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour {

    private Coordinate index;
    private Biome biome;
    private Material material;

    void Start() {
        
    }

    void Update() {
        
    }
    
    //Public methods

    public void setupRegion(Coordinate index, Biome biome, List<Material> biomeMaterials){
        this.index = index;
        this.biome = biome;
        this.material = biomeMaterials[0];
    }

    public Material getMaterial() {
        return material;
    }
}
