using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BladePool : MonoBehaviour {

    public int bladeCount;
    public GameObject blade;
    public List<GameObject> bladeArray;
    public GameObject bladePool;
    public Transform bladeSpawn;

    int stepper;

    // Use this for initialization
    void Start()
    {
        bladeCount = 1;
        //blade = (GameObject)Resources.Load("Blade");
        bladePool = GameObject.Find("BladePool");
        stepper = 0;

        GameObject temp;
        for (int i = 0; i < bladeCount; i++)
        {

            temp = (GameObject)Instantiate(
                    blade, bladePool.transform.position, new Quaternion(0f,0f,0f,0f)
                );
            temp.transform.SetParent(bladePool.transform);
            temp.SetActive(false);
            bladeArray.Add(temp);
        }
    }

    void FixedUpdate() {
        if (Input.GetButton("Fire2")) {
            SwingBlade();
        }
    }

    public void SwingBlade()
    {
        Debug.Log("SwingBlade()");
        for (int i = 0; i < bladeCount; i++)
        {
            if (bladeArray[i].activeSelf) { }
            else {
                bladeArray[i].SetActive(true);
                i = bladeCount + 1;
            }
        }
    }
}
