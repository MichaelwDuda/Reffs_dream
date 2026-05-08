using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterWep : MonoBehaviour
{
    public AttackChoice AttackChoice;   

    public void ChooseAttack(string attackName)
    {
        AttackChoice.chosenAttackName = attackName;
        SceneManager.LoadScene("GameScene");
    }
}
