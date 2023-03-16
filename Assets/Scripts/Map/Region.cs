using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { North, NortEast, SouthEast, South, SouthWest, NorthWest };

public class Region : MonoBehaviour {
    
    private Coordinate index;
    private Biome biome;
    private Material material;
    //Features start from north clockwise
    private Feature[] features;

    void Start() {
        
    }

    void Update() {
        
    }
    
    //Public methods

    public void setupRegion(Coordinate index, Biome biome, List<Material> biomeMaterials){
        this.index = index;
        this.biome = biome;
        this.material = biomeMaterials[0];
        features = new Feature[6];
        for (int i = 0; i < features.Length; i++) {
            Valley feature = gameObject.AddComponent<Valley>();
            feature.setupFeature();
            features[i] = feature;
        }
    }

    public Coordinate getNeighboringCoordinate(Direction direction) {
        if(direction.Equals(Direction.North))
            return new Coordinate(index.getRow() - 1, index.getColumn());
        if(direction.Equals(Direction.NortEast))
            return new Coordinate(index.getRow() - 1, index.getColumn() + 1);
        if(direction.Equals(Direction.SouthEast))
            return new Coordinate(index.getRow(), index.getColumn() + 1);
        if(direction.Equals(Direction.South))
            return new Coordinate(index.getRow() + 1, index.getColumn());
        if(direction.Equals(Direction.SouthWest))
            return new Coordinate(index.getRow() + 1, index.getColumn() - 1);
        if(direction.Equals(Direction.NorthWest))
            return new Coordinate(index.getRow() - 1, index.getColumn() - 1);

        return null;
    }

    public Material getMaterial() {
        return material;
    }

    public Feature[] getFeatures() {
        return features;
    }
}
