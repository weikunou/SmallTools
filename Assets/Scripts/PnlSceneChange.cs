using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PnlSceneChange : MonoBehaviour
{
    Button btnS1, btnS2;

    private void Awake()
    {
        btnS1 = transform.Find("BtnS1").GetComponent<Button>();
        btnS2 = transform.Find("BtnS2").GetComponent<Button>();
    }

    private void Start()
    {
        btnS1.onClick.AddListener(()=>
        {
            LoadSceneManager.instance.LoadTargetScene("S2", "S1");
        });
        btnS2.onClick.AddListener(()=>
        {
            LoadSceneManager.instance.LoadTargetScene("S1", "S2");
        });
    }
}
