using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Unlockable : MonoBehaviour
{
    public int Score;
    [SerializeField] private TextMeshProUGUI _scoreText;
    

    private Button _button;

    private void OnEnable()
    {
        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(IncreaseScore);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(IncreaseScore);
    }

    private void Update()
    {
        var text = $"+{Score} <sprite=0>";
        _scoreText.text = text;
    }

    private void IncreaseScore()
    {
        Player.Instance.Score.Value += Score;
    }

    public void ChangeTextColorGreen()
    {
        _scoreText.color = Color.green;
    }
}
