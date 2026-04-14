using System.Collections;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] TMP_Text healthText;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] GameObject hitEff;
    private Color textColor;
    
    void Start()
    {
        textColor = healthText.color;
        UIUpdate();
    }

    IEnumerator Flash()
    {
        healthText.color = Color.white;
        hitEff.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hitEff.SetActive(false);
        healthText.color = textColor;
    }
    
    private void UIUpdate()
    {
        healthText.text = playerHealth.CurrentHealth.ToString();
    }

    public void OnDamage()
    {
        StartCoroutine(Flash());
        UIUpdate();
    }
}
