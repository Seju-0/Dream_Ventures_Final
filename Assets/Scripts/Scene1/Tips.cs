using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips : MonoBehaviour
{
    [SerializeField] private List<GameObject> TipsPanel;

    public void OpenTips()
    {
        foreach (GameObject component in TipsPanel)
        {
            component.SetActive(true);
        }
    }
    public void CloseBTN()
    {
        foreach (GameObject component in TipsPanel)
        {
            component.SetActive(false);
        }
    }
}
