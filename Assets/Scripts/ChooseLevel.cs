using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Level1()
    {
        level1.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Level2()
    {
        level2.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Level3()
    {
        level3.SetActive(true);
        gameObject.SetActive(false);
    }
}
