using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDelete : MonoBehaviour
{
    GameObject uni;
    Vector3 uniPosi;

    // Start is called before the first frame update
    void Start()
    {
        uni = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        uniPosi = uni.transform.position;

        if (this.transform.position.z + 10 < uniPosi.z)
        {
            Destroy(this.gameObject);
        }
    }
}
