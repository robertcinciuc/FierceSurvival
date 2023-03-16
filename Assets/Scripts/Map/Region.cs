using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour {

    private Coordinate index;
    private Biome biome;
    private Material material;
    //Features start from north-east clockwise
    private Feature[] features;

    void Start() {
        
    }

    void Update() {
        
    }
    
    //Public methods

    public void setupRegion(Coordinate index, Biome biome, List<Material> biomeMaterials){
        this.index = index;
        this.biome = biome;
        this.material = biomeMaterials[0];
        features = new Feature[6];
        for (int i = 0; i < features.Length; i++) {
            features[i] = new Valley();
            features[i].setupFeature();
        }
    }

    public Material getMaterial() {
        return material;
    }
}
