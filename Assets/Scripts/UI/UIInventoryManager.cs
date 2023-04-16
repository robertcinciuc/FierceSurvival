using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class UIInventoryManager : MonoBehaviour {

    public PlayerStatus playerStatus;
    public UIWorldManager uiWorldManager;
    public Inventory inventory;

    private VisualElement root;
    private Label nbNourishmentItems;

    void Start() {
    }

    void Update() {
    }

    private void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = false;

        Button nourishmentItemButton = root.Q<Button>("NourishmentItem");
        nourishmentItemButton.clicked += () => feedPlayer();

        nbNourishmentItems = root.Q<Label>("NbNourishmentItems");
        nbNourishmentItems.text = inventory.getNbNourishmentItems().ToString();

        Button lookAtWorldButton = root.Q<Button>("LookAtWorld");
        lookAtWorldButton.clicked += () => lookAtWorld();
    }

    //Public methods
    
    public void enableInventoryUI() {
        root.visible = true;
    }


    //Private methods

    private void feedPlayer() {
        if(inventory.getNbNourishmentItems() <= 0) {
            Debug.Log("No jerky left");
            return;
        }

        playerStatus.feedPlayer(20);
        inventory.consumeNourishmentItem(typeof(Jerky), 1);
        uiWorldManager.updateNourishmentUI();
        nbNourishmentItems.text = inventory.getNbNourishmentItems().ToString();
    }

    public void lookAtWorld() {
        root.visible = false;
        uiWorldManager.enableWorldUI();
    }
}
