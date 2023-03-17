using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { North, NortEast, SouthEast, South, SouthWest, NorthWest };

public class Region : MonoBehaviour {
    
    private Coordinate index;
    private Biome biome;
    private Material material;
    private Dictionary<Direction, Feature> features;
    
    void Start() {
        
    }

    void Update() {
        
    }
    
    //Public methods

    public void setupRegion(Coordinate index, Biome biome, List<Material> biomeMaterials){
        setupDirectionalFeatures();
        this.index = index;
        this.biome = biome;
        this.material = biomeMaterials[0];
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
    
    public Feature getDirectionalFeature(Direction direction){
      return features[direction];
    }

    public Material getMaterial() {
        return material;
    }

    public Dictionary<Direction, Feature> getFeatures() {
        return features;
    }

    public Coordinate getIndex() {
        return index;
    }
    
    // Private methods
    
    private void setupDirectionalFeatures(){
        features = new Dictionary<Direction, Feature>();
        foreach (Direction direction in Enum.GetValues(typeof(Direction))) {
            Valley feature = gameObject.AddComponent<Valley>();
            feature.setupFeature();
            features.Add(direction, feature);
        }
    }
}
