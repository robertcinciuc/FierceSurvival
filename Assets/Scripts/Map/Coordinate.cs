using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate {

    private int row;
    private int column;

    public Coordinate(int row, int column) {
        this.row = row;
        this.column = column;
    }

    public int getRow() {
        return row;
    }

    public int getColumn() {
        return column;
    }

    public override int GetHashCode() {
        return row.GetHashCode() * 17 + column.GetHashCode();
    }
    
    public override bool Equals(object otherCoordinate) {
        if(otherCoordinate.GetType() != typeof(Coordinate)) {
            return false;
        }

        return this.GetHashCode() == ((Coordinate)otherCoordinate).GetHashCode();
    }
}
