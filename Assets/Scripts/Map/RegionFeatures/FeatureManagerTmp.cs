using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureManager : MonoBehaviour {

    public List<System.Type> features;

    void Start() {
    }

    void Update() {
    }
    
    //Public methods

    public Syste.Type getFeature(int index) {
        return features[index];
    }
    
    public int getNbFeatures(){
        return features.Count;
    }
    
    public void setupFeatureManager() {
        features = new List<Feature>();
        features.Add(typeof(Pond));
        features.Add(typeof(Lake));
        features.Add(typeof(River));
        features.Add(typeof(CliffTop));
        features.Add(typeof(CliffBase));
        features.Add(typeof(Hill));
        features.Add(typeof(Valley));
        features.Add(typeof(Cave));
    }

    //Private methods

}
