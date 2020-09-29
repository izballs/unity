using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Xml;
using System.Text;
using System.Collections;

public class NPCScript : MonoBehaviour
{
    public GameObject keyUp;
    public GameObject Temp;
    public GameObject DialogUI;
    public string NPCName;
    private GameHandler gameHandler;
    private Transform[] DialogUIElements;
    private Collider2D col;
    private bool playerOnRange = false;
    private bool DialogOn = false;
    private bool shopOpen = false;
    private PlayerScript playerScript;
    private XmlDocument xmldoc;
    private XmlDocument shopxmldoc;
    private XmlNode NpcNode;
    private XmlNode NpcShopNode;
    private bool firstTime = true;
    private int currentNode = 0;
    private int maxNode = 0;
    private XmlNamespaceManager nsmgr;
    private XmlNamespaceManager shopnsmgr;
    private string currentNodeType;
    public Sprite[] dialogSprites;
    private Image[] dialogImages;
    private TMPro.TextMeshProUGUI[] dialogTexts;
    private int maxAnswer = 0;
    private int minAnswer = 0;
    private int currentAnswer = 0;
    private XmlNodeList answers;
    private float lastChange;
    public bool shopKeeper;
    public GameObject shopUI;
    public GameObject shopItem;
    public GameObject shopCost;
    public GameObject shopCurrent;
    public Transform shopChooser;
    public Transform shopHolder;
    private GameObject shopClone;
    private GameObject shopCostHolder;
    private GameObject shopItemHolder;
    private GameObject shopCurrentHolder;
    private int shopChoosable;
    private int shopCurrentlyChosen;
    private Vector2 zero = Vector2.zero;
    private Vector2 lerpFrom;
    private Vector2 lerpTo;
    private bool ShopLerp = false;
    private float ShopTimeLerp = 0f;
    private string currentTextAnimating;
    private bool animationOn = false;
    private float animationSpeed = 0.04f;

    private PlayerControls inputAction;

    // Start is called before the first frame update
    void Start()
    {

        col = GetComponent<Collider2D>();
        xmldoc = new XmlDocument();
        xmldoc.LoadXml(Resources.Load<TextAsset>("dialog").text);
        
        nsmgr = new XmlNamespaceManager(xmldoc.NameTable);
        string xPathString = "NPC[@name='" + NPCName + "']";
        NpcNode = xmldoc.DocumentElement.SelectSingleNode(xPathString, nsmgr);
        if (shopKeeper)
        {
            shopxmldoc = new XmlDocument();
            shopxmldoc.LoadXml(Resources.Load<TextAsset>("shop").text);
            shopnsmgr = new XmlNamespaceManager(shopxmldoc.NameTable);
            NpcShopNode = shopxmldoc.DocumentElement.SelectSingleNode(xPathString, shopnsmgr);
        }
        maxNode = NpcNode.ChildNodes.Count;
        lastChange = Time.time;
        gameHandler = GetComponentInParent<GameHandler>();
    }

    void CloseShop()
    {
        shopOpen = false;
        Debug.Log(shopClone);
        Destroy(shopClone);
        playerScript.shopOpen = false;
        EndDialog();
    }

