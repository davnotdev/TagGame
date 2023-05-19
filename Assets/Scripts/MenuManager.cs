//PISGHETTI
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager inst;
    public float beginTime;

    void Awake()
    {
        inst = this;
    }

    public void BeginGame(float beginTime)
    {
        inst.beginTime = beginTime;
        inst.transform.parent = null;
        DontDestroyOnLoad(inst.gameObject);
        SceneManager.LoadScene("ActualScene");
    }
}
