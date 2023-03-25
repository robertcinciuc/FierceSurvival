using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    
    public Map map;
    public Camera worldCamera;

    void Start() {
        map.setupMap();

        worldCamera.GetComponent<AudioListener>().enabled = false;
        worldCamera.enabled = false;
    }

    void Update() {
        
    }
}
