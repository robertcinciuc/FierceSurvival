using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LookAtMap : MonoBehaviour {
    
    private Camera cameraMap;
    private Camera cameraWorld;
    private Button lookAtMapButton;
    
    void Start(){
    }

    void Update(){
    }
    
    public void setup(Camera cameraMap, Camera cameraWorld){
        this.cameraMap = cameraMap;
        this.cameraWorld = cameraWorld;
        this.lookAtMapButton = gameObject.GetComponent<Button>();
        this.lookAtMapButton.onClick.AddListener(lookAtMap);
    }

    public void lookAtMap() {
        cameraWorld.enabled = false;
        cameraMap.enabled = true;
    }
}
