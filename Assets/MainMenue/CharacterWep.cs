using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterWep : MonoBehaviour
{
    public AttackChoice AttackChoice;   // Drag your ScriptableObject here

    public void ChooseAttack(string attackName)
    {
        AttackChoice.chosenAttackName = attackName;
        SceneManager.LoadScene("GameScene");
    }
}
