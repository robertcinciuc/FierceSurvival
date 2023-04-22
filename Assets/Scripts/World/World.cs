using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    
    public Map map;
    public Camera worldCamera;
    public Player player;
    public Inventory inventory;
        
    void OnEnable() {
        map.setupMap();

        worldCamera.GetComponent<AudioListener>().enabled = false;
        worldCamera.enabled = false;
        player.setup(map.getCurrentRegion());
    }

    void Update() {
        
    }

    //Public methods

    public void offerJerkyByChance() {
        System.Random random = new System.Random();
        int chanceToGetJerky = random.Next(0, 2);
        
        if (chanceToGetJerky == 1) {
           inventory.addItem(typeof(Jerky), 1);
            Debug.Log("Found a Jerky");
        }
    }
    
    public void offerWaterBottleByChance() {
        System.Random random = new System.Random();
        int chanceToGetWaterBottle = random.Next(0, 2);
        
        if (chanceToGetWaterBottle == 1) {
           inventory.addItem(typeof(WaterBottle), 1);
            Debug.Log("Found a Water Bottle");
        }
    }
}
