using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    
    public Map map;
    public Camera worldCamera;
    public UIWorldManager uiWorldManager;
    
    void Start() {
        map.setupMap();

        uiWorldManager.setup();

        worldCamera.GetComponent<AudioListener>().enabled = false;
        worldCamera.enabled = false;
    }

    void Update() {
        
    }
}
