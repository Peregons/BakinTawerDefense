using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFrameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("floatingCube", 0, Random.Range(0, 1f));
    }


}