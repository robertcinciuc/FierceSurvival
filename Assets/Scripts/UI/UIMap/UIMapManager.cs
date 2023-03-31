using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIMapManager : MonoBehaviour {
    
    public Camera cameraMap;
    public Camera cameraWorld;
    public Button lookAtWorldButton;
    
    private LookAtWorld lookAtWorld;
    
    void Start(){
    }

    void Update(){
    }
    
    public void setup(){
        lookAtWorld = gameObject.GetComponent<LookAtWorld>();
        lookAtWorld.setup(cameraMap, cameraWorld);
    }
    
}
