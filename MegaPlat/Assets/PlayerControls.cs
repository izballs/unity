// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerControl"",
            ""id"": ""244f2f93-407e-481f-b637-cf8a61c74de3"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""923dbe10-7582-41fe-9eeb-d4c4f284e3d2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""f602ac14-5654-4bd1-8938-36a1e3d7ee46"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""8eac818d-9fd5-438e-8642-d61797e6280f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlowMotion"",
                    ""type"": ""Button"",
                    ""id"": ""0a48d2e7-616a-4706-aefb-c465c1244475"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""RegenSlow"",
                    ""type"": ""Button"",
                    ""id"": ""81b60794-ef09-4714-8692-c58484fb3513"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e77a237c-9fd6-4546-8d52-63d6fa48e45e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TakeDamage"",
                    ""type"": ""Button"",
                    ""id"": ""639f53b5-5c51-45fb-b0c4-eb0ae3d66cd1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RegenHp"",
                    ""type"": ""Button"",
                    ""id"": ""94ee68d7-1422-4954-ad66-74d243ca2e79"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""Button"",
                    ""id"": ""51881f3d-52a7-4bc2-b136-1b4aa3629197"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=1E+10,pressPoint=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""03307434-07c0-491f-8f56-4a5667b3fb2c"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4719d482-058b-4fcd-b7a8-07014d4ec9d6"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36d00bea-c7d8-48f9-8630-e70a61e4f511"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d73da012-3d0a-42a0-9bbd-74f719e1f682"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d43ca27-7ae9-45e5-bffc-039962a2c0ca"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SlowMotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f720de14-98b7-4dd6-a2d0-f6209617b0a1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SlowMotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e989a6d-3f94-41fe-be2b-77811aa637ff"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RegenSlow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""001e92d8-5ef1-41d9-8893-c7e29b1cf8d4"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RegenSlow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1b7347f-b1f1-4e24-b109-98a6f48ac0fa"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d1e5528-56e3-455d-bf1f-cafecfac703f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee45925d-b71a-43fa-a5fc-fd448fdd405e"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""TakeDamage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05d861ae-2723-4f80-8db2-0846dfd6b6a8"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TakeDamage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04dcca7f-f5ae-4e8b-841e-beca04a6c74b"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RegenHp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af91af65-55da-44dc-ae4a-ee61ec7c07e4"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RegenHp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee95a84d-5c02-48d9-abb7-6d7a4699fd68"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90033cf9-fbe0-4ca9-b8d2-6aaa798ee048"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""7f66cd58-4632-472a-9520-9092b093254e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8602b891-949d-436f-ade7-ad8b7350be7a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1cdce6b9-a935-4ffa-a6d6-6883cd9c900b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""11ae9ed1-7ce3-4c4a-8873-82e1412e7a54"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2248d698-2db5-4884-bc57-a093b25811f1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""02b04336-5f83-4738-b046-d6c7de989bd9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""58e8bd09-83eb-406f-a2fb-396b4882c187"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7e3dd0ea-e6ab-4d39-a2a1-aeb3bcae0a07"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9b91c6c3-2055-4bd8-a024-0eb7c916bd30"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""78243aff-aa12-4c67-bb50-f859234443b2"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3883f0eb-1341-4176-a7f3-173067398366"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ShopControl"",
            ""id"": ""4694c04d-5b7a-4b63-8143-ad49271ada87"",
            ""actions"": [
                {
                    ""name"": ""Accept"",
                    ""type"": ""Button"",
                    ""id"": ""ee2f776a-8358-43e6-af96-6a198e49e6a3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Decline"",
                    ""type"": ""Button"",
                    ""id"": ""013c1060-e681-4b6c-bf6e-e26f97881952"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f15225f7-e733-4454-8ca7-a0c163fbc89a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""71384b1e-4626-4404-9b9b-0295f1fd06ff"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c13037b-0980-47dc-84a6-7b4f58175d6a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98f787bc-760c-40fb-96aa-54e6ff4b8831"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32965b04-e3e1-466b-8062-11a1052427ff"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""59a0405c-7fe3-4d09-ac50-1546828667a0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1f77f792-53cb-4b69-8181-07b5d3be5dab"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""95f8163a-a94d-4a35-adc9-3c71f1f4bed3"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""86696793-8bfc-4544-8a1b-b80a8a79ea2f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5e7c1d73-59e2-4a85-9fc0-a6776c5116c1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""739d794e-5c35-4122-b1a0-120744b9a6e7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""78089eb2-d9b7-4a02-8454-ef7855943e91"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f37a569c-a906-44b0-a049-066398803fab"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ec13ac0-e74b-4058-b6ed-703587ca5980"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e07fdc02-b8c7-4e6a-9bd0-ab798a7e1ff6"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Decline"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""174367e1-2446-459c-8364-7178fc87fa65"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Decline"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""b28d218d-f8e4-41b0-9232-8cee5e4f9838"",
            ""actions"": [
                {
                    ""name"": ""Navigation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8a6798c4-3ecc-4a33-982b-b546df4b585d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accept"",
                    ""type"": ""Button"",
                    ""id"": ""4afc44cd-bab3-4d80-ab8e-0a009aa961da"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Decline"",
                    ""type"": ""Button"",
                    ""id"": ""9de1a594-33b4-48a7-85dc-42eb806e36fe"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse-Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e4244af9-55d0-4b68-80d1-e20111ffea91"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse-LeftClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""da78c4cb-b3e3-49e8-aca8-fd8057588869"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1f444b81-ff2d-410e-bcb9-3ca9a0095c8c"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c69fe40e-14a9-41a0-a45a-1768f04a77ee"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""999a8796-3aae-46c7-8a65-73269b8cece4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""81804a09-2288-4764-ba2a-f5052ad4b60c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e07a2ec1-2c91-4782-a2d7-7036bed3c256"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1af78276-4507-4c94-bc7b-f23b4c093cfa"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""193bc4ed-6bbd-467a-8069-7393f0e31e5a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bd19e107-10d4-4491-b4a7-1ebb5a12d885"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1adb02d9-4bd8-485b-9408-bd40460555c9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""95217fe3-538c-4857-8460-ce18f219ad13"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""35f0368c-9e9d-4cd9-b5b9-038f74a41865"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa1b5cff-a122-46b6-b59a-502271e1a2e6"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e7439c0-43c4-4010-94ca-5c78606fbd79"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""476fe269-9b64-4d01-a707-5f07eb6412f6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Decline"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57a8ee83-d0b9-48cd-82f6-e60e51e80788"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Decline"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bc006c7-ace9-478b-8b62-9f087e6c8cc7"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Mouse-Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b124bfbb-63e9-4b3d-be5d-682b03483fd2"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse-Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20fc8e39-3e92-4b18-8337-dfc5b52d2932"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Mouse-LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // PlayerControl
        m_PlayerControl = asset.FindActionMap("PlayerControl", throwIfNotFound: true);
        m_PlayerControl_Movement = m_PlayerControl.FindAction("Movement", throwIfNotFound: true);
        m_PlayerControl_Fire = m_PlayerControl.FindAction("Fire", throwIfNotFound: true);
        m_PlayerControl_Slide = m_PlayerControl.FindAction("Slide", throwIfNotFound: true);
        m_PlayerControl_SlowMotion = m_PlayerControl.FindAction("SlowMotion", throwIfNotFound: true);
        m_PlayerControl_RegenSlow = m_PlayerControl.FindAction("RegenSlow", throwIfNotFound: true);
        m_PlayerControl_Jump = m_PlayerControl.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControl_TakeDamage = m_PlayerControl.FindAction("TakeDamage", throwIfNotFound: true);
        m_PlayerControl_RegenHp = m_PlayerControl.FindAction("RegenHp", throwIfNotFound: true);
        m_PlayerControl_Charge = m_PlayerControl.FindAction("Charge", throwIfNotFound: true);
        // ShopControl
        m_ShopControl = asset.FindActionMap("ShopControl", throwIfNotFound: true);
        m_ShopControl_Accept = m_ShopControl.FindAction("Accept", throwIfNotFound: true);
        m_ShopControl_Decline = m_ShopControl.FindAction("Decline", throwIfNotFound: true);
        m_ShopControl_Navigate = m_ShopControl.FindAction("Navigate", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Navigation = m_MainMenu.FindAction("Navigation", throwIfNotFound: true);
        m_MainMenu_Accept = m_MainMenu.FindAction("Accept", throwIfNotFound: true);
        m_MainMenu_Decline = m_MainMenu.FindAction("Decline", throwIfNotFound: true);
        m_MainMenu_MousePoint = m_MainMenu.FindAction("Mouse-Point", throwIfNotFound: true);
        m_MainMenu_MouseLeftClick = m_MainMenu.FindAction("Mouse-LeftClick", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerControl
    private readonly InputActionMap m_PlayerControl;
    private IPlayerControlActions m_PlayerControlActionsCallbackInterface;
    private readonly InputAction m_PlayerControl_Movement;
    private readonly InputAction m_PlayerControl_Fire;
    private readonly InputAction m_PlayerControl_Slide;
    private readonly InputAction m_PlayerControl_SlowMotion;
    private readonly InputAction m_PlayerControl_RegenSlow;
    private readonly InputAction m_PlayerControl_Jump;
    private readonly InputAction m_PlayerControl_TakeDamage;
    private readonly InputAction m_PlayerControl_RegenHp;
    private readonly InputAction m_PlayerControl_Charge;
    public struct PlayerControlActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerControlActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControl_Movement;
        public InputAction @Fire => m_Wrapper.m_PlayerControl_Fire;
        public InputAction @Slide => m_Wrapper.m_PlayerControl_Slide;
        public InputAction @SlowMotion => m_Wrapper.m_PlayerControl_SlowMotion;
        public InputAction @RegenSlow => m_Wrapper.m_PlayerControl_RegenSlow;
        public InputAction @Jump => m_Wrapper.m_PlayerControl_Jump;
        public InputAction @TakeDamage => m_Wrapper.m_PlayerControl_TakeDamage;
        public InputAction @RegenHp => m_Wrapper.m_PlayerControl_RegenHp;
        public InputAction @Charge => m_Wrapper.m_PlayerControl_Charge;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnMovement;
                @Fire.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnFire;
                @Slide.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnSlide;
                @SlowMotion.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnSlowMotion;
                @SlowMotion.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnSlowMotion;
                @SlowMotion.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnSlowMotion;
                @RegenSlow.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRegenSlow;
                @RegenSlow.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRegenSlow;
                @RegenSlow.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRegenSlow;
                @Jump.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnJump;
                @TakeDamage.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnTakeDamage;
                @TakeDamage.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnTakeDamage;
                @TakeDamage.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnTakeDamage;
                @RegenHp.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRegenHp;
                @RegenHp.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRegenHp;
                @RegenHp.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRegenHp;
                @Charge.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnCharge;
                @Charge.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnCharge;
                @Charge.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnCharge;
            }
            m_Wrapper.m_PlayerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
                @SlowMotion.started += instance.OnSlowMotion;
                @SlowMotion.performed += instance.OnSlowMotion;
                @SlowMotion.canceled += instance.OnSlowMotion;
                @RegenSlow.started += instance.OnRegenSlow;
                @RegenSlow.performed += instance.OnRegenSlow;
                @RegenSlow.canceled += instance.OnRegenSlow;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @TakeDamage.started += instance.OnTakeDamage;
                @TakeDamage.performed += instance.OnTakeDamage;
                @TakeDamage.canceled += instance.OnTakeDamage;
                @RegenHp.started += instance.OnRegenHp;
                @RegenHp.performed += instance.OnRegenHp;
                @RegenHp.canceled += instance.OnRegenHp;
                @Charge.started += instance.OnCharge;
                @Charge.performed += instance.OnCharge;
                @Charge.canceled += instance.OnCharge;
            }
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);

    // ShopControl
    private readonly InputActionMap m_ShopControl;
    private IShopControlActions m_ShopControlActionsCallbackInterface;
    private readonly InputAction m_ShopControl_Accept;
    private readonly InputAction m_ShopControl_Decline;
    private readonly InputAction m_ShopControl_Navigate;
    public struct ShopControlActions
    {
        private @PlayerControls m_Wrapper;
        public ShopControlActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accept => m_Wrapper.m_ShopControl_Accept;
        public InputAction @Decline => m_Wrapper.m_ShopControl_Decline;
        public InputAction @Navigate => m_Wrapper.m_ShopControl_Navigate;
        public InputActionMap Get() { return m_Wrapper.m_ShopControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShopControlActions set) { return set.Get(); }
        public void SetCallbacks(IShopControlActions instance)
        {
            if (m_Wrapper.m_ShopControlActionsCallbackInterface != null)
            {
                @Accept.started -= m_Wrapper.m_ShopControlActionsCallbackInterface.OnAccept;
                @Accept.performed -= m_Wrapper.m_ShopControlActionsCallbackInterface.OnAccept;
                @Accept.canceled -= m_Wrapper.m_ShopControlActionsCallbackInterface.OnAccept;
                @Decline.started -= m_Wrapper.m_ShopControlActionsCallbackInterface.OnDecline;
                @Decline.performed -= m_Wrapper.m_ShopControlActionsCallbackInterface.OnDecline;
                @Decline.canceled -= m_Wrapper.m_ShopControlActionsCallbackInterface.OnDecline;
                @Navigate.started -= m_Wrapper.m_ShopControlActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_ShopControlActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_ShopControlActionsCallbackInterface.OnNavigate;
            }
            m_Wrapper.m_ShopControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accept.started += instance.OnAccept;
                @Accept.performed += instance.OnAccept;
                @Accept.canceled += instance.OnAccept;
                @Decline.started += instance.OnDecline;
                @Decline.performed += instance.OnDecline;
                @Decline.canceled += instance.OnDecline;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
            }
        }
    }
    public ShopControlActions @ShopControl => new ShopControlActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Navigation;
    private readonly InputAction m_MainMenu_Accept;
    private readonly InputAction m_MainMenu_Decline;
    private readonly InputAction m_MainMenu_MousePoint;
    private readonly InputAction m_MainMenu_MouseLeftClick;
    public struct MainMenuActions
    {
        private @PlayerControls m_Wrapper;
        public MainMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigation => m_Wrapper.m_MainMenu_Navigation;
        public InputAction @Accept => m_Wrapper.m_MainMenu_Accept;
        public InputAction @Decline => m_Wrapper.m_MainMenu_Decline;
        public InputAction @MousePoint => m_Wrapper.m_MainMenu_MousePoint;
        public InputAction @MouseLeftClick => m_Wrapper.m_MainMenu_MouseLeftClick;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Navigation.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigation;
                @Navigation.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigation;
                @Navigation.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigation;
                @Accept.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAccept;
                @Accept.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAccept;
                @Accept.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAccept;
                @Decline.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDecline;
                @Decline.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDecline;
                @Decline.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDecline;
                @MousePoint.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMousePoint;
                @MousePoint.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMousePoint;
                @MousePoint.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMousePoint;
                @MouseLeftClick.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMouseLeftClick;
                @MouseLeftClick.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMouseLeftClick;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigation.started += instance.OnNavigation;
                @Navigation.performed += instance.OnNavigation;
                @Navigation.canceled += instance.OnNavigation;
                @Accept.started += instance.OnAccept;
                @Accept.performed += instance.OnAccept;
                @Accept.canceled += instance.OnAccept;
                @Decline.started += instance.OnDecline;
                @Decline.performed += instance.OnDecline;
                @Decline.canceled += instance.OnDecline;
                @MousePoint.started += instance.OnMousePoint;
                @MousePoint.performed += instance.OnMousePoint;
                @MousePoint.canceled += instance.OnMousePoint;
                @MouseLeftClick.started += instance.OnMouseLeftClick;
                @MouseLeftClick.performed += instance.OnMouseLeftClick;
                @MouseLeftClick.canceled += instance.OnMouseLeftClick;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerControlActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
        void OnSlowMotion(InputAction.CallbackContext context);
        void OnRegenSlow(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTakeDamage(InputAction.CallbackContext context);
        void OnRegenHp(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
    }
    public interface IShopControlActions
    {
        void OnAccept(InputAction.CallbackContext context);
        void OnDecline(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnNavigation(InputAction.CallbackContext context);
        void OnAccept(InputAction.CallbackContext context);
        void OnDecline(InputAction.CallbackContext context);
        void OnMousePoint(InputAction.CallbackContext context);
        void OnMouseLeftClick(InputAction.CallbackContext context);
    }
}
