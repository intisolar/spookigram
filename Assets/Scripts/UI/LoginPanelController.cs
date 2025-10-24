using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanelController : PanelController
{
    [SerializeField] private TMP_InputField userNameInput;
    [SerializeField] private Button continueButton;
    [SerializeField] private TMP_Text errorLabel;

    [Header("Rules")]
    [SerializeField] private int minLength = 3; 
    [SerializeField] private bool trimSpaces = true;

    private bool showErrors = false;

    void Awake()
    {
        userNameInput.onValidateInput += (string text, int charIndex, char added) =>
        {
            if (char.IsLetterOrDigit(added)) return added;
            if (added == '_' || added == '-' || added == '.') return added;
            return '\0'; // bloquea el resto (incluye espacios)
        };

        userNameInput.onValueChanged.AddListener(_ => Validate(userNameInput.text));
        userNameInput.onEndEdit.AddListener(_ => Validate(userNameInput.text));

        Validate(userNameInput.text); // estado inicial del botón
    }

    private void Validate(string rawInput)
    {
        var text = trimSpaces ? rawInput?.Trim() : rawInput;
        bool ok = !string.IsNullOrWhiteSpace(text) && text!.Length >= minLength;

        continueButton.interactable = ok;

        if (errorLabel)
        {
            if (!showErrors || string.IsNullOrEmpty(text))
            {
                errorLabel.text = ""; // nada mientras escribe o está vacío
            }
            else
            {
                int faltan = Mathf.Max(0, minLength - text.Length);
                errorLabel.text = ok ? "" :
                    (faltan > 0 ? $"Faltan {faltan} caracteres." : "Entrada inválida.");
            }
        }
    }

    public string GetSanitizedValue() => (trimSpaces ? userNameInput.text.Trim() : userNameInput.text);

    /// <summary>
    /// Save PlayerName for this game and load next page
    /// </summary>
    public void OnLoginButtonClicked()
    {
        showErrors = true;
        Validate(userNameInput.text);

        string enteredName = userNameInput.text.Trim();
        if (string.IsNullOrWhiteSpace(enteredName))
        {
            // mostrar feedback y salir
            errorLabel.text = "El nombre no puede estar vacío.";
            return;
        }
        GameManager.Instance.SetPlayerName(enteredName);
        Debug.Log($"Nombre guardado: {enteredName}");
        OnNextButtonClicked();
    }

    private void OnEnable()
    {
        showErrors = false;
        if (userNameInput) userNameInput.text = "";
        if (errorLabel) errorLabel.text = "";
        if (continueButton) continueButton.interactable = false;
    }

    public override void ResetPanelInfo()
    {
        showErrors = false;
        ResetUserInfo();
        errorLabel.text = null;
        if (continueButton) continueButton.interactable = false;
    }

    private void ResetUserInfo()
    {
        userNameInput.text = "";
    }
}

