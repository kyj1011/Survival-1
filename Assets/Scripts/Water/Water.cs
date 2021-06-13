using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public static bool isWater = false;

    [SerializeField] private float waterDrag;
    private float originDrag;

    [SerializeField] private Color waterColor;
    [SerializeField] private float waterFogDensity;

    private Color originColor;
    private float originFogDensity;

    // Start is called before the first frame update
    void Start()
    {
        originColor = RenderSettings.fogColor;
        originFogDensity = RenderSettings.fogDensity;

        originDrag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="Player")
        {
            GetWater(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GetOutWater(other);
        }
    }

    private void GetWater(Collider _Player)
    {
        isWater = true;
        _Player.transform.GetComponent<Rigidbody>().drag = waterDrag;

        RenderSettings.fogColor = waterColor;
        RenderSettings.fogDensity = waterFogDensity;
    }

    private void GetOutWater(Collider _Player)
    {
        if(isWater)
        {
            isWater = false;
            _Player.transform.GetComponent<Rigidbody>().drag = originDrag;

            RenderSettings.fogColor = originColor;
            RenderSettings.fogDensity = waterFogDensity;
        }
    }
}
