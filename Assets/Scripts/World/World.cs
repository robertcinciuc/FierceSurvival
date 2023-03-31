using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    
    public Map map;
    public Camera worldCamera;
    public UIWorldManager uiWorldManager;
    public UIMapManager uiMapManager;
        
    void Start() {
        map.setupMap();

        uiWorldManager.setup();
        uiMapManager.setup();
        
        worldCamera.GetComponent<AudioListener>().enabled = false;
        worldCamera.enabled = false;
    }

    void Update() {
        
    }
}
