using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatsUI : MonoBehaviour
{
    public GameObject UI;

    public Sprite[] towerImageArray;
    public Sprite[] towerElementArray;

    private Tile targetTile;

    public Text damageText;
    public Text rangeText;
    public Text firerateText;
    public Text passiveText;
    public Text nameText;

    public Image towerImage;
    public Image towerElement;
    public Sprite background;

    void Update(){
        if(targetTile!=null){
            if(targetTile.tower!=null){

            getPassiveText(targetTile.tower);

            damageText.text = "Damage: " + targetTile.tower.damage.ToString();
            rangeText.text = "Range: " + targetTile.tower.range.ToString();

            string rate = string.Format(targetTile.tower.fireRate % 1 == 0 ? "{0:0}" : "{0:0.00}", targetTile.tower.fireRate);
            firerateText.text = "Fire Rate: " + rate;
            
            nameText.text = targetTile.tower.name.Substring(0, targetTile.tower.name.Length-7);

            //Tower Picture
            foreach(Sprite towerSprite in towerImageArray){
                if(targetTile.tower.name.Contains(towerSprite.name)){
                    towerImage.sprite = towerSprite;
                }
            }
            
            //Tower Type Picture
            foreach(Sprite elementImage in towerElementArray){
                if(targetTile.tower.element.Contains(elementImage.name)){
                    Debug.Log("element: " + targetTile.tower.element);
                    towerElement.sprite = elementImage;
                }
            } 
            if(targetTile.tower.element == ""){
                towerElement.sprite = towerElementArray[4];
            }
        }
        }
    }
    public void SetTargetTile(Tile tile){
        targetTile = tile;
        if(targetTile.tower!=null){
            // if(targetTile.tower.name.Contains("Swampert")){

            // }
            UI.SetActive(true);
        }

    }
    
    public void Hide(){
        UI.SetActive(false);
    }

    public void getPassiveText(Tower tower){

        if(tower.name.Contains("Blastoise")){
            passiveText.text = "Increased fire rate";
        }
        if(tower.name.Contains("Charizard")){
            passiveText.text = "Attacks also deal damage to nearby enemies";
        }
        if(tower.name.Contains("Venusaur")){
            passiveText.text = "Increased attack power";
        }
        if(tower.name.Contains("Alakazam")){
            passiveText.text = "Increased attack range";
        }
        if(tower.name.Contains("Swampert")){
            passiveText.text = "Enemies hit are slowed";
        }
        if(tower.name.Contains("Tornandus")){
            passiveText.text = "Deals damage to all enemies caught in wind blast";
        }
        if(tower.name.Contains("Glalie")){
            passiveText.text = "Chill: Enemies have a 50% of being mildly slowed or dramatically slowed";
        }
        if(tower.name.Contains("Gengar")){
            passiveText.text = "Curse: Enemies have decreased armor";
        }
        if(tower.name.Contains("Rotom")){
            passiveText.text = "Paralyze: Enemies have a chance to be stunned";
        }
        if(tower.name.Contains("Nidoking")){
            passiveText.text = "Poison: Enemies take additional damage over time";
        }
        if(tower.name.Contains("Heatran")){
            passiveText.text = "Enemies hit are slowed";
        }
        if(tower.name.Contains("Darkrai")){
            passiveText.text = "Drowsy: Enemies are slowed and have a chance to be stunned";
        }
        if(tower.name.Contains("Xerneas")){
            passiveText.text = "Fairy Aura: Attacks ignore enemy armor";
        }
        if(tower.name.Contains("Palkia")){
            passiveText.text = "Spacial Rend: Enemies hit have a random chance for a random slow";
        }
        if(tower.name.Contains("ballTower")){
            passiveText.text = "A basic pokeball tower";
        }
        if(tower.name.Contains("Chansey")){
            passiveText.text = "Attacks also deal damage to nearby enemies";
        }
        if(tower.name.Contains("Meowth")){
            passiveText.text = "Increased fire rate";
        }

    }



}
