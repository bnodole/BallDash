using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    public Transform levelHolder;
    Transform coinHolder;
    public Transform path;
    public Transform path1;
    public bool switchPath = true;

    public BallScript ballScript;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Base"))
        {
            Transform palmLevel = collision.transform.parent;

            if (palmLevel.GetSiblingIndex() == 2)
            {
                Debug.Log("kasbdkjd");
                levelHolder.GetChild(0).transform.position = levelHolder.GetChild(levelHolder.childCount-1).position + new Vector3(0, 0, 150);
                coinHolder = levelHolder.GetChild(0).GetChild(0);
                for (int i = 0; i < coinHolder.childCount; i++)
                {
                    coinHolder.GetChild(i).gameObject.SetActive(true);
                }
                levelHolder.GetChild(0).SetSiblingIndex(levelHolder.childCount - 1);
            }
            if(palmLevel == levelHolder)
            {
                switchPath = true;
            }

            
        }
    }
}
