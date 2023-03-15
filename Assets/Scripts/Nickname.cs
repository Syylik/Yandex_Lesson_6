using TMPro;
using UnityEngine;

public class Nickname : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nickname;
    [SerializeField] private TMP_InputField _nickField;

    private void Start()
    {
        _nickname.text = PlayerPrefs.GetString("Nickname", "Игрок");
        _nickField.text = _nickname.text;
    }

    public void SetNick()
    {
        _nickname.text = _nickField.text;
        PlayerPrefs.SetString("Nickname", _nickname.text);
    }
}
