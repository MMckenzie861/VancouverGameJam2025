using UnityEngine;


// Each Boss Attack Move should derive from this one!

[CreateAssetMenu(fileName = "BossAttack", menuName = "Scriptable Objects/BossAttack")]
public class BossAttack : ScriptableObject
{
    public string attackName;    // Name of the attack
    public Sprite icon;          // Optional: Icon to represent the attack

    private BossLogic bossLogic; // Reference to notify the boss logic

    public void Initialize(BossLogic bossLogic)
    {
        this.bossLogic = bossLogic;
    }

    // Method called by child attacks when the attack finishes
    public void NotifyAttackComplete()
    {
        bossLogic.OnAttackComplete(this);
    }

    // Method to execute the attack
    public virtual void PerformAttack(Transform bossTransform, Transform playerTransform)
    {
        // Default behavior: Print attack information
        Debug.Log($"Executing {attackName}");
    }
}
