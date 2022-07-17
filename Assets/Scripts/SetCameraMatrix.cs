using UnityEngine;
using System.Collections;

public class SetCameraMatrix : MonoBehaviour
{
    private Camera _camera;
    Matrix4x4 mat = new Matrix4x4();
    Matrix4x4 startMat = new Matrix4x4();

    public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;
    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();
        startMat = _camera.projectionMatrix;
    }

    // Update is called once per frame
    void Update()
    {
        mat = startMat;

        mat[0, 0] += m1;
        mat[1, 0] += m2;
        mat[2, 0] += m3;
        mat[3, 0] += m4;
        mat[0, 1] += m5;
        mat[1, 1] += m6;
        mat[2, 1] += m7;
        mat[3, 1] += m8;
        mat[0, 2] += m9;
        mat[1, 2] += m10;
        mat[2, 2] += m11;
        mat[3, 2] += m12;
        mat[0, 3] += m13;
        mat[1, 3] += m14;
        mat[2, 3] += m15;
        mat[3, 3] += m16;

        _camera.projectionMatrix = mat;
    }
}