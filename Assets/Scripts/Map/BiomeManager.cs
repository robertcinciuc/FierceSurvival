using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeManager : MonoBehaviour {

    public Dictionary<System.Type, List<Material>> biomeMaterials;
    public List<Material> forestConiferousMaterials;

    private bool isSetup = false;

    void Start() {
        setupBiomeMaterials();
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

    public bool getIsSetup() {
        return isSetup;
    }

    public void setupBiomeMaterials() {
        biomeMaterials = new Dictionary<System.Type, List<Material>>();
        biomeMaterials.Add(typeof(ForestConiferous), forestConiferousMaterials);
        isSetup = true;
    }

    //Private methods

}
