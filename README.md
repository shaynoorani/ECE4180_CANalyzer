# CANalyzer - Frugal CAN Line Analyzer with a C# GUI
- Brendan Bassett, Carl Cort, Eric Galluzi, Shayan Noorani, Tiancheng Zhao

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

## Software
### Mbed
! CAN passthrough and initial parser

### C# GUI and Load Analyzer 
?Is the load analyzer in C# or on the Mbed?
! GUI Code (if very long maybe instead call out the key parts and link to the parts of the github with htem)

## Usage
! POPULATE WITH HOW TO USE THE CANalyzer

### Using C# in VS with Github
If you want to add or make changes in Visual Studio for the C# to Github you should 
Follow the following instructions:

The issue can be worked around by deleting “C:\Program Files\Microsoft Visual Studio\2022[Community\Pro\Enterprise]\Common7\IDE\CommonExtensions\Microsoft\Editor\ServiceHub\Indexing.servicehub.service.json” file and restarting Visual Studio.
