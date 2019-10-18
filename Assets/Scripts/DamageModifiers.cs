using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageModifiers : MonoBehaviour
{
    [Header("Class Passives")]
    public float drizzle = 1f;
    public float combustion = 1f;
    public float sap = 0f;
    public float foresight = 1f;

    [Header("Debuffs Stats")]
    public float paralyzeChance = 10f;
    public float paralyzeDuration = 2f;
    public float baseArmorShred = 20f;
    public float poisonDuration = 3f;
    public float poisonDamage = 0f;
    public float drowsyStunChance = 20f;
    public float drowsyDuration = 3f;
    public float drowsySlow = 30f;
    public float spacialRend = 20f;
    public float chillMultiplier = 10f;
    private int chillCounter = 0;
}
