using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
public class OptionsMenuScript : MonoBehaviour
{

    public SettingsObjectScript settingsObject;
    public InputSystemUIInputModule inputSystem;
    private InputActionRebindingExtensions.RebindingOperation rebindOperation;

    public GameObject[] KeyboardBinds;
    public GameObject[] GamepadBinds;


    public void RemapKeyboardButton(string action){
        
        inputSystem.enabled = false;
        
        switch(action){
            case "Fire":
                rebindOperation?.Dispose();
                rebindOperation = settingsObject.inputActions.PlayerControl
                    .Fire.PerformInteractiveRebinding()
                    .WithControlsExcluding("Gamepad")
                    .WithControlsExcluding("Mouse")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => Completed());
                rebindOperation.OnApplyBinding((x, path) => {
                    settingsObject.inputActions.PlayerControl.Fire.ApplyBindingOverride(0, path);
                        });
                break;
            case "Jump":
                rebindOperation?.Dispose();
                rebindOperation = settingsObject.inputActions.PlayerControl
                    .Jump.PerformInteractiveRebinding()
                    .WithControlsExcluding("Gamepad")
                    .WithControlsExcluding("Mouse")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => Completed());
                rebindOperation.OnApplyBinding((x, path) => {
                    settingsObject.inputActions.PlayerControl.Jump.ApplyBindingOverride(0, path);
                        });

                break;
            case "Slide":
                rebindOperation?.Dispose();
                rebindOperation = settingsObject.inputActions.PlayerControl
                    .Slide.PerformInteractiveRebinding()
                    .WithControlsExcluding("Gamepad")
                    .WithControlsExcluding("Mouse")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => Completed());
                rebindOperation.OnApplyBinding((x, path) => {
                    settingsObject.inputActions.PlayerControl.Slide.ApplyBindingOverride(0, path);
                        });

                break;
            case "SlowMotion":
                rebindOperation?.Dispose();
                rebindOperation = settingsObject.inputActions.PlayerControl
                    .SlowMotion.PerformInteractiveRebinding()
                    .WithControlsExcluding("Gamepad")
                    .WithControlsExcluding("Mouse")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => Completed());
                rebindOperation.OnApplyBinding((x, path) => {
                    settingsObject.inputActions.PlayerControl.SlowMotion.ApplyBindingOverride(0, path);
                        });
                break;
        }
        rebindOperation.Start();

        Debug.Log(action);
    }

    public void RemapGamepadButton(string action){
        
        inputSystem.enabled = false;
        
        switch(action){
            case "Fire":
                rebindOperation?.Dispose();
                rebindOperation = settingsObject.inputActions.PlayerControl
                    .Fire.PerformInteractiveRebinding()
                    .WithControlsExcluding("Mouse")
                    .WithControlsExcluding("Keyboard")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => Completed());
                rebindOperation.OnApplyBinding((x, path) => {
                    settingsObject.inputActions.PlayerControl.Fire.ApplyBindingOverride(1, path);
                        });
                break;
            case "Jump":
                rebindOperation?.Dispose();
                rebindOperation = settingsObject.inputActions.PlayerControl
                    .Jump.PerformInteractiveRebinding()
                    .WithControlsExcluding("Mouse")
                    .WithControlsExcluding("Keyboard")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => Completed());
                rebindOperation.OnApplyBinding((x, path) => {
                    settingsObject.inputActions.PlayerControl.Jump.ApplyBindingOverride(1, path);
                        });

                break;
            case "Slide":
                rebindOperation?.Dispose();
                rebindOperation = settingsObject.inputActions.PlayerControl
                    .Slide.PerformInteractiveRebinding()
                    .WithControlsExcluding("Mouse")
                    .WithControlsExcluding("Keyboard")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => Completed());
                rebindOperation.OnApplyBinding((x, path) => {
                    settingsObject.inputActions.PlayerControl.Slide.ApplyBindingOverride(1, path);
                        });

                break;
            case "SlowMotion":
                rebindOperation?.Dispose();
                rebindOperation = settingsObject.inputActions.PlayerControl
                    .SlowMotion.PerformInteractiveRebinding()
                    .WithControlsExcluding("Mouse")
                    .WithControlsExcluding("Keyboard")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => Completed());
                rebindOperation.OnApplyBinding((x, path) => {
                    settingsObject.inputActions.PlayerControl.SlowMotion.ApplyBindingOverride(1, path);
                        });
                break;
        }

        
        rebindOperation.Start();

        Debug.Log(action);
    }

    public void Completed(){
        Debug.Log("Completed!");
        inputSystem.enabled = true;
        UpdateKeys();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateKeys();
    }

    void UpdateKeys(){
        string keyslow = settingsObject.inputActions.PlayerControl.SlowMotion.GetBindingDisplayString(0);
        string gameslow = settingsObject.inputActions.PlayerControl.SlowMotion.GetBindingDisplayString(1);
        keyslow = keyslow.Substring(6);
        gameslow = gameslow.Substring(6);
        KeyboardBinds[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = settingsObject.inputActions.PlayerControl.Fire.GetBindingDisplayString(0).ToUpper();

        KeyboardBinds[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = settingsObject.inputActions.PlayerControl.Jump.GetBindingDisplayString(0).ToUpper();

        KeyboardBinds[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = settingsObject.inputActions.PlayerControl.Slide.GetBindingDisplayString(0).ToUpper();

        KeyboardBinds[3].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = keyslow.ToUpper();

        GamepadBinds[0].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = settingsObject.inputActions.PlayerControl.Fire.GetBindingDisplayString(1).ToUpper();

        GamepadBinds[1].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = settingsObject.inputActions.PlayerControl.Jump.GetBindingDisplayString(1).ToUpper();

        GamepadBinds[2].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = settingsObject.inputActions.PlayerControl.Slide.GetBindingDisplayString(1).ToUpper();
        GamepadBinds[3].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = gameslow.ToUpper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
