
//// Pin Setting
// D2 to D4 is used to control fontstyle
int boldPin = D4;
int italicPin = D3;
int condensedPin = D2;

// D5 is used to control game initial
int activePin = D5;

// Variable to be sent to internet
int fontStyleSend = 0;
int activeSend = 0;

// flag to determine trigger
int boldFlag = 0;
int italicFlag = 0;
int condensedFlag = 0;
int activeFlag = 0;

void setup()
{

  // Particle.varible is used to send data to the internet
  Particle.variable("font", fontStyleSend);
  Particle.variable("active", activeSend);

  // Use INPUT_PULLUP to avoid using extra pullup resistor
  pinMode (activePin, INPUT_PULLUP);
  pinMode( boldPin, INPUT_PULLUP);
  pinMode( italicPin, INPUT_PULLUP);
  pinMode( condensedPin, INPUT_PULLUP);

  // Serial output for debugging
  Serial.begin(9600);

}

void loop()
{
  // Read trigger status
   int activeState = digitalRead( activePin);
   int boldState = digitalRead( boldPin );
   int italicState = digitalRead( italicPin );
   int condensedState = digitalRead( condensedPin );

   // for game starter, the connected wire mean game start
    if (activeState == LOW){
      activeFlag = 1;
    }

    // for bold control, the diconnected wire is default which in this case means not bold
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

    // there are 8 status for bold control
    // 000, 001, 010, 100, 011, 101, 110, 111
    // the first digi is BOLD(1) or not BOLD(0)
    // the second digi is Italic(1) or not Italic(0)
    // the third digi is condensed(1) or not Condensed(0)
    fontStyleSend = boldFlag * 100 + italicFlag *10 + condensedFlag;

    delay(500);
}
