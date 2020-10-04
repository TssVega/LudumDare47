using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

public class City : MonoBehaviour {

    public Tile roadTile;
    public GameObject[] buildings;
    public GameObject lightPoles;
    public Color daySkyColor;
    public Color nightSkyColor;
    private readonly float dayLightIntensity = 1f;
    private readonly float nightLightIntensity = 0.2f;

    private void GenerateCity() {
    
    }
}
