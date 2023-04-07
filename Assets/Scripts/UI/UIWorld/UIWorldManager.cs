using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIWorldManager : MonoBehaviour {
    
    public Camera cameraMap;
    public Camera cameraWorld;
    
    void Start(){
    }

    void Update(){
    }
    
    public void setup(){
    }

    private void OnEnable() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button lookAtMapButton = root.Q<Button>("lookAtMap");

        lookAtMapButton.clicked += () => lookAtMap();
    }

    public void lookAtMap() {
        cameraWorld.enabled = true;
        cameraMap.enabled = false;
    }

}
