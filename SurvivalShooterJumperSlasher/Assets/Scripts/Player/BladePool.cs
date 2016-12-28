using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BladePool : MonoBehaviour {

    public int bladeCount;
    public GameObject blade;
    public List<GameObject> bladeArray;
    public GameObject bladePool;
    public Transform bladeSpawn;
    public Transform playerTransform;
    public float nextFire;
    public float fireRate;
    int stepper;

    // Use this for initialization
    void Start()
    {
        bladeCount = 1;
        //blade = (GameObject)Resources.Load("Blade");
        bladePool = GameObject.Find("BladePool");
        stepper = 0;

        fireRate = 1f;
        nextFire = 0f;

        GameObject temp;
        for (int i = 0; i < bladeCount; i++)
        {

            temp = (GameObject)Instantiate(
                    blade, 
                    new Vector3 (bladePool.transform.position.x, 
                                bladePool.transform.position.y+.35f, 
                                bladePool.transform.position.z+.5f), 
                    new Quaternion(0f,0f,0f,0f)
                );
            temp.transform.SetParent(bladePool.transform);
            //temp.SetActive(false);
            bladeArray.Add(temp);
        }
    }

    void FixedUpdate() {
        if (Input.GetButton("Fire2") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            SwingBlade();
        }
    }

    public void UpdateRotation() {
        playerTransform = GameObject.Find("Player").transform;
        for (int i = 0; i < bladeCount; i++) {
            bladeArray[i].transform.rotation = playerTransform.rotation;
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
