#include<SevSeg.h>
SevSeg sevSeg;
unsigned int myTemp;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  byte numDigits = 4;
  byte ccDPins[] = {A0, A1, A2, A3};
  byte segDPins[] = {2,3,4,5,6,7,8,9};

  sevSeg.begin(COMMON_ANODE, numDigits, ccDPins, segDPins, false, false, false, false);
  sevSeg.setBrightness(100);
  analogReference(INTERNAL);
}

void loop() {
  // put your main code here, to run repeatedly:
  unsigned long prMillis = millis();
  while( millis() - prMillis < 2000)
  {
    sevSeg.refreshDisplay();
  }
  myTemp = acqTemp();
  sevSeg.setNumber(myTemp, 2, LOW);
}

unsigned int acqTemp()
{
  float temp = (float) 100*(1.1/1023)*analogRead(A4);
  Serial.println("Room temperature is - ");
  Serial.print(temp, 2);
  Serial.println(" deg C");
  temp = 100*temp;
  return ((unsigned int)temp);
}
