using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public Map map;

    private Region currentRegion;

    void Start() {
        
    }

    void Update() {
        Debug.Log(currentRegion.getIndex().getColumn() + " " + currentRegion.getIndex().getRow());
    }

    //Public methods

    public void setup(Region currentRegion) {
        this.currentRegion = currentRegion;
    }

    public void goToNeighboringRegion(Direction direction) {
        currentRegion = map.goToNeighboringRegion(direction);
    }

    public void setCurrentRegion(Region currentRegion) {
        this.currentRegion = currentRegion;
    }

    //Private methods
}
