using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexRenderer : MonoBehaviour {

    private Material material;
    private float radiusOut;
    private float radiusIn;
    private Vector3 center;

    void Start() {
        
    }

    void Update() {
        drawHexagon();
    }

    //Public methods

    public void setupHexagon(float radiusOut, Vector3 center, Material material) {
        this.radiusOut = radiusOut;
        this.radiusIn = Mathf.Cos(Mathf.PI / 180f * 30) * radiusOut;
        this.center = center;
        this.material = material;
    }

    public float getRadiusIn() {
        return radiusIn;
    }

    //Private methods

    private void drawHexagon() {
        Vector3[] vertices = getHexagonVertices();
        var triangles = new int[] {
            0, 1, 2,
            0, 2, 3,
            0, 3, 4,
            0, 4, 5,
            0, 5, 6,
            0, 6, 1
        };

        var mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;
    }

    private Vector3[] getHexagonVertices() {
        Vector3[] vertices = new Vector3[7];
        float angle30Rad = Mathf.PI / 180f * 30;
        vertices[0] = center;
        vertices[1] = new Vector3(center.x + Mathf.Sin(angle30Rad) * radiusOut, center.y + radiusIn, center.z);
        vertices[2] = new Vector3(center.x + radiusOut, center.y, center.z);
        vertices[3] = new Vector3(center.x + Mathf.Sin(angle30Rad) * radiusOut, center.y - radiusIn, center.z);
        vertices[4] = new Vector3(center.x - Mathf.Sin(angle30Rad) * radiusOut, center.y - radiusIn, center.z);
        vertices[5] = new Vector3(center.x - radiusOut, center.y, center.z);
        vertices[6] = new Vector3(center.x - Mathf.Sin(angle30Rad) * radiusOut, center.y + radiusIn, center.z);

        return vertices;
    }
}
