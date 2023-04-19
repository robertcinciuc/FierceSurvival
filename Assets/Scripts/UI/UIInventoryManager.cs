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

    void Start() {
    }

    void Update() {
    }

    private void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = false;

        Button consumeJerkyButton = root.Q<Button>("Jerky");
        consumeJerkyButton.clicked += () => feedPlayer(typeof(Jerky));

        nbJerky = root.Q<Label>("NbJerky");
        nbJerky.text = inventory.getNbNourishmentItems(typeof(Jerky)).ToString();

        Button lookAtWorldButton = root.Q<Button>("LookAtWorld");
        lookAtWorldButton.clicked += () => lookAtWorld();
    }

    //Public methods
    
    public void enableInventoryUI() {
        root.visible = true;
    }

    public void updateNourishmentItemCount() {
        nbJerky.text = inventory.getNbNourishmentItems(typeof(Jerky)).ToString();
    }

    //Private methods

    private void feedPlayer(System.Type nourishmentType) {
        if(inventory.getNbNourishmentItems(nourishmentType) <= 0) {
            Debug.Log("No " + nourishmentType + " left");
            return;
        }

        playerStatus.feedPlayer(Jerky.nourishmentValue);
        inventory.consumeNourishmentItem(nourishmentType);
        uiWorldManager.updateNourishmentUI();
        nbJerky.text = inventory.getNbNourishmentItems(nourishmentType).ToString();
    }

    public void lookAtWorld() {
        root.visible = false;
        uiWorldManager.enableWorldUI();
    }
}
