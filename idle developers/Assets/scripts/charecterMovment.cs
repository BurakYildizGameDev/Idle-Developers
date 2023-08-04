using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using System.Runtime.ConstrainedExecution;

public class charecterMovment : MonoBehaviour
{
    GameObject anaNesne;
    [SerializeField] private int money;
    [SerializeField] private TextMeshProUGUI moneytext;
    private Coroutine webOpenCoroutine;
    private Coroutine gameOpenCoroutine;
    private Coroutine androidOpenCoroutine;
    private Coroutine iosOpenCoroutine;
    private Coroutine windowsOpenCoroutine;

    float xMovment;
    float zMovment;
    Vector3 MoveDirection;

    [SerializeField] float MoveSpeed=5f;
    Animator animator;
    Rigidbody rb;
    [SerializeField] float animatordamp=1f;
    //animasyon yumsaklýgý icin 
    bool workinside;
    public GameObject work,outwork, boost,boost2,joystcik;
    public Renderer playerrender;
    public GameObject workcamera,maincamera;

    public bool startingMoney;

    public GameObject[] panels;
    private bool playerinwork;

    private float counter = 0f; // Sayacýn baþlangýç deðeri

    public int[] weblevels = new int[5];
    [SerializeField] int[] weblevelsprice = new int[5];

    [SerializeField] int[] gamelevels = new int[5];
    [SerializeField] int[] gamelevelsprice = new int[5];

    [SerializeField] int[] androidlevels = new int[5];
    [SerializeField] int[] androidlevelsprice = new int[5];

    [SerializeField] int[] ioslevels = new int[5];
    [SerializeField] int[] ioslevelsprice = new int[5];

    [SerializeField] int[] windowslevels = new int[5];
    [SerializeField] int[] windowslevelsprice = new int[5];

    [SerializeField] GameObject[] webdevelopers;
    [SerializeField] GameObject[] gamedevelopers;
    [SerializeField] GameObject[] androiddevelopers;
    [SerializeField] GameObject[] iosdevelopers;
    [SerializeField] GameObject[] windowevelopers;
    [SerializeField] GameObject[] rooms;
    [SerializeField] GameObject[] plane;
    [SerializeField] TextMeshPro[] planetexts;
    [SerializeField] GameObject incomputer;

    private Coroutine webartmaCoroutine;
    private Coroutine gameartmaCoroutine;
    private Coroutine androidartmaCoroutine;
    private Coroutine iosartmaCoroutine;
    private Coroutine windowsartmaCoroutine;
  
    public int webmoney=500;
    public int gamemoney = 750;
    public int androidmoney = 1000;
    public int iosmoney = 1250;
    public int windowsmoney = 1500;
    public int earnedMoney;

    public int webearnedMoney;
    public int gameearnedMoney;

    private bool webMoneyTriggered = false;
    private bool gameMoneyTriggered = false;
    private bool androidMoneyTriggered = false;
    private bool iosMoneyTriggered = false;
    private bool windowsMoneyTriggered = false;

    private float timeCounter = 0f;
    private float interval = 1f; // Toplama aralýðý, burada 1 saniye olarak ayarlanmýþ

