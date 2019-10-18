﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour //PointerEnterHandler, IPointerExitHandler
{
    public Tower pokeballTower;
    public Tower charizardTower;
    public Tower venusaurTower;
    public Tower alakazamTower;
    public Tower blastoiseTower;

    public Button fireTower;
    public Button waterTower;
    public Button grassTower;
    public Button psychicTower;
    public GameObject availabilityUI;

    BuildManager buildManager;

    void Start () {
        buildManager = BuildManager.instance;
    }

    void Update(){
       if (PlayerProperties.fireLevel != 0) {
          fireTower.interactable = true;
       }
       if(PlayerProperties.fireLevel == 0){
          fireTower.interactable = false;
       }
       if (PlayerProperties.waterLevel != 0) {
          waterTower.interactable = true;
       }
       if (PlayerProperties.waterLevel == 0) {
          waterTower.interactable = false;
       }
       if (PlayerProperties.grassLevel != 0) {
          grassTower.interactable = true;
       }
       if (PlayerProperties.grassLevel == 0) {
          grassTower.interactable = false;
       }
       if (PlayerProperties.psychicLevel != 0) {
          psychicTower.interactable = true;
       }
       if (PlayerProperties.psychicLevel == 0) {
          psychicTower.interactable = false;
       }
    }

    public void SelectPokeballTower () {
        buildManager.SelectTowerToBuild(pokeballTower);
    }

    public void SelectCharizardTower () {
        buildManager.SelectTowerToBuild(charizardTower);
    }

    public void SelectAlakazamTower () {
        buildManager.SelectTowerToBuild(alakazamTower);
    }

    public void SelectVenusaurTower () {
        buildManager.SelectTowerToBuild(venusaurTower);
    }

    public void SelectBlastoiseTower () {
        buildManager.SelectTowerToBuild(blastoiseTower);
    }

//     public void OnPointerEnter(PointerEventData eventData){
//        if(eventData.pointerEnter.name == "Charizard"){
//            if(PlayerProperties.fireLevel==0){
//                //availabilityUI.SetActive(true);
//            }
//            else{
//                availabilityUI.SetActive(false);
//            }
//        }
//        if(eventData.pointerEnter.name == "Blastois"){
//            if(PlayerProperties.waterLevel==0){
//                availabilityUI.SetActive(true);
//            }
//            else{
//                availabilityUI.SetActive(false);
//            }
//        }
//        if(eventData.pointerEnter.name == "Venusaur"){
//            if(PlayerProperties.grassLevel==0){
//                availabilityUI.SetActive(true);
//            }
//            else{
//                availabilityUI.SetActive(false);
//            }
//        }
//        if(eventData.pointerEnter.name == "Alakazam"){
//            if(PlayerProperties.psychicLevel==0){
//                availabilityUI.SetActive(true);
//            }
//            else{
//                availabilityUI.SetActive(false);
//            }
//        }
//    }

//     public void OnPointerExit(PointerEventData eventData){
//        availabilityUI.SetActive(false);
//    }
}