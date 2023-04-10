using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIWorldManager : MonoBehaviour {
    
    public Camera cameraMap;
    public Camera cameraWorld;
    public UIMapManager uiMapManager;
    public PlayerStatus playerStatus;

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

        Button goNorthButton = root.Q<Button>("GoNorth");
        goNorthButton.clicked += () => goNorth();
    }

    //Public methods

    public void enableWorldUI() {
        root.visible = true;
    }

    //Private methods

    private void lookAtMap() {
        cameraWorld.enabled = false;
        cameraMap.enabled = true;
        root.visible = false;
        uiMapManager.enableMapUI();
    }

    private void goNorth() {
        playerStatus.goToNeighboringRegion(Direction.North);
    }

}
