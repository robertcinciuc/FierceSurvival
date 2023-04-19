using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public Map map;
    public int maxNourishment = 100;
    public int maxHydration = 100;

    private Region currentRegion;
    private int nourishment;
    private int hydration;

    void Start() {
        
    }

    void Update() {
        Debug.Log(currentRegion.getIndex().getColumn() + " " + currentRegion.getIndex().getRow());
    }

    //Public methods

    public void setup(Region currentRegion) {
        this.currentRegion = currentRegion;
        this.nourishment = 100;
        this.hydration = 100;
    }

    public bool goToNeighboringRegion(Direction direction) {
        return !isGameOver();

        if (nourishment - 30 <= 0) {
            markInsufficientResources("nourishment", "navigation");
            return false;
        }
        if(hydration - 40 <= 0) {
            markInsufficientResources("hydration", "navigation");
            return false;
        }

        nourishment -= 30;
        hydration -= 40;
        currentRegion = map.goToNeighboringRegion(direction);
        return true;
    }
    
    public Feature exploreDirection(Direction direction) {
        if (isGameOver()) {
            return null;
        }

        if (nourishment - 10 <= 0) {
            markInsufficientResources("nourishment", "exploration");
            return null;
        }
        if (hydration - 15 <= 0) {
            markInsufficientResources("hydration", "exploration");
            return null;
        }

        nourishment -= 10;
        hydration -= 15;
        return map.exploreDirection(direction);
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

    private void markInsufficientResources(string resource, string reason) {
        Debug.Log("Insufficient " + resource + " for " + reason);
    }

    private bool isGameOver() {
        if (nourishment <= 0) {
            markGameOver("depleted nourishment");
            return true;
        }

        if (hydration <= 0) {
            markGameOver("depleted hydration");
            return true;
        }

        return false;
    }

}
