using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject homePanel;


    public static UIHandler Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        loginPanel.SetActive(true);
        homePanel.SetActive(false);
    }

    public void SwitchToHomePanel()
    {
        loginPanel.SetActive(false);
        homePanel.SetActive(true);
    }

    public void SwitchToLoginPanel()
    {
        loginPanel.SetActive(true);
        homePanel.SetActive(false);
    }


}
