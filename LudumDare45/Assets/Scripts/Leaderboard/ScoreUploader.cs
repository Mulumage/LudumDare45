using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUploader : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private IntReference _score;
    [SerializeField] private Button _button;

    public void UploadScore()
    {
        if (string.IsNullOrEmpty(_inputField.text))
            return;
        
        LeaderboardHandler.UploadScore(_inputField.text, _score.Value);
        _inputField.interactable = false;
        _button.GetComponentInChildren<TextMeshProUGUI>().text = "Uploaded";
        _button.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
        _button.interactable = false;
    }
}
