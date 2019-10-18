using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
  [Header("Enemy Stats:")]
  public float baseSpeed = 5f;
  [HideInInspector]
  public float speed;

  public float startHealth = 100f;
  public float currentHealth;

  public float startArmor = 10f;
  [HideInInspector]
  public float armor;

  public string classType;

  public int moneyValue = 1;
  public GameObject deathEffect;

  private bool poisoned = false;
  private float poisonDamage = 0f;

  [Header("Types")]
  public float advantage;

  [Header("Health Bar")]
  public Image healthBar;

  void Start () {
      speed = baseSpeed;
      currentHealth = startHealth;
      armor = startArmor;
  }

  void Update () {
      if (poisoned) {
          ApplyPoison(poisonDamage);
      }
  }

  public void TakeDamage (float damage, string type) {
      float damageToTake = damage * (50 / (50 + armor));

      damageToTake = TypeAdvantage(damageToTake, type);
      //Debug.Log("Damage Taken: " + damageToTake);
      //Debug.Log("Current Health before damage: " + currentHealth);
      currentHealth -= damageToTake;
      healthBar.fillAmount = currentHealth / startHealth;

      if (currentHealth <= 0) {
          Die();
      }
  }

  public float TypeAdvantage (float damage, string type) {
      switch (classType) {
          case "water":
            switch (type) {
                case "grass":
                    damage = damage * advantage;
                    break;
                case "fire":
                    damage = damage / advantage;
                    break;
                default:
                    break;
            }
            return damage;

          case "fire":
            switch (type) {
                case "water":
                    damage = damage * advantage;
                    break;
                case "grass":
                    damage = damage / advantage;
                    break;
                default:
                    break;
            }
            return damage;

          case "grass":
            switch (type) {
                case "fire":
                    damage = damage * advantage;
                    break;
                case "water":
                    damage = damage / advantage;
                    break;
                default:
                    break;
            }
            return damage;

          default:
            return damage;
      }
  }

  public void Slow (float slowPercentage, float duration) {
      speed = baseSpeed * ((100f - slowPercentage) / 100f);
      Invoke("ResetSpeed", duration);
  }

  public void Stun (float duration) {
      speed = baseSpeed * 0f;
      Invoke("ResetSpeed", duration);
  }

  public void Curse (float armorShred) {
      armorShred = armorShred / 100f;
      armor = startArmor * (1f - armorShred);
  }

  public void Paralyze (float paralyzeChance, float stunDuration) {
      float chance = Mathf.Round(Random.Range(1, 100));
      if (chance <= paralyzeChance) {
        Stun(stunDuration);
      }
  }

  public void Poison (float damagePerSecond, float duration) {
      poisoned = true;
      poisonDamage = damagePerSecond;
      Invoke("ResetPoison", duration);
  }

  public void ApplyPoison (float damagePerSecond) {
      TakeDamage(damagePerSecond * Time.deltaTime, "grass");
  }

  public void Drowsy (float slow, float stunChance, float duration ) {
      Slow(slow, duration);
      Paralyze(stunChance, duration);
  }

  public void Chill (float multiplier) {
      float chance = Mathf.Round(Random.Range(1, 2));
      if (chance <= 1) {
          float slow = 5 * multiplier;
          float duration = 4 * multiplier;
          Slow(slow, duration);
      }
      else {
          float slow = 35 * multiplier;
          float duration = multiplier / 2;
          Slow(slow, duration);
      }
  }

  public void SpacialRend (float power, float duration) {
      float chance = Mathf.Round(Random.Range(1, 3));
      if (chance <= 1) {
          float slow = power * 2;
          float newDuration = duration * 2;
          Slow(slow, newDuration);
      }
      else {
          Slow(power, duration);
      }
  }

  void ResetSpeed () {
      speed = baseSpeed;
  }

  void ResetPoison () {
      poisoned = false;
  }

  void Die () {
     PlayerProperties.Money += moneyValue;
     PlayerProperties.CurrentEnemiesAlive -= 1;

     GameObject DyingEffect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
     Destroy(DyingEffect, 2f);

     if (gameObject.name == "Charizard(Clone)") {
          PlayerProperties.fireLevel++;
          Destroy(gameObject);
          PlayerProperties.fireIsDead = true;
          if(GameObject.Find("ElementSelectionUI")) {
              if(GameObject.Find("ElementSelectionUI").activeSelf == true){
                  GameObject.Find("Fire").GetComponent<Button>().interactable = true;
              }
          }
      }
      if (gameObject.name == "Blastoise(Clone)") {
          PlayerProperties.waterLevel++;
          Destroy(gameObject);
          PlayerProperties.waterIsDead = true;
          if(GameObject.Find("ElementSelectionUI")) {
              if(GameObject.Find("ElementSelectionUI").activeSelf == true){
                  GameObject.Find("Water").GetComponent<Button>().interactable = true;
              }
          }
      }
      if (gameObject.name == "Venusaur(Clone)") {
          PlayerProperties.grassLevel++;
          Destroy(gameObject);
          PlayerProperties.grassIsDead = true;
          if(GameObject.Find("ElementSelectionUI")) {
              if(GameObject.Find("ElementSelectionUI").activeSelf == true){
                  GameObject.Find("Grass").GetComponent<Button>().interactable = true;
              }
          }
      }
      if (gameObject.name == "Alakazam(Clone)") {
          PlayerProperties.psychicLevel++;
          Destroy(gameObject);
          PlayerProperties.psychicIsDead = true;
          if(GameObject.Find("ElementSelectionUI")) {
              if(GameObject.Find("ElementSelectionUI").activeSelf == true){
                  GameObject.Find("Psychic").GetComponent<Button>().interactable = true;
              }
          }
      }
      else {
          Destroy(gameObject);
      }
   }
}
