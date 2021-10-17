#include<SevSeg.h>
SevSeg sevSeg;
unsigned int myTemp;
float tempc =0;

char state;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  delay(100);
  byte numDigits = 4;
  byte ccDPins[] = {A0, A1, A2, A3};
  byte segDPins[] = {2,3,4,5,6,7,8,9};
  sevSeg.begin(COMMON_ANODE, numDigits, ccDPins, segDPins, false, false, false, false);
  sevSeg.setBrightness(100);
  analogReference(INTERNAL);
}

void loop() {
   // Lấy thời gian kể từ khi arduino được khởi động
  unsigned long prMillis = millis();
  while( millis() - prMillis < 2000)
  {
     // làm mới màn hình
    sevSeg.refreshDisplay();
  }
  
    if(Serial.available()>0) // kiểm tra nếu có dữ liệu được truyền vào
    {
      state = (char) Serial.read(); // đọc giá trị được truyền vào và gán cho biến state
    }
    
    switch (state) {  // thực thi hàm switch case dựa theo giá trị được truyền vào là 1 và 2
      case '1': // nếu là một
            myTemp = ChuyenDoC(); // lấy giá trị độ C
              // Thiết lập số hiển thị và lấy 2 số thập phân
            sevSeg.setNumber(myTemp, 2, LOW);
        break;
      case '2':  // nếu là 2
            myTemp = ChuyenDoF(); // lấy giá trị độ F
              // Thiết lập số hiển thị và lấy 2 số thập phân
            sevSeg.setNumber(myTemp, 2, LOW);
        break;
    }
    
}

unsigned int ChuyenDoC()
{
  float temp = (float) 100*(1.1/1023)*analogRead(A4);
   
  Serial.println(temp);
  // In temp (nhiệt độ) lên màn hình và lấy 2 số thập phân
  temp = 100*temp;
  return ((unsigned int)temp);
}

unsigned int ChuyenDoF()
{
  float temp = (float) 100*(1.1/1023)*analogRead(A4);
  temp = temp*9/5 + 32; // chuyển đổi qua độ F
  Serial.println(temp);
    // In temp (nhiệt độ) lên màn hình và lấy 2 số thập phân
  temp = 100*temp;
  return ((unsigned int)temp);
}
