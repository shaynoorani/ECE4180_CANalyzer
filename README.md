# CANalyzer - Frugal CAN Line Analyzer with a C# GUI
- Brendan Bassett, Carl Cort, Eric Galluzi, Shayan Noorani, Tiancheng Zhao
- Throughout this page, there are links to the section of the main github repo [shaynoorani/ECE4180_CANalyzer](https://github.com/shaynoorani/ECE4180_CANalyzer/tree/main) that correspond to the given component. Navigate to those to see the exact implementations

## Description
- CAN Line Analyzer for easy access to CAN data
- Simple C#-based GUI
   - ! ?Can filter based on CAN message ID? - Did we implement this?
- Calculates and displays CAN Load

## Functionality Demo

## Hardware Setup
### Parts
- (x1) [Mbed](https://www.nxp.com/products/processors-and-microcontrollers/arm-microcontrollers/general-purpose-mcus/lpc1700-arm-cortex-m3/arm-mbed-lpc1768-board:OM11043)
- (x1) [CAN Transducer](https://www.trustedparts.com/en/part/texas-instruments/TCAN1051HDRQ1?gad_source=1&gclid=Cj0KCQjwlZixBhCoARIsAIC745BS6Yo-jjP46UWuMqcR6n9Xm2Zw-S1keO-JjT2n29nrR9FZASSHz-4aAnRbEALw_wcB)
- (x1) [SOP14 SMD-to-DIP Breakout](https://pmdway.com/products/sop14-tssop14-to-dip-adaptor-pcbs-10-pack)
  - Simply used as a breakout for the CAN Transducer for use on a breadboard
- [Breadboard](https://www.digikey.com/en/products/detail/universal-solder-electronics-ltd/SOLDERLESS%2520BREADBOARD%2520400/16819785?utm_adgroup=&utm_source=google&utm_medium=cpc&utm_campaign=PMax_DK%2BProduct_Product%20Categories%20-%20Top%2015&utm_term=&utm_content=&utm_id=go_cmp-19646629144_adg-_ad-__dev-c_ext-_prd-16819785_sig-Cj0KCQjwlZixBhCoARIsAIC745Dwae0ZVhIv94k09Ht68xdOZ6aSgnMd-k5QA9iUPgV3ZDevFuUz87YaAqLCEALw_wcB&gad_source=1&gclid=Cj0KCQjwlZixBhCoARIsAIC745Dwae0ZVhIv94k09Ht68xdOZ6aSgnMd-k5QA9iUPgV3ZDevFuUz87YaAqLCEALw_wcB)
- Housing (optional)

### Wiring Diagram
! Brendan's Wiring Diagram

### [Housing](https://github.com/shaynoorani/ECE4180_CANalyzer/tree/main/Housing) (Optional)
- The housing was developed to make the device more rugged for practical use but is not required for functionality
- As such, this section is presented to show not only our final design but also the measurements of the underlying device so that a different housing ould be developed if desired

#### Embedded Device Dimensions


[<img alt="Dimensions of relavent parts of the embedded device for designing the housing." width="40px" src="CANAlyzer Dimensions and Initial Housing Design.png">](https://github.com/shaynoorani/ECE4180_CANalyzer/blob/main/Housing)

## Software
- The Software is broken up into three key units: the Mbed-based CAN load calculator and CAN message passthrough, the C#-based DBC Message parser, and the C# GUI.
- The messages are first read across a serial connection from the CAN transducer to the mbed where they are either tallied to calculate CAN load or passed-through the USB virtual COM port to the computer for use in the DBC Parser and Gui
- The DBC parser reads the CAN messages sent by the mbed and packages them in structs that delineate the messages and segments the data into the message components
- Finally, the GUI displays the CAN message in an easily read format and allows for filtering of messages based on ID  

### Mbed - CAN Load Calculator & Message Passthrough
! Andy's Code - highlight sections of code if necessary/beneficial, describe functionality, and especially mention how it avoids losing parts of CAN messages through calculation and sending cycles.

### [DBC Parser](https://github.com/shaynoorani/ECE4180_CANalyzer/tree/main/DBCParserTest)
! Eric's Parser (probably just highlight functionality and then link to the code if it is long)

### [GUI](https://github.com/shaynoorani/ECE4180_CANalyzer/tree/main/WindowsAppCanalyzer)
! Shay's GUI Code (probably just highlight functionality and then link to the code if it is long)

## Usage
! POPULATE WITH HOW TO USE THE CANalyzer

### Using C# in VS with Github
If you want to add or make changes in Visual Studio for the C# to Github you should 
Follow the following instructions:

The issue can be worked around by deleting “C:\Program Files\Microsoft Visual Studio\2022[Community\Pro\Enterprise]\Common7\IDE\CommonExtensions\Microsoft\Editor\ServiceHub\Indexing.servicehub.service.json” file and restarting Visual Studio.
