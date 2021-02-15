/*
 * Atmospheric CO Level..............400ppm
 * Average indoor co.............350-450ppm
 * Maxiumum acceptable co...........1000ppm
 * Dangerous co levels.............>2000ppm
 * to convert ppm to % -----> ppm / 10000
 */



#include <LiquidCrystal.h>      //Header file for LCD


const int rs = 13, en = 12, d4 = 11, d5 = 10, d6 = 9, d7 = 8;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

int buz = 5;  //buzzer connected to pin 5
int led = 6;  //led connected to pin 6

const int MQ5sensor = A0;  //output of mq5 connected to A0 pin of Arduino
const int MQ135sensor = A1;  //output of mq135 connected to A1 pin of Arduino
word ppm1,ppm2;
void setup() {

 
  pinMode (led,OUTPUT);     // led is connected as output from Arduino
  Serial.begin (9600);      //begin serial communication with baud rate of 9600
  lcd.clear();              // clear lcd
    // set up the LCD's number of columns and rows:
  pinMode(6,OUTPUT);
  lcd.begin (16,2);         // consider 16,2 lcd
  
}

void loop() {


  ppm1 = analogRead(MQ5sensor); //read MQ5 analog outputs at a0 and store it in ppm
  ppm2 = analogRead(MQ135sensor);

  Serial.print("Air Quality: ");  //print message in serail monitor
  Serial.println(ppm2);            //print value of ppm in serial monitor
  Serial.print("Gas Saturat: ");  //print message in serail monitor
  Serial.println(ppm1);            //print value of ppm in serial monitor

  lcd.setCursor(0,0);             // set cursor of lcd to 0st row and 0st column
  lcd.print("Air Quality: ");      // print message on lcd0
  lcd.print(ppm2);                 // print value of MQ135
  lcd.setCursor(0,1);
  lcd.print("Gas Saturat: ");      // print message on lcd0
  lcd.print(ppm1);                 // print value of MQ5

  if (ppm1 > 2000)            // check is ppm is greater than threshold or not
    {

      lcd.setCursor(1,1);         //jump here if ppm is greater than threshold
      lcd.print("AQ Level HIGH");
      tone(led,1000,200);         //blink led with turn on time 1000mS, turn off time 200mS
      digitalWrite(buz,HIGH);     //Turn ON Buzzer
     
    }
  else
    {
      digitalWrite(led,LOW);   //jump here if ppm is not greater than threshold and turn off LED
      digitalWrite(buz,LOW);   //Turn off Buzzer
      lcd.setCursor(1,1);
      lcd.print ("AQ Level Good");
    }  
    
  delay (500);
}
