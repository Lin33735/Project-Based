using System.Collections;
using UnityEngine;

public class StoveScript : MonoBehaviour
{

    //public GameObject Stove;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private IEnumerator StoveColor()
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        yield return null;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacted with stove");
            StartCoroutine(StoveColor());
        }
    }
}
