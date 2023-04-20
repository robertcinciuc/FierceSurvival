using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIWorldManager : MonoBehaviour {
    
    public Camera cameraMap;
    public Camera cameraWorld;
    public UIMapManager uiMapManager;
    public UIInventoryManager uiInventoryManager;
    public PlayerStatus playerStatus;
    public World world;

    private VisualElement root;
    private VisualElement nourishmentBarOverlay;
    private VisualElement hydrationBarOverlay;

    void Start(){
    }

    void Update(){
    }
    
    private void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = false;

        Button lookAtMapButton = root.Q<Button>("LookAtMap");
        lookAtMapButton.clicked += () => lookAtMap();

        //Navigation
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

        //Exploration
        Button exploreNorthButton = root.Q<Button>("ExploreNorth");
        exploreNorthButton.clicked += () => exploreDirection(Direction.North);

        Button exploreNorthEastButton = root.Q<Button>("ExploreNorthEast");
        exploreNorthEastButton.clicked += () => exploreDirection(Direction.NorthEast);

        Button exploreSouthEastButton = root.Q<Button>("ExploreSouthEast");
        exploreSouthEastButton.clicked += () => exploreDirection(Direction.SouthEast);

        Button exploreSouthButton = root.Q<Button>("ExploreSouth");
        exploreSouthButton.clicked += () => exploreDirection(Direction.South);

        Button exploreSouthWestButton = root.Q<Button>("ExploreSouthWest");
        exploreSouthWestButton.clicked += () => exploreDirection(Direction.SouthWest);

        Button exploreNorthWestButton = root.Q<Button>("ExploreNorthWest");
        exploreNorthWestButton.clicked += () => exploreDirection(Direction.NorthWest);

        //Status
        nourishmentBarOverlay = root.Q("NourishmentBarOverlay");
        nourishmentBarOverlay.style.width = new StyleLength(Length.Percent(100));

        hydrationBarOverlay = root.Q("HydrationBarOverlay");
        hydrationBarOverlay.style.width = new StyleLength(Length.Percent(100));

        Button lookAtInventoryButton = root.Q<Button>("LookAtInventory");
        lookAtInventoryButton.clicked += () => lookAtInventory();

    }

    //Public methods

    public void enableWorldUI() {
        root.visible = true;
    }

    public void updateNourishmentUI() {
        float nourishmentPercentage = playerStatus.getNourishmentPercentage();
        nourishmentBarOverlay.style.width = new StyleLength(Length.Percent(nourishmentPercentage));
    }
    
    public void updateHydrationUI() {
        float hydrationPercentage = playerStatus.getHydrationPercentage();
        hydrationBarOverlay.style.width = new StyleLength(Length.Percent(hydrationPercentage));
    }

    //Private methods

    private void lookAtMap() {
        cameraWorld.enabled = false;
        cameraMap.enabled = true;
        root.visible = false;
        uiMapManager.enableMapUI();
    }

    private void goIntoDirection(Direction direction) {
        bool navigated = playerStatus.goToNeighboringRegion(direction);
        if (navigated) {
            updateNourishmentUI();
            updateHydrationUI();
        }
    }

    private void lookAtInventory() {
        root.visible = false;
        uiInventoryManager.enableInventoryUI();
    }

    private void exploreDirection(Direction direction) {
        Feature feature = playerStatus.exploreDirection(direction);

        if (feature != null) {
            world.offerNourishmentItemByChance();
            updateNourishmentUI();
            updateHydrationUI();
            Debug.Log("Explored " + direction + "; found feature: " + feature.getName());
        }
    }

}
