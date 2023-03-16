using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Visibility { Near, Far };

public abstract class Feature : MonoBehaviour {

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

    public abstract string getName();
}
