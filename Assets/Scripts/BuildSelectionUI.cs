using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BuildSelectionUI : MonoBehaviour {

    public GameObject ui;
    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;
    
    private Tile targetTile;

    private Button[] allButtons;

    public static List<string> fireList = new List<string>();
    public static List<string> waterList = new List<string>();
    public static List<string> grassList = new List<string>();
    public static List<string> psychicList = new List<string>();

    public static List<string> sameTowers = new List<string>();
    public static List<string> differentTowers = new List<string>();

    void Awake(){
        allButtons = GameObject.Find("UpgradePanel").GetComponentsInChildren<Button>(true);
    }

    public void SetTargetTile (Tile tile) {
        targetTile = tile;

        if (!targetTile.isFinalUpgrade) {
            // upgradeCost.text = "$" + targetTile.tower.cost;
            // upgradeButton.interactable = true;
        }
        else {
            upgradeCost.text = "Fully Upgraded!";
            upgradeButton.interactable = false;
        }

        // sellAmount.text = "$" + targetTile.tower.GetSellAmount();
        ui.SetActive(true);
        GetTowerUpgradeUI();
    }

    public void Hide () { 
        ui.SetActive(false);
    }

    public void UpgradeBlueprint (Tower tower) {
        targetTile.UpgradeTower(tower);
        BuildManager.instance.SelectTile(targetTile);
    }

    public void Sell () {
        Debug.Log("Sold!");
        targetTile.SellTower();
        BuildManager.instance.DeselectTile();
        ui.SetActive(false);
    }

    void GetTowerUpgradeUI () {

        GrabPossibleButtons();

        Button[] allUpgrades = targetTile.tower.possibleUpgrades;
        foreach(Button button in allButtons){
            if(button.gameObject.activeSelf == true && button.name != "Sell"){
                button.gameObject.SetActive(false);
            }
        }
        foreach(Button button in allButtons) {
            foreach(Button upgradeButton in allUpgrades){
                if(button.name == upgradeButton.name || button.name == "Sell"){
                    button.gameObject.SetActive(true);
                }
            }
        }
        foreach(Button button in allButtons){
            if(sameTowers.Contains(button.name) || button.name == "Sell"){
                button.interactable = true;
            }
            else{
                button.interactable = false;
            }
        }
    }

    void GrabPossibleButtons(){

            string GreatBlastoiseTower = "GreatBlastoiseTower";
            string GreatCharizardTower = "GreatCharizardTower";
            string GreatAlakazamTower = "GreatAlakazamTower";
            string GreatVenusaurTower = "GreatVenusaurTower";

            string UltraBlastoiseTower = "UltraBlastoiseTower";
            string UltraCharizardTower = "UltraCharizardTower";
            string UltraAlakazamTower = "UltraAlakazamTower";
            string UltraVenusaurTower = "UltraVenusaurTower";

            string MegaBlastoiseTower = "MegaBlastoiseTower";
            string MegaCharizardTower = "MegaCharizardTower";
            string MegaAlakazamTower = "MegaAlakazamTower";
            string MegaVenusaurTower = "MegaVenusaurTower";

            string SpecialSwampertTower = "SpecialSwampertTower";
            string SpecialTornandusTower = "SpecialTornandusTower";
            string SpecialGlalieTower = "SpecialGlalieTower";
            string SpecialGengarTower = "SpecialGengarTower";
            string SpecialRotomTower = "SpecialRotomTower";
            string SpecialNidokingTower = "SpecialNidokingTower";

            string AdvancedSwampertTower = "AdvancedSwampertTower";
            string AdvancedTornandusTower = "AdvancedTornandusTower";
            string AdvancedGlalieTower = "AdvancedGlalieTower";
            string AdvancedGengarTower = "AdvancedGengarTower";
            string AdvancedRotomTower = "AdvancedRotomTower";
            string AdvancedNidokingTower = "AdvancedNidokingTower";

            string EliteSwampertTower = "EliteSwampertTower";
            string EliteTornandusTower = "EliteTornandusTower";
            string EliteGlalieTower = "EliteGlalieTower";
            string EliteGengarTower = "EliteGengarTower";
            string EliteRotomTower = "EliteRotomTower";
            string EliteNidokingTower = "EliteNidokingTower";

            string RareHeatranTower = "RareHeatranTower";
            string RareDarkraiTower = "RareDarkraiTower";
            string RareXerneasTower = "RareXerneasTower";
            string RarePalkiaTower = "RarePalkiaTower";

            string MythicHeatranTower = "MythicHeatranTower";
            string MythicDarkraiTower = "MythicDarkraiTower";
            string MythicXerneasTower = "MythicXerneasTower";
            string MythicPalkiaTower = "MythicPalkiaTower";
                
            string[][] fire = { new string[]{"nothing"}, new string[] {SpecialTornandusTower, SpecialGengarTower, SpecialRotomTower, RareHeatranTower, RareDarkraiTower, RarePalkiaTower}, new string[]{AdvancedTornandusTower, AdvancedGengarTower, AdvancedRotomTower, MythicHeatranTower, MythicDarkraiTower, MythicPalkiaTower}, new string[]{EliteTornandusTower, EliteGengarTower, EliteRotomTower}};
            string[][] water = { new string[]{"nothing"}, new string[] {SpecialTornandusTower, SpecialSwampertTower, SpecialGlalieTower, RareHeatranTower, RareXerneasTower, RarePalkiaTower}, new string[]{AdvancedTornandusTower, AdvancedSwampertTower, AdvancedGlalieTower, MythicHeatranTower, MythicXerneasTower, MythicPalkiaTower}, new string[]{EliteTornandusTower, EliteSwampertTower, EliteGlalieTower}};
            string[][] grass = { new string[]{"nothing"}, new string[] {SpecialGengarTower, SpecialNidokingTower, SpecialSwampertTower, RareHeatranTower, RareDarkraiTower, RareXerneasTower}, new string[]{AdvancedGengarTower, AdvancedNidokingTower, AdvancedSwampertTower, MythicHeatranTower, MythicDarkraiTower, MythicXerneasTower}, new string[]{EliteGengarTower, EliteNidokingTower,EliteSwampertTower}};
            string[][] psychic = { new string[]{"nothing"}, new string[] {SpecialGlalieTower, SpecialNidokingTower, SpecialRotomTower, RareXerneasTower, RareDarkraiTower, RarePalkiaTower}, new string[]{AdvancedGlalieTower, AdvancedNidokingTower, AdvancedRotomTower, MythicXerneasTower, MythicDarkraiTower, MythicPalkiaTower}, new string[]{EliteGlalieTower, EliteNidokingTower, EliteRotomTower}};
        
            string[] fireLinear = new string[]{GreatCharizardTower, UltraCharizardTower, MegaCharizardTower};
            string[] waterLinear = new string[]{GreatBlastoiseTower, UltraBlastoiseTower, MegaBlastoiseTower};
            string[] grassLinear = new string[]{GreatVenusaurTower, UltraVenusaurTower, MegaVenusaurTower};
            string[] psychicLinear = new string[]{GreatAlakazamTower, UltraAlakazamTower, MegaAlakazamTower};

            string[] tertiaries = new string[]{RareDarkraiTower, RareHeatranTower, RarePalkiaTower, RareXerneasTower, MythicDarkraiTower, MythicHeatranTower, MythicPalkiaTower, MythicXerneasTower};
            string[] basicTowers = new string[]{"GreatballTower", "UltraballTower", "GreatMeowthTower", "UltraMeowthTower", "GreatChanseyTower", "UltraChanseyTower"};

        sameTowers.Clear();

        for(int i = 1; i<=PlayerProperties.fireLevel;i++){
            sameTowers.Add(fireLinear[i-1]);
            for(int j = 0; j<fire[i].Length;j++){
                fireList.Add(fire[i][j]);
            }
        }
        for(int i = 1; i<=PlayerProperties.waterLevel;i++){
            sameTowers.Add(waterLinear[i-1]);
            for(int j = 0; j<water[i].Length;j++){
                waterList.Add(water[i][j]);
            }
        }
        for(int i = 1; i<=PlayerProperties.grassLevel;i++){
            sameTowers.Add(grassLinear[i-1]);
            for(int j = 0; j<grass[i].Length;j++){
                grassList.Add(grass[i][j]);
            }
        }
        for(int i = 1; i<=PlayerProperties.psychicLevel;i++){
            sameTowers.Add(psychicLinear[i-1]);
            for(int j = 0; j<psychic[i].Length;j++){
                psychicList.Add(psychic[i][j]);
            }
        }

        for(int i = 0; i<basicTowers.Length;i++){
            sameTowers.Add(basicTowers[i]);
        }

        for(int i = 0; i<tertiaries.Length; i++){
            if(fireList.Contains(tertiaries[i]) && waterList.Contains(tertiaries[i]) && grassList.Contains(tertiaries[i])){
                sameTowers.Add(tertiaries[i]);
                fireList.Remove(tertiaries[i]);
                waterList.Remove(tertiaries[i]);
                grassList.Remove(tertiaries[i]);
            }
            else if(fireList.Contains(tertiaries[i]) && psychicList.Contains(tertiaries[i]) && grassList.Contains(tertiaries[i])){
                sameTowers.Add(tertiaries[i]);
                fireList.Remove(tertiaries[i]);
                psychicList.Remove(tertiaries[i]);
                grassList.Remove(tertiaries[i]);
            }
            else if(fireList.Contains(tertiaries[i]) && waterList.Contains(tertiaries[i]) && psychicList.Contains(tertiaries[i])){
                sameTowers.Add(tertiaries[i]);
                fireList.Remove(tertiaries[i]);
                waterList.Remove(tertiaries[i]);
                psychicList.Remove(tertiaries[i]);
            }
            else if(grassList.Contains(tertiaries[i]) && waterList.Contains(tertiaries[i]) && psychicList.Contains(tertiaries[i])){
                sameTowers.Add(tertiaries[i]);
                grassList.Remove(tertiaries[i]);
                waterList.Remove(tertiaries[i]);
                psychicList.Remove(tertiaries[i]);
            }
            else{
                fireList.Remove(tertiaries[i]);
                grassList.Remove(tertiaries[i]);
                waterList.Remove(tertiaries[i]);
                psychicList.Remove(tertiaries[i]);
            }
        }

        string[] fireArray = fireList.ToArray();
        string[] grassArray = grassList.ToArray();
        string[] psychicArray = psychicList.ToArray();

        for(int i = 0; i<fireArray.Length; i++){
            if(waterList.Contains(fireArray[i])){
                sameTowers.Add(fireArray[i]);
                waterList.Remove(fireArray[i]);
            }
            else{
                differentTowers.Add(fireArray[i]);
            }
        }
        
        string[] waterArray = waterList.ToArray();
        for(int i = 0; i<waterArray.Length;i++){
            differentTowers.Add(waterArray[i]);
        }

        
        for(int i = 0; i<grassArray.Length;i++){
            if(differentTowers.Contains(grassArray[i])){
                sameTowers.Add(grassArray[i]);
                grassList.Remove(grassArray[i]);
                differentTowers.Remove(grassArray[i]);
            }
        }

        for(int i = 0; i<grassList.Count;i++){
            differentTowers.Add(grassList[i]);
        }

        for(int i = 0; i<psychicArray.Length;i++){
            if(differentTowers.Contains(psychicArray[i])){
                sameTowers.Add(psychicArray[i]);
                psychicList.Remove(psychicArray[i]);
                differentTowers.Remove(psychicArray[i]);
            }
        }
        fireList.Clear();
        waterList.Clear();
        grassList.Clear();
        psychicList.Clear();
        differentTowers.Clear();
    }
}


