using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { North, NorthEast, SouthEast, South, SouthWest, NorthWest };

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

    public void setupRegion(Coordinate index, Biome biome, List<Material> biomeMaterials, FeatureManager featureManager){
        setupDirectionalFeatures(featureManager);
        this.index = index;
        this.biome = biome;
        this.material = biomeMaterials[0];
    }

    public Coordinate getNeighboringCoordinate(Direction direction) {
        int isoNorthEastWest = 1;
        int isoSouthEastWest = 1;
        if (index.getColumn() % 2 == 0) {
            isoNorthEastWest = 0;
        } else {
            isoSouthEastWest = 0;
        }

        if(direction.Equals(Direction.North))
            return new Coordinate(index.getRow() - 1, index.getColumn());
        if(direction.Equals(Direction.NorthEast))
            return new Coordinate(index.getRow() - isoNorthEastWest, index.getColumn() + 1);
        if(direction.Equals(Direction.SouthEast))
            return new Coordinate(index.getRow() + isoSouthEastWest, index.getColumn() + 1);
        if(direction.Equals(Direction.South))
            return new Coordinate(index.getRow() + 1, index.getColumn());
        if(direction.Equals(Direction.SouthWest))
            return new Coordinate(index.getRow() + isoSouthEastWest, index.getColumn() - 1);
        if(direction.Equals(Direction.NorthWest))
            return new Coordinate(index.getRow() - isoNorthEastWest, index.getColumn() - 1);

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
    
    private void setupDirectionalFeatures(FeatureManager featureManager){
        features = new Dictionary<Direction, Feature>();
        System.Random randy = new System.Random();

        foreach (Direction direction in Enum.GetValues(typeof(Direction))) {
            int featureIndex = randy.Next(0, featureManager.getNbFeatures());

            Type featureType = featureManager.getFeature(featureIndex);
            Component feature = gameObject.AddComponent(featureType);
            ((Feature)feature).setupFeature();
            features.Add(direction, (Feature)feature);
        }
    }
}
