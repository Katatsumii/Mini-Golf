using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();
    
    public void SetActiveLevel(int i)
    {
        foreach(GameObject level in levels)
        {
            level.SetActive(false);
        }
        i--;
        levels[i].SetActive(true);
    }
}
