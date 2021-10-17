#include<SevSeg.h>
SevSeg sevSeg;
unsigned int myTemp;

void setup() {
  Serial.begin(9600);
  Serial.println("==================");
  Serial.println("Welcome to Nhom 3");
  Serial.println("==================");
  byte numDigits = 4;
  byte ccDPins[] = {A0, A1, A2, A3};
  byte segDPins[] = {2,3,4,5,6,7,8,9};

  //(hardwareConfig,numDigitsIn,digitPinsIn[], segmentPinsIn[],
  //resOnSegmentsIn,updateWithDelaysIn,leadingZerosIn, disableDecPoint)
  sevSeg.begin(COMMON_ANODE, numDigits, ccDPins, segDPins, false, false, false, false);
  // Thiết lập độ sáng
  sevSeg.setBrightness(100); 
}

void loop() {
  // Lấy thời gian kể từ khi arduino được khởi động
  unsigned long prMillis = millis();
  while( millis() - prMillis < 2000)
  {
    // làm mới màn hình
    sevSeg.refreshDisplay();
  }
  myTemp = ChuyenDoC();
  // Thiết lập số hiển thị và lấy 2 số thập phân
  sevSeg.setNumber(myTemp, 2, LOW); 
}

unsigned int ChuyenDoC()
{
  float temp = (float) 100*(5.0/1024)*analogRead(A4);
  
  Serial.print("Nhiet do trong phong la: ");
  // In temp (nhiệt độ) lên màn hình và lấy 2 số thập phân
  Serial.print(temp, 2);
  Serial.print(char(223));
  Serial.println("C");
  temp = 100*temp;
  return ((unsigned int)temp);
}
