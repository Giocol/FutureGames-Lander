using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Ship {
    // Class that contains all the ship's status
    public class ShipComputer : MonoBehaviour {

        [SerializeField] private ShipHull shipHull;
        [SerializeField] private float timeBeforeRestartAfterDeath = 3;
        [SerializeField] private GameObject deathUI;
        private bool isShipDestroyed;
        private float timeSpentInLevel;

        private void Awake() {
            shipHull.RestoreMaxHullHp();
            isShipDestroyed = false;
            timeSpentInLevel = 0;
        }

        private void Update() {
            timeSpentInLevel += Time.deltaTime;
        }

        public void OnLanding() {
            Debug.Log("Landed!");
            SceneUtils.LoadNextScene();

            ScoreboardUtils.WriteToScoreboard(SceneManager.GetActiveScene().name, timeSpentInLevel, SceneManager.GetActiveScene().buildIndex);
        }

        public void OnTakeDamage(int damage) {
            shipHull.TakeDamage(damage, out isShipDestroyed);

            if(isShipDestroyed) {
                StartCoroutine(OnShipDestroyed());
            }
            Debug.Log($"Took damage, {shipHull.HullHealth} HP remaining");
        }

        public void RepairHull(int hpRepaired) {
            shipHull.RepairHull(hpRepaired);
        }

        private IEnumerator OnShipDestroyed() {
            Debug.Log("Crashed!");
            gameObject.GetComponent<PlayerInputHandler>().enabled = false; //take control away from the player
            deathUI.SetActive(true);
            //Explosion animation, then restart the game
            yield return new WaitForSeconds(timeBeforeRestartAfterDeath);
            Init.InitGame();
        }
    }
}
