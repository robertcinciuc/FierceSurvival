using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour {

    private Map map;

    void Start() {
    }

    void Update() {
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            map.setCurrentTile(gameObject);
        }
    }

    public void setupClickableTile(Map map) {
        this.map = map;
    }
}
