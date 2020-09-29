using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class CanvasController : MonoBehaviour
{

    public PlayerScript playerScript;
    public GameObject BarLife;
    public Sprite BarLifeSprite;
    public Sprite BarEmptySprite;
    public Transform[] objects;
    private Transform[] tops;
    public UILineRenderer[] bars;
    private Transform bar;
    private Material[] BarMaterial;
    private float[] barCount;
    private InputField maxSlides;
    private Toggle airSlide;
    private string lastMaxSlides;
    [SerializeField]
    private float[] lerpLenght;
    private int lastHP;
    private int lastSlowTime;
    static float[] t;
    private float[] timeStartedLerping;
    private float[] timeSinceStarted;
    private float[] from;
    private float[] to;
    private float[] matCount;
    private bool[] lerping;
    private int[] movingBars;
    private int[] stillBars;
    private int lastChips = 0;
    private TMPro.TextMeshProUGUI chipText;
    // Start is called before the first frame update
    void Awake()
    {
        chipText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        maxSlides = GetComponentInChildren<InputField>();
        airSlide = GetComponentInChildren<Toggle>();
        lastMaxSlides = maxSlides.text;
        objects = GetComponentsInChildren<Transform>();
        bar = objects[4];
        bars = bar.transform.parent.parent.GetComponentsInChildren<UILineRenderer>();
        int z = 0;
        int zz = 0;
        t = new float[bars.Length / 2];
        timeStartedLerping = new float[bars.Length / 2];
        timeSinceStarted = new float[bars.Length / 2];
        from = new float[bars.Length / 2];
        to = new float[bars.Length / 2];
        lerping = new bool[bars.Length / 2];
        movingBars = new int[bars.Length / 2];
        stillBars = new int[bars.Length / 2];
        barCount = new float[bars.Length / 2];
        matCount = new float[bars.Length / 2];
        tops = new Transform[bars.Length / 2];
        lerpLenght = new float[bars.Length / 2];
        
        BarMaterial = new Material[bars.Length / 2];
        barCount[0] = playerScript.maxHP / 2f;
        barCount[1] = playerScript.maxSlowTime / 2f;
        //Debug.LogError("timeStart.length" + timeStartedLerping.Length);
        //Debug.LogError("timeSince.length" + timeSinceStarted .Length);
        //Debug.LogError("from.length" + from.Length);
        //Debug.LogError("to.length" + to.Length);

        for (int n = 1; n < bars.Length; n++)
        {
            if(n % 2 != 0)
            {
                movingBars[z] = n;
                z++;
            }
            else
            {
                stillBars[zz] = n;
                zz++;

            }
        }
        z = 0;
        for (int x = 0; x < objects.Length; x++)
        {
            if(objects[x].name == "Top")
            {
                tops[z] = objects[x];
                z++;
            }
        }
        for (int x = 0; x < tops.Length; x++)
        {
            float y = barCount[x] + 16f - 100f;
            tops[x].localPosition = new Vector3(0f, y, 0f);
            bars[movingBars[x]].Points[1] = new Vector2(7f, barCount[x] + 16f);
            bars[stillBars[x]].Points[1] = new Vector2(7f, barCount[x] + 16f);
            //Debug.Log("movingBars[x] = " + movingBars[x]);
            BarMaterial[x] = bars[movingBars[x]].material;
            //Debug.Log(" bars[movingBars[x]].material = " + bars[movingBars[x]].material);
            lerping[x] = false; 
            matCount[x] = (bars[movingBars[x]].Points[1].y - 16f);
            matCount[x] /= 2.5f;
            BarMaterial[x].SetTextureScale("_MainTex", new Vector2(matCount[x], 1f));
            bars[movingBars[x]].SetAllDirty();
            lerpLenght[x] = 0.3f;
        }
        lastHP = playerScript.currentHP;
        lastSlowTime = playerScript.slowTimeMeter;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastChips != playerScript.chips){
            lastChips = playerScript.chips;
            chipText.text = lastChips.ToString();
            
        }
        //Debug.LogWarning(timeSinceStarted[1]);
        //Debug.LogWarning(timeStartedLerping[1]);
        for (int x = 0; x < bars.Length/2; x++) {
            //Debug.Log("x=" + x);
            if (lerping[x])
            {
                //Debug.LogWarning("Lerping = " + x);
                timeSinceStarted[x] = Time.realtimeSinceStartup - timeStartedLerping[x];
                t[x] = timeSinceStarted[x] / lerpLenght[x];
                if (to[x] < 0)
                {
                    to[x] = 0;
                }
                bars[movingBars[x]].Points[1] = new Vector2(7f, Mathf.Lerp((from[x] / 2f) + 16f, (to[x] / 2f) + 16f, t[x]));
                matCount[x] = (bars[movingBars[x]].Points[1].y - 16f);
                matCount[x] /= 2.5f;
                BarMaterial[x].SetTextureScale("_MainTex", new Vector2(matCount[x], 1f));
                bars[movingBars[x]].SetAllDirty();

                if (t[x] >= 1.0f)
                {
                    t[x] = 0.0f;
                    lerping[x] = false;
                    bars[movingBars[x]].Points[1] = new Vector2(7f, (to[x] / 2f) + 16f);
                }
            }
        }
        if (lastHP != playerScript.currentHP)
        {
            //Debug.Log(lastHP);
            from[0] = lastHP;
            to[0] = playerScript.currentHP;
            lastHP = playerScript.currentHP;
            lerping[0] = true;
            timeStartedLerping[0] = Time.realtimeSinceStartup;
        }

        if (lastSlowTime != playerScript.slowTimeMeter)
        {
            from[1] = lastSlowTime;
            to[1] = playerScript.slowTimeMeter;
            lastSlowTime = playerScript.slowTimeMeter;
            lerping[1] = true;
            timeStartedLerping[1] = Time.realtimeSinceStartup;
        }


        if (airSlide.isOn)
        {
            playerScript.airSlide = true;
        }
        else
        {
            playerScript.airSlide = false;
        }
        if(maxSlides.text != lastMaxSlides)
        {
            int.TryParse(maxSlides.text, out playerScript.maxSlides);
        }
    }
}
