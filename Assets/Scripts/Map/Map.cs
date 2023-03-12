using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public int nbRegionsRow;
    public int nbRegionsCol;
    public BiomeManager biomeManager;

    private float mapHalfWidth;
    private float mapHalfHeight;
    private Dictionary<Coordinate, GameObject> tiles;

    void Start() {
        tiles = new Dictionary<Coordinate, GameObject>();

        if (!biomeManager.getIsSetup()) {
            biomeManager.setupBiomeMaterials();
        }

        Vector3 extents = GetComponent<Renderer>().bounds.extents;
        mapHalfWidth = extents.x;
        mapHalfHeight = extents.y;

        setupRegions();
    }

    void Update() {
        
    }

    private void setupRegions() {
        float hexagonRadiusIn = mapHalfHeight / nbRegionsRow;
        float hexagonRadiusOut = hexagonRadiusIn / Mathf.Cos(Mathf.PI / 180f * 30);

        for (int i = 0; i < nbRegionsCol; i++) {
            for (int j = 0; j < nbRegionsRow; j++) {
                if (i % 2 == 0 && j == nbRegionsRow - 1) {
                    continue;
                }

                GameObject tile = new GameObject();
                Region region = tile.AddComponent<Region>();
                ForestConiferous forestConiferous = tile.AddComponent<ForestConiferous>();
                Coordinate coord = new Coordinate(i, j);
                region.setupRegion(coord, forestConiferous, biomeManager.getMaterialsForBiome(forestConiferous.GetType()));
                setupHexagonRendering(tile, hexagonRadiusOut, j, i, region.getMaterial());

                tiles.Add(coord, tile);
            }
        }
    }

    private void setupHexagonRendering(GameObject tile, float radiusOut, int row, int col, Material regionMaterial) {
        tile.AddComponent<MeshFilter>();
        tile.AddComponent<MeshRenderer>();
        HexRenderer hexRenderer = tile.AddComponent<HexRenderer>();
        hexRenderer.setupHexagon(radiusOut, new Vector3(0, 0, 0), regionMaterial);

        Vector3 mapCenter = gameObject.transform.position;
        float xShift = - radiusOut * col / 2;
        float yShift = 0;
        if(col % 2 == 0) {
            yShift = -hexRenderer.getRadiusIn();
        }
        float xPos = mapCenter.x - mapHalfWidth + radiusOut + col * radiusOut * 2 + xShift; 
        float yPos = mapCenter.y + mapHalfHeight - hexRenderer.getRadiusIn() - row * hexRenderer.getRadiusIn() * 2 + yShift;
        tile.transform.position = new Vector3(xPos, yPos, 0);
    }
    

}
