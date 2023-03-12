using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public int nbRegionsRow;
    public int nbRegionsCol;
    public Dictionary<System.Type, List<Texture2D>> biomeTextures;
    public Material regionMaterial;

    private float mapHalfWidth { get; set; }
    private float mapHalfHeight { get; set; }
    private Dictionary<Coordinate, GameObject> regions;
    private float regionWidth;
    private float regionHeight;

    void Start() {
        regions = new Dictionary<Coordinate, GameObject>();
        setupBiomeTextures();
        
        Vector3 extents = GetComponent<Renderer>().bounds.extents;
        mapHalfWidth = extents.x;
        mapHalfHeight = extents.y;

        setupRegions2();
    }

    void Update() {
        
    }

    private void setupRegions2() {
        float hexagonRadiusIn = mapHalfHeight / nbRegionsRow;
        float hexagonRadiusOut = hexagonRadiusIn / Mathf.Cos(Mathf.PI / 180f * 30);

        for (int i = 0; i < nbRegionsCol; i++) {
            for (int j = 0; j < nbRegionsRow; j++) {
                if (i % 2 == 0 && j == nbRegionsRow - 1) {
                    continue;
                }

                GameObject hexagon = setupHexagon(hexagonRadiusOut, j, i);
                Coordinate coord = new Coordinate(i, j);
                Region region = hexagon.AddComponent<Region>();
                region.setupRegion(regionHeight, regionWidth, coord, biomeTextures);

                regions.Add(coord, hexagon);
            }
        }
    }

    private GameObject setupHexagon(float radiusOut, int row, int col) {
        GameObject hexagon = new GameObject();
        hexagon.AddComponent<MeshFilter>();
        hexagon.AddComponent<MeshRenderer>();
        HexRenderer hexRenderer = hexagon.AddComponent<HexRenderer>();
        hexRenderer.setupHexagon(radiusOut, new Vector3(0, 0, 0), regionMaterial);

        Vector3 mapCenter = gameObject.transform.position;
        float xShift = - radiusOut * col / 2;
        float yShift = 0;
        if(col % 2 == 0) {
            yShift = -hexRenderer.getRadiusIn();
        }
        float xPos = mapCenter.x - mapHalfWidth + radiusOut + col * radiusOut * 2 + xShift; 
        float yPos = mapCenter.y + mapHalfHeight - hexRenderer.getRadiusIn() - row * hexRenderer.getRadiusIn() * 2 + yShift;
        hexagon.transform.position = new Vector3(xPos, yPos, 0);

        return hexagon;
    }
    
    private void setupBiomeTextures(){
      biomeTextures = new Dictionary<System.Type, List<Texture2D>>();
      // TODO:
      // biomeTextures.Add(Forest.GetType(), new List<>())
    }
}
