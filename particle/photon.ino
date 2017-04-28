
// We will be using D1 to control our LED
int ledPin = D1;
// Our button wired to D0
int buttonPin = D0;


int boldPin = D4;
int italicPin = D3;
int condensedPin = D2;
int activePin = D5;

int buttonSend= 0;
int fontStyleSend = 0;
int activeSend = 0;

int boldFlag = 0;
int italicFlag = 0;
int condensedFlag = 0;
int activeFlag = 0;

void setup()
{

  // For input, we define the
  // pushbutton as an input-pullup
  // this uses an internal pullup resistor
  // to manage consistent reads from the device

  //Particle.variable("LED", buttonSend);
  Particle.variable("font", fontStyleSend);
  Particle.variable("active", activeSend);

  pinMode( buttonPin, INPUT_PULLUP); // sets pin as input

  pinMode (activePin, INPUT_PULLUP); // sets pin as input
  pinMode( boldPin, INPUT_PULLUP); // sets pin as input
  pinMode( italicPin, INPUT_PULLUP); // sets pin as input
  pinMode( condensedPin, INPUT_PULLUP); // sets pin as input

  // We also want to use the LED

  pinMode( ledPin , OUTPUT ); // sets pin as output
  Serial.begin(9600);

}

void loop()
{
   // find out if the button is pushed
   // or not by reading from it.
   int buttonState = digitalRead( buttonPin );

   int boldState = digitalRead( boldPin );
   int italicState = digitalRead( italicPin );
   int condensedState = digitalRead( condensedPin );

   int activeState = digitalRead( activePin);

  // remember that we have wired the pushbutton to
  // ground and are using a pulldown resistor
  // that means, when the button is pushed,
  // we will get a LOW signal
  // when the button is not pushed we'll get a HIGH

  // let's use that to set our LED on or off

// LOW means wire is connected
  /*if( buttonState == LOW )
  {
    // turn the LED On
    digitalWrite( ledPin, HIGH);
    Serial.println("HIGH");
    buttonSend = 2;
    Particle.publish("LED", buttonSend);
    delay(500);
  }else{
    // otherwise
    // turn the LED Off
    digitalWrite( ledPin, LOW);
    Serial.println("LOW");
    buttonSend = 1;
    Particle.publish("LED", buttonSend);
    delay(500);

  }*/

    if (activeState == LOW){
      activeFlag = 1;
    }

    if (boldState == HIGH){
      boldFlag = 1;
    }
    else if (boldState == LOW){
      boldFlag = 0;
    }
    if (italicState == HIGH){
      italicFlag = 1;
    }
    else if (italicState == LOW){
      italicFlag = 0;
    }
    if (condensedState == HIGH){
      condensedFlag = 1;
    }
    else if (condensedState == LOW){
      condensedFlag = 0;
    }

    fontStyleSend = boldFlag * 100 + italicFlag *10 + condensedFlag;
    Serial.println("Active: " + activeFlag);
    Serial.println("Style: " + fontStyleSend);
    //Particle.publish("FONT", fontStyleSend);
    delay(500);
}
