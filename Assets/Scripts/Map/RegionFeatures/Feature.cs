using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feature : MonoBehaviour {

    public enum Visibility { Near, Far};

    private Visibility visibility;

    void Start() {
        
    }

    void Update() {
        
    }

    public void setupFeature() {
        visibility = Visibility.Near;
    }

    public Visibility getVisibility() {
        return visibility;
    }
}
