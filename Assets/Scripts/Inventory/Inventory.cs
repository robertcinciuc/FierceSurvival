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


}
