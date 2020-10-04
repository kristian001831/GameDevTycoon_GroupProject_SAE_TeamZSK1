using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public string Name;
    public enum EGenre { Adventure, FPS, Horror, Platformer, RPG, Simulation, Sports};
    public EGenre Genre;
    public float Price;
    public float InvestedAmount;
}
