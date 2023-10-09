using Ship;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
    [SerializeField] private ShipHull hull;
    [SerializeField] private Image hullHealthFill;

    private void Update() {
        hullHealthFill.fillAmount = 1 - (float) hull.HullHealth / hull.MaxHullHealth;
    }
}
