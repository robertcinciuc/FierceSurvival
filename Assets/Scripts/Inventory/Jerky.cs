using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerky : NourishmentItem {

    private int nourishmentValue = 20;

    public override int getNourishmentValue() {
        return nourishmentValue;
    }

}
