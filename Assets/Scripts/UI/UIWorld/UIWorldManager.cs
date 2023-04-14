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
    private VisualElement energyBarOverlay;

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
        goNorthButton.clicked += () => goIntoDirection(Direction.North);

        Button goNorthEastButton = root.Q<Button>("GoNorthEast");
        goNorthEastButton.clicked += () => goIntoDirection(Direction.NorthEast);

        Button goSouthEastButton = root.Q<Button>("GoSouthEast");
        goSouthEastButton.clicked += () => goIntoDirection(Direction.SouthEast);

        Button goSouthButton = root.Q<Button>("GoSouth");
        goSouthButton.clicked += () => goIntoDirection(Direction.South);

        Button goSouthWestButton = root.Q<Button>("GoSouthWest");
        goSouthWestButton.clicked += () => goIntoDirection(Direction.SouthWest);

        Button goNorthWestButton = root.Q<Button>("GoNorthWest");
        goNorthWestButton.clicked += () => goIntoDirection(Direction.NorthWest);

        energyBarOverlay = root.Q("EnergyBarOverlay");
        energyBarOverlay.style.width = new StyleLength(Length.Percent(100));
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

    private void goIntoDirection(Direction direction) {
        playerStatus.goToNeighboringRegion(direction);
        updateEnergyUI();
    }

    private void updateEnergyUI() {
        float energyPercentage = playerStatus.getEnergyPercentage();
        energyBarOverlay.style.width = new StyleLength(Length.Percent(energyPercentage));
    }

}
