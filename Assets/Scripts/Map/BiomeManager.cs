using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeManager : MonoBehaviour {

    public Dictionary<System.Type, List<Material>> biomeMaterials;
    public List<Material> forestConiferousMaterials;
    public List<Material> cityMaterials;

    void Start() {
    }

    void Update() {
        
    }
    
    //Public methods

    public Dictionary<System.Type, List<Material>> getBiomeMaterials() {
        return biomeMaterials;
    }

    public List<Material> getMaterialsForBiome(System.Type biomeType) {
        return biomeMaterials[biomeType];
    }

    public void setupBiomeMaterials() {
        biomeMaterials = new Dictionary<System.Type, List<Material>>();
        biomeMaterials.Add(typeof(ForestConiferous), forestConiferousMaterials);
        biomeMaterials.Add(typeof(City), cityMaterials);
    }

    //Private methods

}
