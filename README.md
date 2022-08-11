# GPMLink
 GW-Instek Power Meter Logging Utility

 GW-Instek GPM8310 AC/DC Power Meter data logger utility.

This project includes a .NET Winforms and a WPF application (and .NETCore work in progress) to perform long measurements and data logging sessions with the above power meter device.

## The Power Meter

GW Instek GPM-8310 is a digital power meter for single-phase (1P/2W) AC power measurement. Features include DC, 0.1Hz~100kHz test bandwidth, 16bits A/D, and 300 kHz sampling rate. It adopts 5” TFT LCD screen with a five-digit measurement display and provides 25 power measurement related parameters, and has a high-precision measurement capability. It also features the ability to display waveform (voltage/current/power), the integration measurement function, harmonic measurement and analysis of each order, external sensor input terminals, and various communication interfaces, etc., to help users achieve clear, convenient and accurate power measurements. This power meter is a most cost-effective power meter with most complete functionalities among the products of the same category.

[Product Page](https://www.gwinstek.com/en-global/products/detail/GPM-8310)

[Specifications](https://www.gwinstek.com/en-global/products/downloadSeriesSpec/2114)

## Connection and speed

The GPM-8310 has RS232C, USB port, Ethernet and GBIP ports. This program relies on its Ethernet port and implements a simple Telnet class to pull data out of it using timed requests to which the device answers with data reponses.

Speed should not be a problem: the device itself samples and computes data at high rates, while the final data (voltage, current, and all other signal characteristics) can be queried as "fast" as twice a second (2 Hz) reliably event though slower speed (and less data point) show good results for the scope of this project.

