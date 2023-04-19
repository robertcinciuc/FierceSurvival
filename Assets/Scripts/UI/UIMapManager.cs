using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIMapManager : MonoBehaviour {
    
    public Camera cameraMap;
    public Camera cameraWorld;
    public UIWorldManager uiWorldManager;

    private VisualElement root;

    void Start(){
    }

    void Update(){
    }

    private void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = true;

        Button lookAtMapButton = root.Q<Button>("LookAtWorld");

        lookAtMapButton.clicked += () => lookAtWorld();
    }

    public void lookAtWorld() {
        cameraMap.enabled = false;
        cameraWorld.enabled = true;
        root.visible = false;
        uiWorldManager.enableWorldUI();
    }

    public void enableMapUI() {
        root.visible = true;
    }

}
