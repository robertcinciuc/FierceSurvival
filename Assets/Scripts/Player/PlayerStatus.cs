using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public Map map;
    public int maxEnergy = 100;

    private Region currentRegion;
    private int energy;

    void Start() {
        
    }

    void Update() {
        Debug.Log(currentRegion.getIndex().getColumn() + " " + currentRegion.getIndex().getRow());
    }

    //Public methods

    public void setup(Region currentRegion) {
        this.currentRegion = currentRegion;
        this.energy = 100;
    }

    public void goToNeighboringRegion(Direction direction) {
        if(energy <= 0) {
            markGameOver("loss of energy");
            return;
        }

        energy -= 30;
        if (energy <= 0) {
            energy = 0;
        }
        currentRegion = map.goToNeighboringRegion(direction);
    }

    public void setCurrentRegion(Region currentRegion) {
        this.currentRegion = currentRegion;
    }

    public float getEnergyPercentage() {
        return 100f * energy / maxEnergy;
    }

    //Private methods

    private void markGameOver(string reason) {
        Debug.Log("Game over: " + reason);
    }
}
