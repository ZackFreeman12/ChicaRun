using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRot : MonoBehaviour
{

    public float rotSpeed = 50f;
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, rotSpeed * Time.deltaTime, 0f);
    }
}
