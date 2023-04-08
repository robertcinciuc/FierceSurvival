using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIWorldManager : MonoBehaviour {
    
    public Camera cameraMap;
    public Camera cameraWorld;
    public UIMapManager uiMapManager;

    private VisualElement root;

    void Start(){
    }

    void Update(){
    }
    
    private void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = false;

        Button lookAtMapButton = root.Q<Button>("lookAtMap");

        lookAtMapButton.clicked += () => lookAtMap();
    }

    public void lookAtMap() {
        cameraWorld.enabled = false;
        cameraMap.enabled = true;
        root.visible = false;
        uiMapManager.enableMapUI();
    }

    public void enableWorldUI() {
        root.visible = true;
    }

}
