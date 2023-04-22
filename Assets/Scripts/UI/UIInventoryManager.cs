using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class UIInventoryManager : MonoBehaviour {

    public PlayerStatus playerStatus;
    public UIWorldManager uiWorldManager;
    public Inventory inventory;

    private VisualElement root;
    private Label nbJerky;
    private Label nbWaterBottle;

    void Start() {
    }

    void Update() {
    }

    private void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = false;

        //Jerky
        Button consumeJerkyButton = root.Q<Button>("Jerky");
        consumeJerkyButton.clicked += () => feedPlayer(typeof(Jerky));

        nbJerky = root.Q<Label>("NbJerky");
        nbJerky.text = inventory.getNbItemsByType(typeof(Jerky)).ToString();

        //Water bottle
        Button drinkWaterBottle = root.Q<Button>("WaterBottle");
        drinkWaterBottle.clicked += () => hydratePlayer(typeof(WaterBottle));
        
        nbWaterBottle = root.Q<Label>("NbWaterBottle");
        nbWaterBottle.text = inventory.getNbItemsByType(typeof(WaterBottle)).ToString();

        Button lookAtWorldButton = root.Q<Button>("LookAtWorld");
        lookAtWorldButton.clicked += () => lookAtWorld();
    }

    //Public methods
    
    public void enableInventoryUI() {
        root.visible = true;
    }

    public void updateJerkyCount() {
        nbJerky.text = inventory.getNbItemsByType(typeof(Jerky)).ToString();
    }

    public void updateWaterBottleCount() {
        nbWaterBottle.text = inventory.getNbItemsByType(typeof(WaterBottle)).ToString();
    }

    //Private methods

    private void feedPlayer(System.Type nourishmentType) {
        if(inventory.getNbItemsByType(nourishmentType) <= 0) {
            Debug.Log("No " + nourishmentType + " left");
            return;
        }

        playerStatus.feedPlayer(Jerky.nourishmentValue);
        inventory.useItem(nourishmentType);
        uiWorldManager.updateNourishmentUI();
        nbJerky.text = inventory.getNbItemsByType(nourishmentType).ToString();
    }
    
    private void hydratePlayer(System.Type hydroItemType) {
        if(inventory.getNbItemsByType(hydroItemType) <= 0) {
            Debug.Log("No " + hydroItemType + " left");
            return;
        }

        playerStatus.hydratePlayer(Jerky.nourishmentValue);
        inventory.useItem(hydroItemType);
        uiWorldManager.updateHydrationUI();
        nbWaterBottle.text = inventory.getNbItemsByType(hydroItemType).ToString();
    }

    public void lookAtWorld() {
        root.visible = false;
        uiWorldManager.enableWorldUI();
    }
}
