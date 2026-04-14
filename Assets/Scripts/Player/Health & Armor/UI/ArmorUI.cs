using TMPro;
using UnityEngine;

public class ArmorUI : MonoBehaviour
{
    [SerializeField] TMP_Text armorText;
    [SerializeField] PlayerArmor playerArmor;
   
    private void UIArmorUpdate()
    {
        armorText.text = playerArmor.Armor.ToString();
    }
    
    private void OnEnable()
    {
        UIArmorUpdate();
        playerArmor.OnArmorChanged += UIArmorUpdate;
    }

    private void OnDisable()
    {
        playerArmor.OnArmorChanged -= UIArmorUpdate;
    }
}


    

    

