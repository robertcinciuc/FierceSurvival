using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour {

    private float height { get; set; }
    private float width { get; set; }
    private Coordinate index { get; set; }
    private Biome biome { get; set; }
    private int idTexture {get; set; }

    void Start() {
        
    }

    void Update() {
        
    }
    
    public void setupRegion(float height, float width, Coordinate index, Dictionary<System.Type, List<Texture2D>> biomeTextures){
      this.height = height;
      this.width = width;
      this.index = index;
      // TODO:
      // GetComponent<Renderer>().material.SetTexture();
    }
}