    void OpenShop()
    {
        Debug.LogWarning("OpenShop()");
        shopOpen = true;
        DialogUI.SetActive(false);
        shopClone = Instantiate(shopUI, shopHolder);
        playerScript.shopOpen = true;
        Transform[] temp = shopHolder.GetComponentsInChildren<Transform>();
        for (int x = 0; x < temp.Length; x++)
        {
            if (temp[x].gameObject.tag == "UIChooser")
            {
                shopChooser = temp[x];
            }
            if (temp[x].gameObject.tag == "UIItemHolder")
            {
                shopItemHolder = temp[x].gameObject;
            }
            if (temp[x].gameObject.tag == "UICostsHolder")
            {
                shopCostHolder = temp[x].gameObject;
            }
            if (temp[x].gameObject.tag == "UICurrentHolder")
            {
                shopCurrentHolder = temp[x].gameObject;
            }
        }
        Debug.Log(NpcShopNode.ChildNodes.Count);
        shopChoosable = NpcShopNode.ChildNodes.Count;
        shopCurrentlyChosen = 0;
        for (int x = 0; x < NpcShopNode.ChildNodes.Count; x++)
        {
            Debug.Log("Lol Looping");
            GameObject teItem = Instantiate(shopItem, shopItemHolder.transform);
            GameObject teCost = Instantiate(shopCost, shopCostHolder.transform);
            GameObject teCurrent = Instantiate(shopCurrent, shopCurrentHolder.transform);
            Debug.Log(teItem);
            Debug.Log(teItem.GetComponent<TMPro.TextMeshProUGUI>().text);

            teItem.GetComponent<TMPro.TextMeshProUGUI>().text = NpcShopNode.ChildNodes[x].SelectSingleNode("name", shopnsmgr).InnerText;
            teItem.transform.position = new Vector3(teItem.transform.position.x, teItem.transform.position.y + (x * -25), teItem.transform.position.z);

            teCost.GetComponent<TMPro.TextMeshProUGUI>().text = NpcShopNode.ChildNodes[x].SelectSingleNode("cost", shopnsmgr).InnerText;
            teCost.transform.position = new Vector3(teCost.transform.position.x, teCost.transform.position.y + (x * -25), teCost.transform.position.z);

            Debug.Log(NpcShopNode.ChildNodes[x].SelectSingleNode("gameHandler", shopnsmgr).InnerText);
            string cur = gameHandler.GetVariableString(NpcShopNode.ChildNodes[x].SelectSingleNode("gameHandler", shopnsmgr).InnerText);
            teCurrent.GetComponent<TMPro.TextMeshProUGUI>().text = cur;
            teCurrent.transform.position = new Vector3(teCurrent.transform.position.x, teCurrent.transform.position.y + (x * -25), teCurrent.transform.position.z);
        }
    }
    public void Interact(PlayerControls controls)
    {
        inputAction = controls;
        inputAction.PlayerControl.Disable();
        inputAction.ShopControl.Enable();
        inputAction.ShopControl.Accept.performed += AcceptPressed;
        inputAction.ShopControl.Decline.performed += DeclinePressed;
        inputAction.ShopControl.Navigate.performed += Navigate;
        StartDialog();
    }

    void DeclinePressed(InputAction.CallbackContext context){
        if(shopOpen)
            CloseShop();
        else
            EndDialog();
    }

    void AcceptPressed(InputAction.CallbackContext context)
    {
        if(!shopOpen){
        if (currentNodeType == "text")
        {
            if (animationOn)
            {
                StopAllCoroutines();
                animationOn = false;
                dialogTexts[0].text = currentTextAnimating;
            }
            else
                NextNode();
        }
        else if (currentNodeType == "question")
        {
            Debug.Log("YouChose:");
            Debug.Log(dialogTexts[currentAnswer].text);

            string func = answers.Item(currentAnswer - 2).Attributes["func"].Value;
            switch (func)
            {
                case "openShop":
                    Debug.Log("Opening shop for you");
                    OpenShop();
                    break;
                case "exitDialog":
                    Debug.Log("Exiting dialog");
                    EndDialog();
                    break;
                case "jumpTo":
                    string nextID = answers.Item(currentAnswer - 2).Attributes["nextID"].Value;
                    currentNode = int.Parse(nextID);
                    Debug.Log("Jumping to dialog id = " + nextID);
                    NextNode();
                    break;
            }
        }
        }
        else{
        }

    }
    void Navigate(InputAction.CallbackContext context)
    {
        Vector2 inp = context.ReadValue<Vector2>();
        if(!shopOpen){
        if (inp.y == 1 && Time.time - lastChange > 0.2f)
        {
            lastChange = Time.time;
            currentAnswer--;
            if (currentAnswer <= minAnswer)
                currentAnswer = minAnswer;
            for (int x = 2; x <= 5; x++)
            {
                dialogTexts[x].fontStyle = TMPro.FontStyles.Normal;
            }
            dialogTexts[currentAnswer].fontStyle = TMPro.FontStyles.Bold;
            dialogTexts[currentAnswer].fontStyle = TMPro.FontStyles.Underline;
        }
        else if (inp.y == -1 && Time.time - lastChange > 0.2f)
        {
            lastChange = Time.time;
            currentAnswer++;
            if (currentAnswer >= maxAnswer)
                currentAnswer = maxAnswer;
            for (int x = 2; x <= 5; x++)
            {
                dialogTexts[x].fontStyle = TMPro.FontStyles.Normal;
            }
            dialogTexts[currentAnswer].fontStyle = TMPro.FontStyles.Bold;
            dialogTexts[currentAnswer].fontStyle = TMPro.FontStyles.Underline;
        }
        }
        else
        {
            if(inp.y == 1 && Time.time - lastChange > 0.2f && shopCurrentlyChosen > 0){
                lastChange = Time.time;
                lerpFrom = shopChooser.position;
                lerpTo = new Vector2(shopChooser.position.x, shopChooser.position.y + 25);
                ShopLerp= true;
                ShopTimeLerp = Time.realtimeSinceStartup;
                shopCurrentlyChosen--;
        }
            if(inp.y == -1 && Time.time - lastChange > 0.2f && shopCurrentlyChosen < shopChoosable - 1){
                lastChange = Time.time;
                lerpFrom = shopChooser.position;
                lerpTo = new Vector2(shopChooser.position.x, shopChooser.position.y - 25);
                ShopLerp= true;
                ShopTimeLerp = Time.realtimeSinceStartup;
                shopCurrentlyChosen++;
        }

        }
    }

