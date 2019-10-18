using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ElementSelectionUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text message;
    public GameObject UI;
    public GameObject SelectUI;
    public GameObject BlurUI;
    public Button elementButton;

    
    public Transform fireEnemy;
    public Transform waterEnemy;
    public Transform grassEnemy;
    public Transform psychicEnemy;
    public Transform spawnPoint;

    private string[] elements = {"Fire", "Water", "Grass", "Psychic", "Interest"};

    

    // Start is called before the first frame update
    
    void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            toggle();
        }
        if(PlayerProperties.elementToken==0 && SelectUI.activeSelf == true){
            if(SelectUI.activeSelf == true){
                foreach(string element in elements){
                
                    GameObject.Find(element).GetComponent<Button>().interactable = false;
                 }
            }
        }
        else if(PlayerProperties.elementToken>0 && SelectUI.activeSelf == true){
            if(SelectUI.activeSelf == true){
                 foreach(string element in elements){
                     if(element == "Fire"){
                         if(PlayerProperties.fireIsDead){
                             GameObject.Find(element).GetComponent<Button>().interactable = true;
                         }
                     }
                     if(element == "Water"){
                         if(PlayerProperties.waterIsDead){
                             GameObject.Find(element).GetComponent<Button>().interactable = true;
                         }
                     }
                     if(element == "Grass"){
                        if(PlayerProperties.grassIsDead){
                            GameObject.Find(element).GetComponent<Button>().interactable = true;
                        }
                     }
                     if(element == "Psychic"){
                         if(PlayerProperties.psychicIsDead){
                             GameObject.Find(element).GetComponent<Button>().interactable = true;
                         }
                     }
                     GameObject.Find("Interest").GetComponent<Button>().interactable = true;
                 }
            }
        }
    }

    public void toggle(){
        SelectUI.SetActive(!SelectUI.activeSelf);
        BlurUI.SetActive(!BlurUI.activeSelf);
    }

        public void OnPointerEnter(PointerEventData eventData){
            UI.SetActive(true);
            if(eventData.pointerEnter.tag == "Fire"){
                if(PlayerProperties.fireLevel == 3){
                    message.text="Max Fire Level";
                    elementButton.interactable = false;
                }
                else{
                    message.text = "Fire " + (PlayerProperties.fireLevel+1).ToString();
                }
            }
            else if (eventData.pointerEnter.tag == "Water"){
                if(PlayerProperties.waterLevel == 3){
                    message.text="Max Water Level";
                    elementButton.interactable = false;
                }
                else{
                    message.text = "Water " + (PlayerProperties.waterLevel+1).ToString();
                }
            }
            else if(eventData.pointerEnter.tag == "Grass"){
                if(PlayerProperties.grassLevel == 3){
                    message.text="Max Grass Level";
                    elementButton.interactable = false;
                }
                else{
                    message.text = "Grass " + (PlayerProperties.grassLevel+1).ToString();
                }
            }
            else if(eventData.pointerEnter.tag == "Psychic"){
                if(PlayerProperties.psychicLevel == 3){
                    message.text="Max Psychic Level";
                    elementButton.interactable = false;
                }
                else{
                    message.text = "Psychic " + (PlayerProperties.psychicLevel+1).ToString();
                }
            }
            else if(eventData.pointerEnter.tag == "Interest"){
                message.text = ((PlayerProperties.Interest+1)*10).ToString() + "% interest";
            }


        }
        public void OnPointerExit(PointerEventData eventData){
            UI.SetActive(false);
        }

        public void chooseFire(){
            GameObject.Find("Fire").GetComponent<Button>().interactable = false;
            GameObject.Find("FireLevel").GetComponent<Text>().text = "";
            SelectUI.SetActive(false);
            BlurUI.SetActive(false);
            Instantiate(fireEnemy, spawnPoint.position, spawnPoint.rotation);
            PlayerProperties.fireIsDead = false;
            PlayerProperties.elementToken--;
        
        }
        public void chooseWater(){
            GameObject.Find("Water").GetComponent<Button>().interactable = false;
            GameObject.Find("WaterLevel").GetComponent<Text>().text = "";
            SelectUI.SetActive(false);
            BlurUI.SetActive(false);
            Instantiate(waterEnemy, spawnPoint.position, spawnPoint.rotation);
            PlayerProperties.waterIsDead = false;
            PlayerProperties.elementToken--;
        }
        public void chooseGrass(){
            GameObject.Find("Grass").GetComponent<Button>().interactable = false;
            GameObject.Find("GrassLevel").GetComponent<Text>().text = "";
            SelectUI.SetActive(false);
            BlurUI.SetActive(false);
            Instantiate(grassEnemy, spawnPoint.position, spawnPoint.rotation);
            PlayerProperties.grassIsDead = false;
            PlayerProperties.elementToken--;
        }
        public void choosePsychic(){
            GameObject.Find("Psychic").GetComponent<Button>().interactable = false;
            GameObject.Find("PsychicLevel").GetComponent<Text>().text = "";
            SelectUI.SetActive(false);
            BlurUI.SetActive(false);
            Instantiate(psychicEnemy, spawnPoint.position, spawnPoint.rotation);
            PlayerProperties.elementToken--;
        }
        public void chooseInterest(){
            GameObject.Find("InterestAmount").GetComponent<Text>().text = "";
            SelectUI.SetActive(false);
            BlurUI.SetActive(false);
            PlayerProperties.Interest++;
            PlayerProperties.elementToken--;
        }


        
}