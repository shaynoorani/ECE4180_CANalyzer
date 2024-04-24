#include "mbed.h"
#define FREQ 500000

Serial      pc(USBTX, USBRX);
DigitalOut led1(LED1);
DigitalOut led2(LED2);
CAN         can(p30, p29);
CANMessage  msg;
Ticker can_load_tick;



class CAN_load_calculator{
private:
    bool calculating;
    Timer t;
    int t_prev;
    int t_now;

public:
    volatile int can_load;
    volatile int can_bits_counter;
    CAN_load_calculator(){
        calculating = false;
        t.stop();
        t_prev = 0;
        t_now = 0;
        can_load = 0;
        can_bits_counter = 0;
    }

    void send(){
        // pc.printf("tprev: %d\r\n", t_prev);
        // pc.printf("tnow: %d\r\n", t_now);
        pc.printf("The can load is: %0.2d %%\n ", can_load); // send over serial
        pc.printf("\r\n");
        reset_can_bits_counter();
    }

    void increment_can_bits_counter(int x){
        can_bits_counter += x;
    }

    void reset_can_bits_counter(){
        can_bits_counter = 0;
    }

    

};

CAN_load_calculator can_calc;  
void can_load_send() {
    can_calc.can_load =(int) 100 * ((double)can_calc.can_bits_counter / (5000.0));
}

int main()
{
    can.monitor(1);
    can.frequency(FREQ);
    

    int can_msg_counter = 0;
    pc.baud(115200);
    can_load_tick.attach(&can_load_send, .01); // send and measure can load every 0.5 second
    while(1) {
        // pc.printf("trying\n");
        if(can.read(msg)) {
            led1 = 1;
            if (msg.len){
                can_calc.increment_can_bits_counter(470);

                //print CAN msg to serial port if can_calc is not processing
                
                  pc.printf("%.3x!", msg.id);
                  for (int i = 7; i >= 0; i--) {
                    pc.printf("%.2x", msg.data[i]);
                  }
                  pc.printf("\r\n");
                

            }
            
        }
        
        led1 = 0;
        can_msg_counter++;

        if((can_msg_counter >= 100)){
           
            can_calc.send();
        }
        
    
        
    }
}