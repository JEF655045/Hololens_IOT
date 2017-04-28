using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ArticleController : MonoBehaviour
{
    private int buttonValue;
    private string buttonValString;
    private string particleURI;
    private string particleURI_Active;
    private int buttonState = 0;
    private int buttonStateOld = 0;

    public Text articleText_1;
    public Text articleText_2;
    public Text articleText_3;
    public Text articleText_4;


    // Create a function that could run with update() parallel
    IEnumerator GetButtonValue()
    {
        while (true)
        {
            // Assign your URI here
            particleURI = "https://api.particle.io/v1/devices/310024001447333438373338/font?access_token=553b543dae956f438796d84a9bf58d43c569925f";
            // Create a GET web request
            UnityWebRequest buttonStateRequest = UnityWebRequest.Get(particleURI);
            // Wait until the data has been received
            yield return buttonStateRequest.Send();
            // Make sure you have JSON Object plugin imported
            JSONObject buttonData = new JSONObject(buttonStateRequest.downloadHandler.text);
            // Open the URI link and you can see the value you want is stored in "result", grab this data and store
            buttonData = buttonData["result"];
            Debug.Log(buttonData);
            // Convert the JSON object to a string and then to a integer
            buttonValString = buttonData.ToString();
            buttonValue = int.Parse(buttonValString);
            // delay one second
            yield return new WaitForSeconds(1);
        }
    }
    void Start()
    {
        //Get ButtonValue() should be run with Update() in paralle
        StartCoroutine(GetButtonValue());
    }

    // Update is called once per frame, handle the data received from Particle here
    void Update()
    {

        // Assign the buttonValue from internet to a local variable
        buttonState = buttonValue;
        
        // Check whether buttonState is changed or not, if yes, check the value
        if (buttonState != buttonStateOld)
        {
            // 000 means not BOLD, not Italic, not Condensed
            // 100 means BOLD, not Italic, not Condensed
            // 110 means BOLD, Italic, not Condensed
            // 101 means BOLD, not Italic, Condensed
            // 111 means BOLD, Italic, Condensed
            // 001 means not BOLD, not Italic, Condensed
            // 010 means not BOLD, Italic, not Condensed
            // 011 means not BOLD, Italic, Condensed
            if (buttonState.Equals(0))
            {
                articleText_1.font = (Font)Resources.Load("HelveticaNeueLTPro-Lt");
                articleText_2.font = (Font)Resources.Load("HelveticaNeueLTPro-Lt");
                articleText_3.font = (Font)Resources.Load("HelveticaNeueLTPro-Lt");
                articleText_4.font = (Font)Resources.Load("HelveticaNeueLTPro-Lt");
                Debug.Log("Lt");
            }
            
            if (buttonState.Equals(100))
            {
                articleText_1.font = (Font)Resources.Load("HelveticaNeueLTPro-Md");
                articleText_2.font = (Font)Resources.Load("HelveticaNeueLTPro-Md");
                articleText_3.font = (Font)Resources.Load("HelveticaNeueLTPro-Md");
                articleText_4.font = (Font)Resources.Load("HelveticaNeueLTPro-Md");
                Debug.Log("Md");
            }
            if (buttonState.Equals(110))
            {
                articleText_1.font = (Font)Resources.Load("HelveticaNeueLTPro-MdIt");
                articleText_2.font = (Font)Resources.Load("HelveticaNeueLTPro-MdIt");
                articleText_3.font = (Font)Resources.Load("HelveticaNeueLTPro-MdIt");
                articleText_4.font = (Font)Resources.Load("HelveticaNeueLTPro-MdIt");
                Debug.Log("MdIt");
            }
            if (buttonState.Equals(101))
            {
                articleText_1.font = (Font)Resources.Load("HelveticaNeueLTPro-MdCn");
                articleText_2.font = (Font)Resources.Load("HelveticaNeueLTPro-MdCn");
                articleText_3.font = (Font)Resources.Load("HelveticaNeueLTPro-MdCn");
                articleText_4.font = (Font)Resources.Load("HelveticaNeueLTPro-MdCn");
                Debug.Log("MdCn");
            }
            if (buttonState.Equals(111))
            {
                articleText_1.font = (Font)Resources.Load("HelveticaNeueLTPro-MdCnO");
                articleText_2.font = (Font)Resources.Load("HelveticaNeueLTPro-MdCnO");
                articleText_3.font = (Font)Resources.Load("HelveticaNeueLTPro-MdCnO");
                articleText_4.font = (Font)Resources.Load("HelveticaNeueLTPro-MdCnO");
                Debug.Log("MdCnO");
            }
            if (buttonState.Equals(1))
            {
                articleText_1.font = (Font)Resources.Load("HelveticaNeueLTPro-LtCn");
                articleText_2.font = (Font)Resources.Load("HelveticaNeueLTPro-LtCn");
                articleText_3.font = (Font)Resources.Load("HelveticaNeueLTPro-LtCn");
                articleText_4.font = (Font)Resources.Load("HelveticaNeueLTPro-LtCn");
                Debug.Log("LtCn");
            }
            if (buttonState.Equals(10))
            {
                articleText_1.font = (Font)Resources.Load("HelveticaNeueLTPro-LtIt");
                articleText_2.font = (Font)Resources.Load("HelveticaNeueLTPro-LtIt");
                articleText_3.font = (Font)Resources.Load("HelveticaNeueLTPro-LtIt");
                articleText_4.font = (Font)Resources.Load("HelveticaNeueLTPro-LtIt");
                Debug.Log("LtIt");
            }
            if (buttonState.Equals(11))
            {
                articleText_1.font = (Font)Resources.Load("HelveticaNeueLTPro-LtCnO");
                articleText_2.font = (Font)Resources.Load("HelveticaNeueLTPro-LtCnO");
                articleText_3.font = (Font)Resources.Load("HelveticaNeueLTPro-LtCnO");
                articleText_4.font = (Font)Resources.Load("HelveticaNeueLTPro-LtCnO");
                Debug.Log("LtCnO");
            }

            //Assign current buttonState to buttonStateOld for future comparison
            buttonStateOld = buttonState;
            //Debug.Log("Value Change");
        }
    }
}
