using UnityEngine;


// Each Boss Attack Move should derive from this one!

[CreateAssetMenu(fileName = "BossAttack", menuName = "Scriptable Objects/BossAttack")]
public class BossAttack : ScriptableObject
{
    public string attackName;    // Name of the attack
    public float cooldown;       // Cooldown of boss attack move
    public Sprite icon;          // Optional: Icon to represent the attack

    // Method to execute the attack
    public virtual void PerformAttack(Transform bossTransform, Transform playerTransform)
    {
        // Default behavior: Print attack information
        Debug.Log($"Executing {attackName}");
    }
}
