﻿using Ship;
using System;
using UnityEngine;

namespace Environment {
    public class LandingZone : MonoBehaviour{

        private void OnCollisionEnter(Collision other) {
            ShipComputer shipComputer = other.gameObject.GetComponent<ShipComputer>();
            if(shipComputer) {
                shipComputer.OnLanding();
            }
        }

    }
}