    // Update is called once per frame
    void Update()
    {/*
        if(!shopOpen){
        if(playerOnRange)
            if(Input.GetAxisRaw("Vertical") == 1) {
                StartDialog();
            }
        if(DialogOn){
                    }
                }
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.C)){
            }
        }*/
    }

    void FixedUpdate()
    {
        if (ShopLerp)
        {
            float timesinceStarted = Time.realtimeSinceStartup - ShopTimeLerp;
            float t = timesinceStarted / 0.1f;
            shopChooser.position = Vector2.Lerp(lerpFrom, lerpTo, t);
            if (t >= 1f)
            {
                ShopLerp = false;
                shopChooser.position = new Vector2(lerpFrom.x, lerpTo.y);

            }
        }
    }

    void NextNode()
    {
        if (currentNode > maxNode - 1)
        {
            currentNode = maxNode - 1;
        }
        if (currentNode < 0)
            currentNode = 0;
        currentNodeType = NpcNode.ChildNodes[currentNode].SelectSingleNode("type", nsmgr).InnerText;
        int currentImage = int.Parse(NpcNode.ChildNodes[currentNode].SelectSingleNode("img", nsmgr).InnerText);

        dialogImages[1].sprite = dialogSprites[currentImage];


        if (currentNodeType == "question")
        {
            dialogTexts[0].text = "";
            dialogTexts[1].text = NpcNode.ChildNodes[currentNode].SelectSingleNode("text", nsmgr).InnerText;
            answers = NpcNode.ChildNodes[currentNode].SelectNodes("answer", nsmgr);
            int z = 2;
            Debug.Log(answers.Count);
            minAnswer = 2;
            currentAnswer = 2;
            maxAnswer = minAnswer + answers.Count - 1;
            for (int x = 0; x < answers.Count; x++)
            {
                dialogTexts[z].text = answers.Item(x).InnerText;
                dialogTexts[z].fontStyle = TMPro.FontStyles.Normal;

                z++;
            }
            dialogTexts[currentAnswer].fontStyle = TMPro.FontStyles.Bold;
            dialogTexts[currentAnswer].fontStyle = TMPro.FontStyles.Underline;
        }
        else if (currentNodeType == "text")
        {
            currentTextAnimating = NpcNode.ChildNodes[currentNode].SelectSingleNode("text", nsmgr).InnerText;
            StartCoroutine(AnimateText());
            dialogTexts[1].text = "";
            dialogTexts[2].text = "";
            dialogTexts[3].text = "";
            dialogTexts[4].text = "";
            dialogTexts[5].text = "";
            currentNode = int.Parse(NpcNode.ChildNodes[currentNode].SelectSingleNode("nextID", nsmgr).InnerText);
        }
    }


    void StartDialog()
    {
        DialogOn = true;
        playerScript.dialogOpen = true;
        dialogTexts = DialogUI.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        dialogImages = DialogUI.GetComponentsInChildren<Image>();
        if (firstTime)
            NextNode();
        DialogUI.SetActive(true);
        Destroy(Temp);
        firstTime = false;
    }
    void EndDialog()
    {
        DialogUI.SetActive(false);
        DialogOn = false;
        playerScript.dialogOpen = false;
        inputAction.ShopControl.Disable();
        inputAction.PlayerControl.Enable();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Temp = Instantiate(keyUp, col.bounds.center + new Vector3(0f, 0.45f, 0f), new Quaternion());
            playerOnRange = true;
            playerScript = other.gameObject.GetComponent<PlayerScript>();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(Temp);
            playerOnRange = true;
            if (DialogOn)
                EndDialog();
        }
    }

    IEnumerator AnimateText()
    {
        animationOn = true;
        int length = currentTextAnimating.Length;
        StringBuilder sb = new StringBuilder("", length);
        Debug.Log(sb.ToString());
        dialogTexts[0].text = sb.ToString();
        for (int x = 0; x < length; x++)
        {

            Debug.Log(sb.Length);
            if (currentTextAnimating[x] != ' ')
                yield return new WaitForSecondsRealtime(animationSpeed);
            if (sb.Length > 0)
                sb.Remove(x, sb.Length - x);
            sb.Insert(x, currentTextAnimating[x]);
            sb.AppendFormat("<color=#00000000>{0}</color>", currentTextAnimating.Substring(x + 1));
            dialogTexts[0].text = sb.ToString();
        }
        animationOn = false;
        yield return null;

    }
}
