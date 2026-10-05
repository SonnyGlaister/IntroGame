using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject Player;
    private GameObject[] Pickups;
    private float[] PickupDistances;
    private float currentPickupDistance;
    private float smallestPickupDistance;
    private GameObject closestPickup;
    private float closestPickupDistance;
    public TextMeshProUGUI closestPickupDistanceText;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        Pickups = GameObject.FindGameObjectsWithTag("PickUp");
        PickupDistances = new float[Pickups.Length];
        smallestPickupDistance = 100000;
    }

    // Update is called once per frame
    void Update()
    {
        i = 0;
        foreach(GameObject Pickup in Pickups)
        {
            currentPickupDistance = Vector3.Distance(Player.transform.position, Pickup.transform.position);
            PickupDistances[i] = currentPickupDistance;

            if (currentPickupDistance < smallestPickupDistance)
            {
                smallestPickupDistance = currentPickupDistance;
            }
            i++;
        }

        closestPickupDistanceText.text = "Distance: " + smallestPickupDistance.ToString();
    }
}
