using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public Map map;
    public int maxNourishment = 100;

    private Region currentRegion;
    private int nourishment;

    void Start() {
        
    }

    void Update() {
        Debug.Log(currentRegion.getIndex().getColumn() + " " + currentRegion.getIndex().getRow());
    }

    //Public methods

    public void setup(Region currentRegion) {
        this.currentRegion = currentRegion;
        this.nourishment = 100;
    }

    public void goToNeighboringRegion(Direction direction) {
        if(nourishment <= 0) {
            markGameOver("too little nourishment");
            return;
        }

        nourishment -= 30;
        if (nourishment <= 0) {
            nourishment = 0;
        }
        currentRegion = map.goToNeighboringRegion(direction);
    }

    public void setCurrentRegion(Region currentRegion) {
        this.currentRegion = currentRegion;
    }

    public float getNourishmentPercentage() {
        return 100f * nourishment / maxNourishment;
    }

    public void feedPlayer(int feedPoints) {
        if (this.nourishment + feedPoints > maxNourishment) {
            this.nourishment = maxNourishment;
            return;
        }

        this.nourishment += feedPoints;
    }

    //Private methods

    private void markGameOver(string reason) {
        Debug.Log("Game over: " + reason);
    }
}
