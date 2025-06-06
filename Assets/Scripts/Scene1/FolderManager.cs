using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : MonoBehaviour
{
    [SerializeField] private List<GameObject> Folder_Components;
    [SerializeField] private List<GameObject> Questions_Panel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenFolder()
    {
        foreach (GameObject component in Folder_Components)
        {
            component.SetActive(true);
        }
        foreach (GameObject component in Questions_Panel)
        {
            component.SetActive(false);
        }
    }

    public void CloseBTN()
    {
        foreach (GameObject component in Folder_Components)
        {
            component.SetActive(false);
        }
        foreach (GameObject component in Questions_Panel)
        {
            component.SetActive(true);
        }
    }
    public void AcceptBTN()
    {
        Debug.Log("Loan Accepted");
    }
    public void RejectBTN()
    {
        Debug.Log("Loan Rejected");
    }
}

