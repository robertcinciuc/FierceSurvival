using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public PlayerStatus playerStatus;
    public Inventory inventory;
    
    void Start() {
        
    }

    void Update() {
        
    }

    //Public methods

    public void setup(Region currentRegion) {
        playerStatus.setup(currentRegion);
        inventory.setup();
    }
}
