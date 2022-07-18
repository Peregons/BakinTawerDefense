using UnityEngine;

namespace Utility
{
    public class SetCameraMatrix : MonoBehaviour
    {
        void Awake()
        {
            var cam =  Camera.main;
            var mat = cam.projectionMatrix;
            mat[1, 0] = -0.0358f;
            cam.projectionMatrix = mat;
        }
    }
}