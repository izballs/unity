using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ColorPreview : MonoBehaviour
{
    private Material mat;
    private Image img;
    public Slider red;
    public Slider green;
    public Slider blue;
    public Toggle hardmix;
    public float defRed = 0.29f;
    public float defGreen = 0.47f;
    public float defBlue = 0.65f;
    


    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        mat = img.material;    
        Debug.Log(mat);
        if(PlayerPrefs.HasKey("RED"))
            {
            red.value = PlayerPrefs.GetFloat("RED");
            UpdateRED(PlayerPrefs.GetFloat("RED"));
            }
        else
        {
            red.value = defRed; 
            UpdateRED(defRed);
        }
        if(PlayerPrefs.HasKey("GREEN"))
        {
            green.value = PlayerPrefs.GetFloat("GREEN");
            Debug.Log("green=" +green.value);
            UpdateGREEN(PlayerPrefs.GetFloat("GREEN"));
        }
        else
        {
            red.value = defGreen; 
            UpdateRED(defGreen);
        }
            if(PlayerPrefs.HasKey("BLUE"))
            {
                blue.value = PlayerPrefs.GetFloat("BLUE");
                Debug.Log("blue=" +blue.value);
                UpdateBLUE(PlayerPrefs.GetFloat("BLUE"));
            }
        else
        {
            red.value = defBlue; 
            UpdateRED(defBlue);
        }
                if(PlayerPrefs.HasKey("HardMix"))
                { 
                    hardmix.isOn = PlayerPrefs.GetInt("HardMix") == 1?true:false;
                    UpdateHardMix(PlayerPrefs.GetInt("HardMix"));
                }
        else
        {
            hardmix.isOn = false; 
            UpdateHardMix(0);
        }
    }

    public void UpdateHardMix(int value){
        mat.SetInt("HardMix", value);
        PlayerPrefs.SetInt("HardMix", value);
    }

    public void UpdateHardMix(bool value){
        mat.SetInt("HardMix", value?1:0);
        PlayerPrefs.SetInt("HardMix", value?1:0);
    }

    public void UpdateRED(float value){
        mat.SetFloat("RED", value);
        PlayerPrefs.SetFloat("RED", value);
    }
    public void UpdateGREEN(float value){
        mat.SetFloat("GREEN", value);
        PlayerPrefs.SetFloat("GREEN", value);
    }
    public void UpdateBLUE(float value){
        mat.SetFloat("BLUE", value);
        PlayerPrefs.SetFloat("BLUE", value);
    }

    public void SaveSettings(){
        ExitGames.Client.Photon.Hashtable hashTable = new ExitGames.Client.Photon.Hashtable();
        hashTable.Add("PlayerColorRed", PlayerPrefs.GetFloat("RED"));
        hashTable.Add("PlayerColorGreen", PlayerPrefs.GetFloat("GREEN"));
        hashTable.Add("PlayerColorBlue", PlayerPrefs.GetFloat("BLUE"));
        hashTable.Add("PlayerColorHardMix", PlayerPrefs.GetInt("HardMix"));


        PhotonNetwork.SetPlayerCustomProperties(hashTable);
        }

    // Update is called once per frame
    void Update()
    {
    }
}
