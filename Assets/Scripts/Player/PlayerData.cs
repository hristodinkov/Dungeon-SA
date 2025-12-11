using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int maxHP;
    public float speed;
    public int money;
    public int xp;
    public int attckDamage;
    public int level;
    public int currentHP;
  
    //public enum PlayerClass
    //{
    //    Warrior,
    //    Mage,
    //    Archer
    //}
}
