# CANalyzer - Frugal CAN Line Analyzer with a C# GUI
- Brendan Bassett, Carl Cort, Eric Galluzi, Shayan Noorani, Tiancheng Zhao
- Throughout this page, there are links to the section of the main github repo [shaynoorani/ECE4180_CANalyzer](https://github.com/shaynoorani/ECE4180_CANalyzer/tree/main) that correspond to the given component. Navigate to those to see the exact implementations

<img width="400" alt="Team Picture" src="https://github.com/shaynoorani/ECE4180_CANalyzer/assets/124218592/7faa5a21-4a88-4b69-bc6e-8f2c1a3e5df8">


## Description
- CAN Line Analyzer for easy access to CAN data
- Simple C#-based GUI
   - Can filter based on CAN message ID
- Calculates and displays CAN Load

## Functionality Demo
[<img width="500" alt="Team Picture" src="https://github.com/shaynoorani/ECE4180_CANalyzer/assets/124218592/6230bc35-f6be-4f16-86ee-17178f3d6d57">](https://youtu.be/kEs1tA9cYeo?si=FgBFabkiXCYflOZx)

## Hardware
### Parts
- (x1) [Mbed](https://www.nxp.com/products/processors-and-microcontrollers/arm-microcontrollers/general-purpose-mcus/lpc1700-arm-cortex-m3/arm-mbed-lpc1768-board:OM11043)
- (x1) [CAN Transducer](https://www.trustedparts.com/en/part/texas-instruments/TCAN1051HDRQ1?gad_source=1&gclid=Cj0KCQjwlZixBhCoARIsAIC745BS6Yo-jjP46UWuMqcR6n9Xm2Zw-S1keO-JjT2n29nrR9FZASSHz-4aAnRbEALw_wcB)
- (x1) [SOP14 SMD-to-DIP Breakout](https://pmdway.com/products/sop14-tssop14-to-dip-adaptor-pcbs-10-pack)
  - Simply used as a breakout for the CAN Transducer for use on a breadboard
- [Breadboard](https://www.digikey.com/en/products/detail/universal-solder-electronics-ltd/SOLDERLESS%2520BREADBOARD%2520400/16819785?utm_adgroup=&utm_source=google&utm_medium=cpc&utm_campaign=PMax_DK%2BProduct_Product%20Categories%20-%20Top%2015&utm_term=&utm_content=&utm_id=go_cmp-19646629144_adg-_ad-__dev-c_ext-_prd-16819785_sig-Cj0KCQjwlZixBhCoARIsAIC745Dwae0ZVhIv94k09Ht68xdOZ6aSgnMd-k5QA9iUPgV3ZDevFuUz87YaAqLCEALw_wcB&gad_source=1&gclid=Cj0KCQjwlZixBhCoARIsAIC745Dwae0ZVhIv94k09Ht68xdOZ6aSgnMd-k5QA9iUPgV3ZDevFuUz87YaAqLCEALw_wcB)
- Housing (optional)
- Male Molex Connector (optional)

### [Electronics](https://github.com/shaynoorani/ECE4180_CANalyzer/tree/main/schematic)

#### Wiring Diagram
<img width="630" alt="Wiring Diagram" src="https://github.com/shaynoorani/ECE4180_CANalyzer/assets/124218592/b021f11a-1659-4db7-b5f6-4b5727ba3e97">

Note: the TCAN105 is the SMD CAN transducer itself and the wiring shown is for that device however the wires directly from the mbed go through the SOP14 breakout. The maping for the TCAN105 pins to the SOP14 pins are TCAN105(1-4) -> SOP14(1-4) and TCAN105(5-8) -> SOP14(11-14). This can be seen in the realworld image below.

#### Closeup of the Electronics
<img alt="Closeup of the final electronics" width="400px" src="https://github.com/shaynoorani/ECE4180_CANalyzer/assets/124218592/d91efa1b-e216-4a97-999b-a9c67850fe88">


### [Housing](https://github.com/shaynoorani/ECE4180_CANalyzer/tree/main/Housing) (Optional)
- The housing was developed to make the device more rugged for practical use but is not required for functionality
- As such, this section is presented to show not only our final design but also the measurements of the underlying device so that a different housing ould be developed if desired

#### Embedded Device Dimensions
<img alt="Dimensions of relavent parts of the embedded device for designing the housing" width="750px" src="https://github.com/shaynoorani/ECE4180_CANalyzer/blob/main/Housing/CANAlyzer%20Dimensions%20and%20Initial%20Housing%20Design.png?raw=true">

*The CAN lines no longer come out as 3 lines but as one bundled wire that are terminated with a male molex connector since our car's CAN was accessible via a female molex

#### Final Housing Design
<img alt="" width="650px" src="https://github.com/shaynoorani/ECE4180_CANalyzer/blob/main/Housing/Yellow%20CANalyzer%20Housing.png?raw=true">
<img alt="" width="650px" src="https://github.com/shaynoorani/ECE4180_CANalyzer/blob/main/Housing/Yellow%20CANalyzer%20Housing%20Front%20Removed.png?raw=true">
<img alt="" width="650px" src="https://github.com/shaynoorani/ECE4180_CANalyzer/assets/124218592/9cb02d9d-4a11-4481-a3b3-0134888d4d83">

- Two 3D printed components (PLA on the Bambu printers at the HIVE)
- Front plate
  - Openning with ample clearance for varying size mini USB cables
- Main housing Body
  - Window for onboard Mbed indicator LEDs
  - Openning for Mbed reset button
  - Openning on back side for CAN lines
- Connected by M4 screws with a locking not pressure fit into the main housing side
  - Sturdy but also allows for replacement of Mbed or other components

## Software
- The Software is broken up into two key units: the Mbed-based CAN load calculator with CAN message passthrough and the C#-based DBC Message parser with the C# GUI.
- The messages are first read across a serial connection from the CAN transducer to the mbed where they are either tallied to calculate CAN load or passed-through the USB virtual COM port to the computer for use in the DBC Parser and Gui
- The DBC parser reads the CAN messages sent by the mbed and packages them in structs that delineate the messages and segments the data into the message components
- Finally, the GUI displays the CAN message in an easily read format

### [Mbed - CAN Load Calculator & Message Passthrough]
(https://github.com/shaynoorani/ECE4180_CANalyzer/tree/main/main.cpp)
! Andy's Code - highlight sections of code if necessary/beneficial, describe functionality, and especially mention how it avoids losing parts of CAN messages through calculation and sending cycles.

### [GUI](https://github.com/shaynoorani/ECE4180_CANalyzer/tree/main/WindowsAppCanalyzer)
! Shay's GUI Code (probably just highlight functionality and then link to the code if it is long)

## Usage
- Select COM Port
- Select Baud Rate
- Select DBC
- (Optional) Select ID Filter
- Connect/Run and Stop when necessary
![image](https://github.com/shaynoorani/ECE4180_CANalyzer/assets/92798736/afa03a9c-7c5d-4ef2-ae30-ab9c8ad74eee)


### Using C# in VS with Github
Link to the page on github pages: https://shaynoorani.github.io/ECE4180_CANalyzer/
