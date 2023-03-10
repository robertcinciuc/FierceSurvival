using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public int nbRegionsRow;
    public int nbRegionsCol;
    public GameObject regionPrefab;
    public Dictionary<Type, List<Texture2D>> biomeTextures;

    private float width { get; set; }
    private float height { get; set; }
    private Dictionary<Coordinate, GameObject> regions;
    private float regionWidth;
    private float regionHeight;

    void Start() {
        regions = new Dictionary<Coordinate, GameObject>();
        setupBiomeTextures();
        
        Vector3 extents = GetComponent<Renderer>().bounds.extents;
        width = extents.x;
        height = extents.y;

        setupRegions();
    }

    void Update() {
        
    }

    private void setupRegions() {
        regionWidth =  width / nbRegionsCol;
        regionHeight = 4 * height / (4 * nbRegionsRow - (nbRegionsRow - 1));
        Vector3 prefabRegionExtents = regionPrefab.GetComponent<MeshFilter>.mesh.bounds.extents;
        float horizScale = regionWidth / prefabRegionExtents.x;
        float verticScale = regionHeight / prefabRegionExtents.y;
                
        for (int i = 0; i < nbRegionsRow; i++) {
            for (int j = 0; j < nbRegionsCol; j++) {
                float xPos = (i % nbRegionsCol) * regionWidth + regionWidth / 2;
                float yPos = height - regionHeight / 2 - regionHeight * j;
                
                GameObject region = Instantiate(regionPrefab, new Vector3(xPos, yPos, 0), new Quaternion(-0.71f, 0, 0, 0.71f));
                region.transform.localScale = new Vector3(horizScale, verticScale, 1);
                
                Coordinate coord = new Coordinate(i, j);
                Region regionComp = region.AddComponent<Region>();
                regionComp.setupRegion(regionHeight, regionWidth, coord, biomeTextures);
                
                regions.Add(coord, region);
            }
        }
    }
    
    private void setupBiomeTextures(){
      biomeTextures = new Dictionary<Type, List<Texture2D>>();
      // TODO:
      // biomeTextures.Add(Forest.GetType(), new List<>())
    }
}
