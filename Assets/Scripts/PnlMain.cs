using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PnlMain : MonoBehaviour
{
    private Transform contentLeft;
    private Transform contentRight;
    private List<Transform> btnsLeft = new List<Transform>(10);
    private Dictionary<int, bool> initViews = new Dictionary<int, bool>();

    private void Awake()
    {
        contentLeft = transform.Find("ScrollRect_Left/Viewport/Content");
        contentRight = transform.Find("ScrollRect_Right/Viewport/Content");
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
            Button btn = child.transform.GetComponent<Button>();
            int j = i;
            btn.onClick.AddListener(()=>
            {
                InitRightView(j);
            });
            btnsLeft.Add(child.transform);
        }
    }

    public void InitRightView(int index)
    {
        switch(index)
        {
            case 0:
                if(!initViews.ContainsKey(0))
                {
                    ShowSceneChangeView();
                    initViews.Add(0, true);
                }
                break;
            default:
                Debug.Log("暂时没有");
                break;
        }
    }

    public void ShowSceneChangeView()
    {
        GameObject obj = Resources.Load<GameObject>("Prefabs/UI/PnlSceneChange");
        Instantiate(obj, contentRight);
    }
}
