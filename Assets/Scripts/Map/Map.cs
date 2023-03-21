using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public int nbRegionsRow;
    public int nbRegionsCol;
    public BiomeManager biomeManager;

    private float mapHalfWidth;
    private float mapHalfHeight;
    private Dictionary<int, GameObject> tiles;
    private GameObject currentTile;
    private float tileZDelta = -0.1f;

    void Start() {
        tiles = new Dictionary<int, GameObject>();
        biomeManager.setupBiomeMaterials();

        Vector3 extents = GetComponent<Renderer>().bounds.extents;
        mapHalfWidth = extents.x;
        mapHalfHeight = extents.y;

        setupTiles();
    }

    void Update() {
        
    }
    
    // Public methods
    
    public void setCurrentTile(GameObject tile){
        currentTile = tile;
        Region currentRegion = currentTile.GetComponent<Region>();
        Debug.Log("current index: " + currentRegion.getIndex().getRow() + " " + currentRegion.getIndex().getColumn());
        Debug.Log("current feature north: " + currentRegion.getDirectionalFeature(Direction.North));

        Region neighboringRegion = getNeighboringRegion(currentRegion, Direction.NortEast);
        if (neighboringRegion == null) {
            Debug.Log("Neighbor doesn't exist");
        } else {
            Debug.Log("neighbor's index: " + neighboringRegion.getIndex().getRow() + " " + currentRegion.getIndex().getColumn());
            Debug.Log("neighbor's north feature: " + neighboringRegion.getDirectionalFeature(Direction.North));
        }
    }
    
    // Private methods
    
    private void setupTiles() {
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
                Coordinate coord = new Coordinate(j, i);
                region.setupRegion(coord, forestConiferous, biomeManager.getMaterialsForBiome(forestConiferous.GetType()));
                setupHexagonRendering(tile, hexagonRadiusOut, j, i, region.getMaterial());

                MeshCollider meshCollider = tile.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = tile.GetComponent<MeshFilter>().sharedMesh;
                
                ClickableTile clickableTile = tile.AddComponent<ClickableTile>();
                clickableTile.setupClickableTile(this);
                
                tiles.Add(coord.GetHashCode(), tile);
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
        tile.transform.position = new Vector3(xPos, yPos, gameObject.transform.position.z + tileZDelta);
    }
    
    private Region getNeighboringRegion(Region currentRegion, Direction direction) {
        Coordinate neighborCoordinate = currentRegion.getNeighboringCoordinate(Direction.NortEast);
        if (!tiles.ContainsKey(neighborCoordinate.GetHashCode())) {
            return null;
        }
        GameObject neighboringTile = tiles[neighborCoordinate.GetHashCode()];
        return neighboringTile.GetComponent<Region>();
    }

}
