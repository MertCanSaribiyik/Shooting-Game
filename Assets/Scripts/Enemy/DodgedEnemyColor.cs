using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgedEnemyColor : MonoBehaviour {
    [SerializeField] private Color color;

    private void Awake() {
        GetComponent<MeshRenderer>().material.color = color;
    }
}