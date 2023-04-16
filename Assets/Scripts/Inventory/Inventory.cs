using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

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

    public int getNbNourishmentItems() {
        return items[typeof(Jerky)].Count;
    }

    public void consumeNourishmentItem(System.Type nourishmentItemType, int nbConsumed) {
        for (int i = 0; i < nbConsumed; i++) {
            if (items[nourishmentItemType].Count > 0) {
                items[nourishmentItemType].RemoveAt(0);
            }
        }
    }

}
