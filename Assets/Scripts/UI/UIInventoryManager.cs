using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class UIInventoryManager : MonoBehaviour {

    public PlayerStatus playerStatus;
    public UIWorldManager uiWorldManager;
    public Inventory inventory;

    private VisualElement root;

    void Start() {
    }

    void Update() {
    }

    private void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = false;

        Button nourishmentItemButton = root.Q<Button>("NourishmentItem");
        nourishmentItemButton.clicked += () => feedPlayer();
        
        Button lookAtWorldButton = root.Q<Button>("LookAtWorld");
        lookAtWorldButton.clicked += () => lookAtWorld();
    }

    //Public methods
    
    public void enableInventoryUI() {
        root.visible = true;
    }


    //Private methods

    private void feedPlayer() {
        playerStatus.feedPlayer(20);
        uiWorldManager.updateNourishmentUI();
    }

    public void lookAtWorld() {
        root.visible = false;
        uiWorldManager.enableWorldUI();
    }
}