    public GameObject[] butons;
    public TextMeshProUGUI[] leveltexts;
    public TextMeshProUGUI[] levelpricetexts;
    void Start()
    {
        animator = GetComponent < Animator>();
        rb= GetComponent <Rigidbody>();

        earnedMoney = 0;

        anaNesne = this.gameObject;

        
        //web levels durumlarý 
        weblevels[0] = 0;
        weblevels[1] = 0;
        weblevels[2] = 0;
        weblevels[3] = 0;
        weblevels[4] = 0;
        
        weblevelsprice[0] = 100;
        weblevelsprice[1] = 115;
        weblevelsprice[2] = 130;
        weblevelsprice[3] = 145;
        weblevelsprice[4] = 200;
        
        //gamedevlevels durumlarý
        gamelevels[0] = 0;
        gamelevels[1] = 0;
        gamelevels[2] = 0;
        gamelevels[3] = 0;
        gamelevels[4] = 0;
        
        gamelevelsprice[0] = 100;
        gamelevelsprice[1]= 115;
        gamelevelsprice[2]= 130;
        gamelevelsprice[3]= 145;
        gamelevelsprice[4] = 200;

        
        //androidlevels durumlarý
        androidlevels[0] = 0;
        androidlevels[1] = 0;
        androidlevels[2] = 0;
        androidlevels[3] = 0;
        androidlevels[4] = 0;
        
        androidlevelsprice[0] = 100;
        androidlevelsprice[1] = 115;
        androidlevelsprice[2] = 130;
        androidlevelsprice[3] = 145;
        androidlevelsprice[4] = 200;
        
        //ios levels durumlarý
        ioslevels[0] = 0;
        ioslevels[1] = 0;
        ioslevels[2] = 0;
        ioslevels[3] = 0;
        ioslevels[4] = 0;
        
        ioslevelsprice[0] = 100;
        ioslevelsprice[1] = 115;
        ioslevelsprice[2] = 130;
        ioslevelsprice[3] = 145;
        ioslevelsprice[4] = 200;
        
        //windows levels durumlarý
        windowslevels[0] = 0;
        windowslevels[1] = 0;
        windowslevels[2] = 0;
        windowslevels[3] = 0;
        windowslevels[4] = 0;
        
        windowslevelsprice[0] = 100;
        windowslevelsprice[1] = 115;
        windowslevelsprice[2] = 130;
        windowslevelsprice[3] = 145;
        windowslevelsprice[4] = 200;

        //basta herkes kapalý adam birz para kazansýn

        for (int i = 0; i < webdevelopers.Length; i++) 
        {
            webdevelopers[i].SetActive(false);
        }
        for (int i = 0; i < gamedevelopers.Length; i++)
        {
            gamedevelopers[i].SetActive(false);
        }
        for (int i = 0; i < androiddevelopers.Length; i++)
        {
            androiddevelopers[i].SetActive(false);
        }
        for (int i = 0; i < iosdevelopers.Length; i++)
        {
            iosdevelopers[i].SetActive(false);
        }
        for (int i = 0; i < windowevelopers.Length; i++)
        {
            windowevelopers[i].SetActive(false);
        }
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].SetActive(false);
        }
        for (int i = 1; i < plane.Length; i++)
        {
            plane[i].SetActive(false);
        }
        for (int i = 0; i < butons.Length; i++)
        {
            butons[i].SetActive(false) ;
        }

        StartCoroutine(earnedMoneytoplama());

        
        money = PlayerPrefs.GetInt("money", 0);
        webmoney = PlayerPrefs.GetInt("webmoney", 500);
        gamemoney = PlayerPrefs.GetInt("gamemoney", 750);
        androidmoney = PlayerPrefs.GetInt("androidmoney", 1000);
        iosmoney = PlayerPrefs.GetInt("iosmoney ", 1250);
        windowsmoney = PlayerPrefs.GetInt("windowsmoney", 1500);
        earnedMoney = PlayerPrefs.GetInt("earnedMoney");

        // weblevels dizisini PlayerPrefs'den yüklemek
        for (int i = 0; i < weblevels.Length; i++)
        {
            weblevels[i] = PlayerPrefs.GetInt("weblevel_" + i, 0);
        }

        // weblevelsprice dizisini PlayerPrefs'den yüklemek
        for (int i = 0; i < weblevelsprice.Length; i++)
        {
            weblevelsprice[i] = PlayerPrefs.GetInt("weblevelprice_" + i, 0);
        }

        // gamelevels dizisini PlayerPrefs'den yüklemek
        for (int i = 0; i < gamelevels.Length; i++)
        {
            gamelevels[i] = PlayerPrefs.GetInt("gamelevel_" + i, 0);
        }

        // gamelevelsprice dizisini PlayerPrefs'den yüklemek
        for (int i = 0; i < gamelevelsprice.Length; i++)
        {
            gamelevelsprice[i] = PlayerPrefs.GetInt("gamelevelprice_" + i, 0);
        }

        // androidlevels dizisini PlayerPrefs'den yüklemek
        for (int i = 0; i < androidlevels.Length; i++)
        {
            androidlevels[i] = PlayerPrefs.GetInt("androidlevel_" + i, 0);
        }

        // androidlevelsprice dizisini PlayerPrefs'den yüklemek
        for (int i = 0; i < androidlevelsprice.Length; i++)
        {
            androidlevelsprice[i] = PlayerPrefs.GetInt("androidlevelprice_" + i, 0);
        }

        // ioslevelsprice dizisini PlayerPrefs'den yüklemek
        for (int i = 0; i < ioslevelsprice.Length; i++)
        {
            ioslevelsprice[i] = PlayerPrefs.GetInt("ioslevelprice_" + i, 0);
        }

        // ioslevelsprice dizisini PlayerPrefs'den yüklemek
        for (int i = 0; i < ioslevelsprice.Length; i++)
        {
            ioslevelsprice[i] = PlayerPrefs.GetInt("ioslevelprice_" + i, 0);
        }

        // windowslevels dizisini PlayerPrefs'den yüklemek
        for (int i = 0; i < windowslevels.Length; i++)
        {
            windowslevels[i] = PlayerPrefs.GetInt("windowslevel_" + i, 0);
        }

        // windowslevelsprice dizisini PlayerPrefs'den yüklemek
        for (int i = 0; i < windowslevelsprice.Length; i++)
        {
            windowslevelsprice[i] = PlayerPrefs.GetInt("windowslevelprice_" + i, 0);
        }
    }

    void Update()
    {


        PlayerPrefs.SetInt("money", (int)money);
        PlayerPrefs.SetInt("webmoney", (int)webmoney);
        PlayerPrefs.SetInt("gamemoney", (int)gamemoney);
        PlayerPrefs.SetInt("androidmoney", (int)androidmoney);
        PlayerPrefs.SetInt("iosmoney", (int)iosmoney);
        PlayerPrefs.SetInt("windowsmoney", (int)windowsmoney);
        PlayerPrefs.SetInt("earnedmoney", (int)earnedMoney);

        // weblevels dizisini PlayerPrefs ile kaydetmek
        for (int i = 0; i < weblevels.Length; i++)
        {
            PlayerPrefs.SetInt("weblevel_" + i, weblevels[i]);
        }

        // weblevelsprice dizisini PlayerPrefs ile kaydetmek
        for (int i = 0; i < weblevelsprice.Length; i++)
        {
            PlayerPrefs.SetInt("weblevelprice_" + i, weblevelsprice[i]);
        }

        // gamelevels dizisini PlayerPrefs ile kaydetmek
        for (int i = 0; i < gamelevels.Length; i++)
        {
            PlayerPrefs.SetInt("gamelevel_" + i, gamelevels[i]);
        }

        // gamelevelsprice dizisini PlayerPrefs ile kaydetmek
        for (int i = 0; i < gamelevelsprice.Length; i++)
        {
            PlayerPrefs.SetInt("gamelevelprice_" + i, gamelevelsprice[i]);
        }
        // androidlevels dizisini PlayerPrefs ile kaydetmek
        for (int i = 0; i < androidlevels.Length; i++)
        {
            PlayerPrefs.SetInt("androidlevel_" + i, androidlevels[i]);
        }

        // androidlevelsprice dizisini PlayerPrefs ile kaydetmek
        for (int i = 0; i < androidlevelsprice.Length; i++)
        {
            PlayerPrefs.SetInt("androidlevelprice_" + i, androidlevelsprice[i]);
        }

        // ioslevels dizisini PlayerPrefs ile kaydetmek
        for (int i = 0; i < ioslevels.Length; i++)
        {
            PlayerPrefs.SetInt("ioslevel_" + i, ioslevels[i]);
        }

        // windowslevelsprice dizisini PlayerPrefs ile kaydetmek
        for (int i = 0; i < windowslevelsprice.Length; i++)
        {
            PlayerPrefs.SetInt("windowslevelprice_" + i, windowslevelsprice[i]);
        }
        // windowslevels dizisini PlayerPrefs ile kaydetmek
        for (int i = 0; i < windowslevels.Length; i++)
        {
            PlayerPrefs.SetInt("ioslevel_" + i, windowslevels[i]);
        }

        // windowslevelsprice dizisini PlayerPrefs ile kaydetmek
        for (int i = 0; i < windowslevelsprice.Length; i++)
        {
            PlayerPrefs.SetInt("windowslevelprice_" + i, windowslevelsprice[i]);
        }

        xMovment = SimpleInput.GetAxisRaw("Horizontal");
        zMovment = SimpleInput.GetAxisRaw("Vertical");
        //burada simple imput icin giriþi belirttik 

        MoveDirection = new Vector3(xMovment, rb.velocity.y, zMovment);
        //giriþi belirttik

        updateanimation();
        look();


        //web kýsmý için

        // startingMoney bool deðiþkeni güncellendiðinde çalýþacak olan kod bloðu
        if (startingMoney && webartmaCoroutine == null)
        {
            // SaniyedeBirArtirCoroutine adlý Coroutine'i baþlat
            webartmaCoroutine = StartCoroutine(SaniyedeBirArtirCoroutine());
        }
        else if (!startingMoney && webartmaCoroutine != null)
        {
            // Eðer startingMoney false ise, Coroutine'i durdur
            StopCoroutine(webartmaCoroutine);
            webartmaCoroutine = null;
        }

        //game kýsmý için

        if (startingMoney && gameartmaCoroutine == null)
        {
             gameartmaCoroutine = StartCoroutine(SaniyedeBirArtirCoroutine());
        }
        else if (!startingMoney && gameartmaCoroutine != null)
        {
            StopCoroutine(gameartmaCoroutine);
            gameartmaCoroutine = null;
        }

        //android kýsmý 

        if (startingMoney && androidartmaCoroutine == null)
        {
            androidartmaCoroutine = StartCoroutine(SaniyedeBirArtirCoroutine());
        }
        else if (!startingMoney && androidartmaCoroutine != null)
        {
            StopCoroutine(androidartmaCoroutine);
            androidartmaCoroutine = null;
        }

        //ios kýsmý
        if (startingMoney && iosartmaCoroutine == null)
        {
            iosartmaCoroutine = StartCoroutine(SaniyedeBirArtirCoroutine());
        }
        else if (!startingMoney && iosartmaCoroutine != null)
        {
            StopCoroutine(iosartmaCoroutine);
            iosartmaCoroutine = null;
        }

        //windows kýsmý

        if (startingMoney && windowsartmaCoroutine == null)
        {
            windowsartmaCoroutine = StartCoroutine(SaniyedeBirArtirCoroutine());
        }
        else if (!startingMoney && windowsartmaCoroutine != null)
        {
            StopCoroutine(windowsartmaCoroutine);
            windowsartmaCoroutine = null;
        }

        //plane yani yerlerin acýlma kýsmý
        if (webmoney == 0)
        {
            Destroy(plane[0]);
            rooms[0].SetActive(true);
            plane[1].SetActive(true);   
        }
        if (gamemoney == 0&& webmoney==0)
        {
            plane[1].SetActive(false);//destroy etme hata alýoruz
            rooms[1].SetActive(true);
            plane[2].SetActive(true);
        }
       if (gamemoney == 0 && webmoney == 0 && androidmoney==0)
        {
            plane[2].SetActive(false);
            rooms[2].SetActive(true);
            plane[3].SetActive(true);
        }
        if (gamemoney == 0 && webmoney == 0 && androidmoney == 0 && iosmoney==0)
        {
            plane[3].SetActive(false);
            rooms[3].SetActive(true);
            plane[4].SetActive(true);
        }
        if (gamemoney == 0 && webmoney == 0 && androidmoney == 0 && iosmoney == 0 && windowsmoney == 0)
        {
            plane[4].SetActive(false);
            rooms[4].SetActive(true);
        }

        //web sayacý arttýrma

        // Her frame için zaman sayacýný güncelle
        timeCounter += Time.deltaTime;

        // Zaman sayacý belirli bir süreyi geçtiyse (interval süresini aþtýysa)
        if (timeCounter >= interval)
       {
         // Ýki sayýyý topla
          money += webearnedMoney;

          // Zaman sayacýný sýfýrla
         timeCounter = 0f;
       }
        
        //game sayacý arttýrma
        if (gamelevels[4] >=1)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= interval)
            {
                money += gameearnedMoney;

                timeCounter = 0f;
            }
        }

        //android sayacý arttýrma
        if (androidlevels[4] >= 1)
        {
            // Her frame için zaman sayacýný güncelle
            timeCounter += Time.deltaTime;

            // Zaman sayacý belirli bir süreyi geçtiyse (interval süresini aþtýysa)
            if (timeCounter >= interval)
            {
                // Ýki sayýyý topla
                money += gameearnedMoney;

                // Zaman sayacýný sýfýrla
                timeCounter = 0f;
            }
        }

        if (ioslevels[4] >= 1)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= interval)
            {
                money += gameearnedMoney;
                timeCounter = 0f;
            }
        }

        if (windowslevels[4] >= 1)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= interval)
            {
                money += gameearnedMoney;
                timeCounter = 0f;
            }
        }


        if (weblevels[4]>0)
        {
            for (int i = 0; i < 4; i++)
            {
                butons[i].SetActive(true);
            }
        }
        if (gamelevels[4] > 0)
        {
            for (int i = 0; i < 8; i++)
            {
                butons[i].SetActive(true);
            }
        }
        if (androidlevels[4] > 0)
        {
            for (int i = 0; i < 12; i++)
            {
                butons[i].SetActive(true);
            }
        }
        if (ioslevels[4] > 0)
        {
            for (int i = 0; i < 16; i++)
            {
                butons[i].SetActive(true);
            }
        }
        if (windowslevels[4] > 0)
        {
            for (int i = 0; i < 20; i++)
            {
                butons[i].SetActive(true);
            }
        }
        
        if(playerinwork == false)
        {
            incomputer.SetActive(false);
        }
        else
        {
            incomputer.SetActive(true);
        }

        moneytext.text = money.ToString() ;

        for (int i = 0;i < weblevels[4];i++)
        {
            webdevelopers[i].SetActive(true);
        }
        for (int i = 0; i < gamelevels[4]; i++)
        {
            gamedevelopers[i].SetActive(true);
        }
        for (int i = 0; i < androidlevels[4]; i++)
        {
            androiddevelopers[i].SetActive(true);
        }
        for (int i = 0; i < ioslevels[4]; i++)
        {
            iosdevelopers[i].SetActive(true);
        }
        for (int i = 0; i < windowslevels[4]; i++)
        {
            windowevelopers[i].SetActive(true);
        }

        planetexts[0].text = "Price: " + webmoney.ToString() + " $";
        planetexts[1].text = "Price: " + gamemoney.ToString() + " $";
        planetexts[2].text = "Price: " + androidmoney.ToString() + " $";
        planetexts[3].text = "Price: " + iosmoney.ToString() + " $";
        planetexts[4].text = "Price: " + windowsmoney.ToString() + " $";

        leveltexts[0].text = "Level : " + weblevels[0].ToString();
        leveltexts[1].text = "Level : " + weblevels[1].ToString();
        leveltexts[2].text = "Level : " + weblevels[2].ToString();
        leveltexts[3].text = "Level : " + weblevels[3].ToString();
        leveltexts[4].text = "Level : " + weblevels[4].ToString();
        leveltexts[5].text = "Level : " + gamelevels[0].ToString();
        leveltexts[6].text = "Level : " + gamelevels[1].ToString();
        leveltexts[7].text = "Level : " + gamelevels[2].ToString();
        leveltexts[8].text = "Level : " + gamelevels[3].ToString();
        leveltexts[9].text = "Level : " + gamelevels[4].ToString();
        leveltexts[10].text = "Level : " + androidlevels[0].ToString();
        leveltexts[11].text = "Level : " + androidlevels[1].ToString();
        leveltexts[12].text = "Level : " + androidlevels[2].ToString();
        leveltexts[13].text = "Level : " + androidlevels[3].ToString();
        leveltexts[14].text = "Level : " + androidlevels[4].ToString();
        leveltexts[15].text = "Level : " + ioslevels[0].ToString();
        leveltexts[16].text = "Level : " + ioslevels[1].ToString();
        leveltexts[17].text = "Level : " + ioslevels[2].ToString();
        leveltexts[18].text = "Level : " + ioslevels[3].ToString();
        leveltexts[19].text = "Level : " + ioslevels[4].ToString();
        leveltexts[20].text = "Level : " + windowslevels[0].ToString();
        leveltexts[21].text = "Level : " + windowslevels[1].ToString();
        leveltexts[22].text = "Level : " + windowslevels[2].ToString();
        leveltexts[23].text = "Level : " + windowslevels[3].ToString();
        leveltexts[24].text = "Level : " + windowslevels[4].ToString();

        levelpricetexts[0].text = "Price : " + weblevelsprice[0].ToString();
        levelpricetexts[1].text = "Price : " + weblevelsprice[1].ToString();
        levelpricetexts[2].text = "Price : " + weblevelsprice[2].ToString();
        levelpricetexts[3].text = "Price : " + weblevelsprice[3].ToString();
        levelpricetexts[4].text = "Price : " + weblevelsprice[4].ToString();
        levelpricetexts[5].text = "Price : " + gamelevelsprice[0].ToString();
        levelpricetexts[6].text = "Price : " + gamelevelsprice[1].ToString();
        levelpricetexts[7].text = "Price : " + gamelevelsprice[2].ToString();
        levelpricetexts[8].text = "Price : " + gamelevelsprice[3].ToString();
        levelpricetexts[9].text = "Price : " + gamelevelsprice[4].ToString();
        levelpricetexts[10].text = "Price : " + androidlevelsprice[0].ToString();
        levelpricetexts[11].text = "Price : " + androidlevelsprice[1].ToString();
        levelpricetexts[12].text = "Price : " + androidlevelsprice[2].ToString();
        levelpricetexts[13].text = "Price : " + androidlevelsprice[3].ToString();
        levelpricetexts[14].text = "Price : " + androidlevelsprice[4].ToString();
        levelpricetexts[15].text = "Price : " + ioslevelsprice[0].ToString();
        levelpricetexts[16].text = "Price : " + ioslevelsprice[1].ToString();
        levelpricetexts[17].text = "Price : " + ioslevelsprice[2].ToString();
        levelpricetexts[18].text = "Price : " + ioslevelsprice[3].ToString();
        levelpricetexts[19].text = "Price : " + ioslevelsprice[4].ToString();
        levelpricetexts[20].text = "Price : " + windowslevelsprice[0].ToString();
        levelpricetexts[21].text = "Price : " + windowslevelsprice[1].ToString();
        levelpricetexts[22].text = "Price : " + windowslevelsprice[2].ToString();
        levelpricetexts[23].text = "Price : " + windowslevelsprice[3].ToString();
        levelpricetexts[24].text = "Price : " + windowslevelsprice[4].ToString();

        //money += earnedMoney;
    }
    private void FixedUpdate()
    {
        rb.velocity= MoveDirection*MoveSpeed;
        //hareketi belirttik 
        //daha sonra simple imput dan joyistic ekledik 
        //canvas scalerden canvas with screen size yapýlýr 1280 e 720 
    }
    void updateanimation()
    {
        animator.SetFloat("moveSpeed",MoveDirection.magnitude);
        //yuryuste 0 ile 1 arasýnda daha yumsak olsun diye
        //hazýr method kullan
    }
    void look()
    {
        if (MoveDirection.magnitude < 0.1) return;
        {
            Vector3 rotvector = Camera.main.transform.TransformDirection(MoveDirection);
            rotvector.y = 0;
            transform.forward = Vector3.Slerp(transform.forward, rotvector, 3f);
            //burada bakýs acýsýný ayarladýk
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("work"))
        {
            work.SetActive(true);
        }

        if(other.gameObject.CompareTag("webtriger"))
        {
            panels[0].SetActive(true);
        }
        else if (other.gameObject.CompareTag("gametriger"))
        {
            panels[1].SetActive(true);
        }
        else if (other.gameObject.CompareTag("androidtriger"))
        {
            panels[2].SetActive(true);
        }
        else if (other.gameObject.CompareTag("iostriger"))
        {
            panels[3].SetActive(true);
        }
        else if (other.gameObject.CompareTag("windowstriger"))
        {
            panels[4].SetActive(true);
        }


    
    }
    private void OnTriggerStay(Collider other)
    {

        //paranýn sýfýra dusme durumuna care bul negatif olmasýn
        //web yeri acma
        if (other.gameObject.CompareTag("webmoney"))
        {
            if (money > 0 && webmoney > 0)
            {
                if (!webMoneyTriggered)
                {
                    webOpenCoroutine = StartCoroutine(WebOpenCoroutine());
                    webMoneyTriggered = true;
                }
            }
            else if(money==0)
            {
                StopCoroutine(webOpenCoroutine);
                webMoneyTriggered = false;
            }
        }
        //game yeri acma
        if (other.gameObject.CompareTag("gamemoney"))
        {
            if (money > 0 && gamemoney > 0)
            {
                if (!gameMoneyTriggered)
                {
                    gameOpenCoroutine = StartCoroutine(GameOpenCoroutine());
                    gameMoneyTriggered = true;
                }
            }
            else if (money == 0)
            {
                StopCoroutine(gameOpenCoroutine);
                gameMoneyTriggered = false;
            }
        }
        //androidyeri acma
        if (other.gameObject.CompareTag("androidmoney"))
        {
            if (money > 0 && androidmoney > 0)
            {
                if (!androidMoneyTriggered)
                {
                    androidOpenCoroutine = StartCoroutine(AndroidOpenCoroutine());
                    androidMoneyTriggered = true;
                }
            }
            else if (money == 0)
            {
                StopCoroutine(androidOpenCoroutine);
                androidMoneyTriggered = false;
            }
        }
        //ios yeri acma
        if (other.gameObject.CompareTag("iosmoney"))
        {
            if (money > 0 && iosmoney > 0)
            {
                if (!iosMoneyTriggered)
                {
                    iosOpenCoroutine = StartCoroutine(IosOpenCoroutine());
                    iosMoneyTriggered = true;
                }
            }
            else if (money == 0)
            {
                StopCoroutine(iosOpenCoroutine);
                iosMoneyTriggered = false;
            }
        }
        //windows yeri acma
        if (other.gameObject.CompareTag("windowsmoney"))
        {
            if (money > 0 && windowsmoney > 0)
            {
                if (!windowsMoneyTriggered)
                {
                    windowsOpenCoroutine = StartCoroutine(WindowsOpenCoroutine());
                    windowsMoneyTriggered = true;
                }
            }
            else if (money == 0)
            {
                StopCoroutine(windowsOpenCoroutine);
                windowsMoneyTriggered = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //web yeri çýkma
        if (other.gameObject.CompareTag("webmoney"))
        {
            if (webOpenCoroutine != null)
            {
                StopCoroutine(webOpenCoroutine);
                webMoneyTriggered = false;
            }
        }
        //game yeri çýkma
        if (other.gameObject.CompareTag("gamemoney"))
        {
            if (gameOpenCoroutine != null)
            {
                StopCoroutine(gameOpenCoroutine);
                gameMoneyTriggered = false;
            }
        }
        //android yeri çýkma
        if (other.gameObject.CompareTag("androidmoney"))
        {
            if (androidOpenCoroutine != null)
            {
                StopCoroutine(androidOpenCoroutine);
                androidMoneyTriggered = false;
            }
        }
        //ios yeri çýkma
        if (other.gameObject.CompareTag("iosmoney"))
        {
            if (iosOpenCoroutine != null)
            {
                StopCoroutine(iosOpenCoroutine);
                iosMoneyTriggered = false;
            }
        }
        //windows yeri çýkma
        if (other.gameObject.CompareTag("windowsmoney"))
        {
            if (windowsOpenCoroutine != null)
            {
                StopCoroutine(windowsOpenCoroutine);
                windowsMoneyTriggered= false;
            }
        }
    }

    public void workinbutton()
    {
        playerrender.enabled = false;
        workcamera.SetActive(true);
        maincamera.SetActive(false);
        outwork.SetActive(true);
        work.SetActive(false);
        boost.SetActive(true);
        boost2.SetActive(true);
        joystcik.SetActive(false);
        playerinwork = true;
        startingMoney = true;
    }
    public void workoutbutton()
    {
        playerrender.enabled = true;
        workcamera.SetActive(false);
        maincamera.SetActive(true);
        outwork.SetActive(false);
        work.SetActive(false);
        boost.SetActive(false);
        boost2.SetActive(false);
        joystcik.SetActive(true);
        playerinwork = false;
        startingMoney = false;
    }
    public void quit()
    {
        panels[0].SetActive(false);
        panels[1].SetActive(false);
        panels[2].SetActive(false);
        panels[3].SetActive(false);
        panels[4].SetActive(false);
    }

    //web dev geliþtirme
    public void htmllevel()
    {
        if (money > weblevelsprice[0])
        {
          weblevels[0]++;
            money -= weblevelsprice[0];
          weblevelsprice[0] = weblevelsprice[0] + 150;
          earnedMoney += 1;
        }
        else if (weblevels[0]==10)
        {
            weblevels[0] +=0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void Csslevel()
    {
        if (money > weblevelsprice[1])
        {
            weblevels[1]++;
            money -= weblevelsprice[1];
            weblevelsprice[1] = weblevelsprice[1] + 150;
            earnedMoney += 1;
        }
        else if (weblevels[1] == 10)
        {
            weblevels[1] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void javascriptlevel()
    {
        if (money > weblevelsprice[2])
        {
            weblevels[2]++;
            money -= weblevelsprice[2];
            weblevelsprice[2] = weblevelsprice[2] + 150;
            earnedMoney += 1;
        }
        else if (weblevels[2] == 10)
        {
            weblevels[2] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void phplevel()
    {
        if (money > weblevelsprice[3])
        {
            weblevels[3]++;
             money -= weblevelsprice[3];
            weblevelsprice[3] = weblevelsprice[3] + 150;
            earnedMoney += 1;
        }
        else if (weblevels[3] == 10)
        {
            weblevels[3] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }   
    public void webdevlevel()
    {
        if (money > weblevelsprice[4])
        {
            weblevels[4]++;
                money -= weblevelsprice[4];
            weblevelsprice[4] = weblevelsprice[4] + 300;
            earnedMoney += 2;
        }
        else if (weblevels[4] == 12)
        {
            weblevels[1] += 0;
            earnedMoney += 0;
            //max 12 yazacak
        }
        
    }

    //game dev geliþtirme
    public void Csharplevel()
    {
        if (money > gamelevels[0])
        {
            gamelevels[0]++;
            money -= gamelevelsprice[0];
            gamelevelsprice[0] = gamelevelsprice[0] + 150;
            earnedMoney += 1;
        }
        else if (gamelevels[0] == 10)
        {
            gamelevels[0] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        } 
    }
    public void cplasplaslevel()
    {
        if (money > gamelevels[1])
        {
            gamelevels[1]++;
            money -= gamelevelsprice[1];
            gamelevelsprice[1] = gamelevelsprice[1] + 150;
            earnedMoney += 1;
        }
        else if (gamelevels[1] == 10)
        {
            gamelevels[1] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void unreallevel()
    {
        if (money > gamelevelsprice[2])
        {
            gamelevels[2]++;
            money -= gamelevels[2];
            gamelevelsprice[2] = gamelevelsprice[2] + 150;
            earnedMoney += 1;
        }
        else if (gamelevelsprice[2] == 10)
        {
            gamelevels[2] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void unitylevel()
    {
        if (money > gamelevelsprice[3])
        {
            gamelevels[3]++;
            money -= gamelevelsprice[3];
            gamelevelsprice[3] = gamelevelsprice[3] + 150;
            earnedMoney += 1;
        }
        else if (gamelevels[3] == 10)
        {
            gamelevels[3] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void gamedevlevel()
    {
        if (money > gamelevelsprice[4])
        {
            gamelevels[4]++;
            money -= gamelevelsprice[4];
            gamelevelsprice[4] = gamelevelsprice[4] + 300;
            earnedMoney += 2; 
        }
        else if (gamelevels[4] == 12)
        {
            gamelevels[1] += 0;
            earnedMoney += 0;
            //max 12 yazacak
        }
    }



    //android dev geliþtirme
    public void javalevel()
    {
        if (money > androidlevelsprice[0])
        {
            androidlevels[0]++;
            money -= androidlevelsprice[0];
            androidlevelsprice[0] = androidlevelsprice[0] + 150;
            earnedMoney += 1;
        }
        else if (androidlevels[0] == 10)
        {
            androidlevels[0] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void andridstore()
    {
        if (money > androidlevelsprice[1])
        {
            androidlevels[1]++;
            money -= androidlevelsprice[1];
            androidlevelsprice[1] = androidlevelsprice[1] + 150;
            earnedMoney += 1;
        }
        else if (androidlevels[1] == 10)
        {
            androidlevels[1] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void andridSDK()
    {
        if (money > androidlevelsprice[2])
        {
            androidlevels[2]++;
            money -= androidlevelsprice[2];
            androidlevelsprice[2] = androidlevelsprice[2] + 150;
            earnedMoney += 1;
        }
        else if (androidlevels[2] == 10)
        {
            androidlevels[2] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void kotlin()
    {
        if (money > androidlevelsprice[3])
        {
            androidlevels[3]++;
            money -= androidlevelsprice[3];
            androidlevelsprice[3] = androidlevelsprice[3] + 150;
            earnedMoney += 1;
        }
        else if (androidlevels[3] == 10)
        {
            androidlevels[3] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void androiddevlevel()
    {
        if (money >androidlevelsprice[4])
        {
            androidlevels[4]++;
            money -= androidlevelsprice[4];
            androidlevelsprice[4] = androidlevelsprice[4] + 300;
            earnedMoney += 2;
        }
        else if (androidlevels[4] == 12)
        {
            androidlevels[4] += 0;
            earnedMoney += 0;
            //max 12 yazacak
        }
    }


    //ios dev geliþtirme
    public void swiftlevel()
    {
        if (money > ioslevels[0])
        {
            ioslevels[0]++;
            money -= ioslevelsprice[0];
            ioslevelsprice[0] = ioslevelsprice[0] + 150;
            earnedMoney += 1;
        }
        else if (ioslevels[0] == 10)
        {
            ioslevels[0] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void iosstorelevel()
    {
        if (money > ioslevels[1])
        {
            ioslevels[1]++;
            money -= ioslevelsprice[1];
            ioslevelsprice[1] = ioslevelsprice[1] + 150;
            earnedMoney += 1;
        }
        else if (gamelevels[1] == 10)
        {
            ioslevels[1] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void GCDlevel()
    {
        if (money > ioslevels[2])
        {
            ioslevels[2]++;
            money -= ioslevelsprice[2];
            ioslevelsprice[2] = ioslevelsprice[2] + 150;
            earnedMoney += 1;
        }
        else if (ioslevelsprice[2] == 10)
        {
            ioslevels[2] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void iossdklevel()
    {
        if (money > ioslevelsprice[3])
        {
            ioslevels[3]++;
            money -= ioslevelsprice[3];
            ioslevelsprice[3] = ioslevelsprice[3] + 150;
            earnedMoney += 1;
        }
        else if (gamelevels[3] == 10)
        {
           ioslevels[3] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void iosdevlevel()
    {
        if (money > gamelevelsprice[4])
        {
            ioslevels[4]++;
            money -= ioslevelsprice[4];
            ioslevelsprice[4] = ioslevelsprice[4] + 300;
            earnedMoney += 2;
        }
        else if (gamelevels[4] == 12)
        {
            ioslevels[4] += 0;
            earnedMoney += 0;
            //max 12 yazacak
        }
    }

    //windows dev geliþtirme
    public void windowscsharp()
    {
        if (money > windowslevels[0])
        {
            windowslevels[0]++;
            money -= windowslevelsprice[0];
            windowslevelsprice[0] = windowslevelsprice[0] + 150;
            earnedMoney += 1;
        }
        else if (windowslevels[0] == 10)
        {
            windowslevels[0] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void windowsAPI()
    {
        if (money > windowslevels[1])
        {
            windowslevels[1]++;
            money -= windowslevelsprice[1];
            windowslevelsprice[1] = windowslevelsprice[1] + 150;
            earnedMoney += 1;
        }
        else if (windowslevels[1] == 10)
        {
            windowslevels[1] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void veritabani()
    {
        if (money > windowslevels[2])
        {
            windowslevels[2]++;
            money -= windowslevelsprice[2];
            windowslevelsprice[3] = windowslevelsprice[2] + 150;
            earnedMoney += 1;
        }
        else if (ioslevelsprice[2] == 10)
        {
            windowslevels[2] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void winUI()
    {
        if (money > ioslevelsprice[3])
        {
            windowslevels[3]++;
            money -= windowslevelsprice[2];
            windowslevelsprice[3] = windowslevelsprice[3] + 150;
            earnedMoney += 1;
        }
        else if (gamelevels[3] == 10)
        {
            windowslevels[3] += 0;
            earnedMoney += 0;
            //max 10 yazacak
        }
    }
    public void windowsdevlevel()
    {
        if (money > gamelevelsprice[4])
        {
            windowslevels[4]++;
            money -= windowslevelsprice[4];
            windowslevelsprice[4] = windowslevelsprice[4] + 300;
            earnedMoney += 2;
        }
        else if (gamelevels[4] == 12)
        {
            windowslevels[4] += 0;
            earnedMoney += 0;
            //max 12 yazacak
        }
    }

    public void boostbuton()
    {
        money += 1;
    }
    IEnumerator inworkplayer()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(1f); 

            counter += 1f;
        }
    }
    private System.Collections.IEnumerator SaniyedeBirArtirCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1 saniye bekleyin

            // Para deðiþkenini 1 artýr
            money++;        
        }
    }
    private System.Collections.IEnumerator WebOpenCoroutine()
    {
        while (webmoney > 0)
        {
            yield return new WaitForSeconds(0.025f); 

            // Para ve webmoney deðiþkenlerini 1 azalt
            money--;
            webmoney--;  
        }

        // Webmoney sýfýr olduðunda coroutine'i durdur
        webMoneyTriggered = false;
    }

    private System.Collections.IEnumerator GameOpenCoroutine()
    {
        while (gamemoney > 0)
        {
            yield return new WaitForSeconds(0.025f); 
            money--;
            gamemoney--;
        }
        gameMoneyTriggered = false;
    }

    private System.Collections.IEnumerator AndroidOpenCoroutine()
    {
        while (androidmoney > 0)
        {
            yield return new WaitForSeconds(0.025f);
            money--;
            androidmoney--;
        }
        androidMoneyTriggered = false;
    }
    private System.Collections.IEnumerator IosOpenCoroutine()
    {
        while (iosmoney > 0)
        {
            yield return new WaitForSeconds(0.025f);
            money--;
            iosmoney--;
        }
        iosMoneyTriggered = false;
    }
    private System.Collections.IEnumerator WindowsOpenCoroutine()
    {
        while (windowsmoney > 0)
        {
            yield return new WaitForSeconds(0.025f);
            money--;
            windowsmoney--;
        }
        windowsMoneyTriggered = false;
    }

    private System.Collections.IEnumerator earnedMoneytoplama()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1 saniye bekleyin
            money+=earnedMoney;
        }
    }
}