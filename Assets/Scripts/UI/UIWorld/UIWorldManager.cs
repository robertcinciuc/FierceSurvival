using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIWorldManager : MonoBehaviour {
    
    public Camera cameraMap;
    public Camera cameraWorld;
    public Button lookAtMapButton;
    
    private LookAtMap lookAtMap;
    
    void Start(){
    }

    void Update(){
    }
    
    public void setup(){
        lookAtMap = gameObject.GetComponent<LookAtMap>();
        lookAtMap.setup(cameraMap, cameraWorld);
    }
    
}
