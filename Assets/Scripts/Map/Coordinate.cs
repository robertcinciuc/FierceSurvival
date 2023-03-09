using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate {

    private int row { get; set; }
    private int column { get; set; }

    public Coordinate(int row, int column) {
        this.row = row;
        this.column = column;
    }
}
