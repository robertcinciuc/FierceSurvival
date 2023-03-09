using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public int nbRegionsRow;
    public int nbRegionsCol;
    public GameObject regionPrefab;

    private float width { get; set; }
    private float height { get; set; }
    private Dictionary<Coordinate, GameObject> regions; 

    void Start() {
        Vector3 extents = GetComponent<Renderer>().bounds.extents;
        width = extents.x;
        height = extents.y;

        setupRegions();
    }

    void Update() {
        
    }

    private void setupRegions() {
        for (int i = 0; i < nbRegionsRow; i++) {
            for (int j = 0; j < nbRegionsCol; j++) {
                Coordinate coord = new Coordinate(i, j);
                Instantiate(regionPrefab, new Vector3(i * 2.0f, 0, 0), new Quaternion(-0.71f, 0, 0, 0.71f));
            }
        }
    }
}
