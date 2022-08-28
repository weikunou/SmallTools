using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PnlMain : MonoBehaviour
{
    private Transform contentLeft;
    private List<Transform> btnsLeft = new List<Transform>(10);

    private void Awake()
    {
        contentLeft = transform.Find("ScrollRect_Left/Viewport/Content");
    }

    private void Start()
    {
        InitLeftView();
    }

    public void InitLeftView()
    {
        GameObject obj = Resources.Load<GameObject>("Prefabs/UI/BtnLeft");
        for(int i = 0; i < 10; i++)
        {
            GameObject child = Instantiate(obj, contentLeft);
            btnsLeft.Add(child.transform);
        }
    }
}
