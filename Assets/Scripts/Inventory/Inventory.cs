using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public UIInventoryManager uiInventoryManager;

    private Dictionary<System.Type, List<Object>> items;
    
    void Start() {
    }

    void Update() {
        
    }

    //Public methods
    
    public void setup() {
        items = new Dictionary<System.Type, List<Object>>();
        items.Add(typeof(Jerky), new List<Object>());

        items[typeof(Jerky)].Add(new Jerky());
        items[typeof(Jerky)].Add(new Jerky());
        items[typeof(Jerky)].Add(new Jerky());
    }

    public int getNbNourishmentItems(System.Type nourishmentType) {
        return items[nourishmentType].Count;
    }

    public void consumeNourishmentItem(System.Type nourishmentItemType) {
        if (items[nourishmentItemType].Count > 0) {
            items[nourishmentItemType].RemoveAt(0);
        }
    }
    
    public void addItem(System.Type itemType, int nbItems) {
        if (!items.ContainsKey(itemType)) {
            items.Add(itemType, new List<Object>());
        }

        for (int i = 0; i < nbItems; i++) {
            object item = System.Activator.CreateInstance(itemType);
            items[itemType].Add((Object)item);
        }

        uiInventoryManager.updateNourishmentItemCount();
    }

}
