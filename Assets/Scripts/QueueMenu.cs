using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class QueueMenu : MonoBehaviour {

public Image[] images;
   private string GameMapToLoad = "GameMap";
   private string MenuScene = "MainMenu";

   public void BackToMenu () {
       SceneManager.LoadScene(MenuScene);
   }
   public void MoreInfo () {
   }
   public void SetGameMap (string selectedGameMap) {
       GameMapToLoad = selectedGameMap;
   }
   public void StartGame () {
       SceneManager.LoadScene (GameMapToLoad);
   }

   public void Toggle(){

       foreach(Image mapImage in images){
        if(GameMapToLoad.Contains(mapImage.name)){
            mapImage.gameObject.SetActive(true);
        }
        else{
            mapImage.gameObject.SetActive(false);
        }
       }
   }
   public void ExitGame () {
       Application.Quit();
   }
}
