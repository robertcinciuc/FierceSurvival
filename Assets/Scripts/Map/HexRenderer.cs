using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexRenderer : MonoBehaviour {

    private Material material;
    private float radiusOut;
    private float radiusIn;
    private Vector3 center;
    private int[] triangles;
    private Vector3[] vertices;
    private Vector2[] uv;

    void Start() {
    }

    void Update() {
    }

    //Public methods

    public void setupHexagon(float radiusOut, Vector3 center, Material material) {
        triangles = new int[] {
            0, 1, 2,
            0, 2, 3,
            0, 3, 4,
            0, 4, 5,
            0, 5, 6,
            0, 6, 1
        };
        vertices = new Vector3[7];
        uv = new Vector2[7];

        this.radiusOut = radiusOut;
        this.radiusIn = Mathf.Cos(Mathf.PI / 180f * 30) * radiusOut;
        this.center = center;
        this.material = material;

        drawHexagon();
    }

    public float getRadiusIn() {
        return radiusIn;
    }

    //Private methods

    private void drawHexagon() {
        setupHexagonVertices();
        setupUVs();

        var mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;
    }

    private void setupHexagonVertices() {
        float angle30Rad = Mathf.PI / 180f * 30;
        vertices[0] = center;
        vertices[1] = new Vector3(center.x + Mathf.Sin(angle30Rad) * radiusOut, center.y + radiusIn, center.z);
        vertices[2] = new Vector3(center.x + radiusOut, center.y, center.z);
        vertices[3] = new Vector3(center.x + Mathf.Sin(angle30Rad) * radiusOut, center.y - radiusIn, center.z);
        vertices[4] = new Vector3(center.x - Mathf.Sin(angle30Rad) * radiusOut, center.y - radiusIn, center.z);
        vertices[5] = new Vector3(center.x - radiusOut, center.y, center.z);
        vertices[6] = new Vector3(center.x - Mathf.Sin(angle30Rad) * radiusOut, center.y + radiusIn, center.z);
    }

    private void setupUVs() {
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);
        uv[4] = new Vector2(1, 1);
        uv[5] = new Vector2(0, 1);
        uv[6] = new Vector2(1, 1);
    }

}
