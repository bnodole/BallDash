using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    public Transform levelHolder;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            if (collision.transform.GetSiblingIndex() == 1)
            {
                levelHolder.GetChild(0).transform.position = levelHolder.GetChild(3).position + new Vector3(0, 0, 150);
                levelHolder.GetChild(0).SetSiblingIndex(3);
            }
        }
    }
}
