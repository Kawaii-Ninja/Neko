using UnityEngine;
using TMPro;

public class ComboStreak : MonoBehaviour
{
    UniversalPlayerData upd;
    Timer _TimerComponent;
    [SerializeField] TextMeshProUGUI comboText;

    private void Start()
    {
        // Find and assign references to UniversalPlayerData and Timer components.
        upd = FindObjectOfType<UniversalPlayerData>();
        _TimerComponent = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        // Check and update combo text based on combo streak.
        SetComboTextTrigger();
        UpdateComboText();
    }

    // Activate or deactivate the combo text panel based on the combo streak.
    private void SetComboTextTrigger()
    {
        // Activate the panel when the combo streak is greater than 2.
        if (upd.combo > 2)
        {
            comboText.gameObject.SetActive(true);
        }
        // Deactivate the panel when the combo streak is not sufficient.
        else
        {
            comboText.gameObject.SetActive(false);
        }
    }

    // Increase the combo streak and adjust timer when called.
    public void IncreaseCombo()
    {
        // Adjust the timer based on the combo streak.
        _TimerComponent.time += upd.combo;
    }

    // Update the combo text displayed in the UI panel.
    void UpdateComboText()
    {
        // Update the combo text to reflect the current combo streak.
        comboText.text = "Combo: " + upd.combo + "x";
    }
}
