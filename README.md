# ivao-aipcoord
> A simple C# tool to convert airspace coordinates from eAIP to IVAO IvAc and WebEye, and T2:Radar (IVAC2)

## "I just wanna download and use it"
Although you can simply clone the Git repository and compile the source, I made the downloadable executable available (lots of '*able*'s) separately:
**https://donatus.hu/files/aipcoord.zip**


## What is it?
This tool has been created in a few hours to make my life easier while converting path/shape coordinates from eAIP to IVAC2. Later on I added the feature to support IvAc1 and WebEye formats as output.   
However the source coordinate format has to be eAIP-style WGS84 format, it **might** work with IVAC2 coordinates as source too. Latitude and longitude must be separated by ONE space, and the coordinate pairs must be separated either via newline or dash.   

## Usage
Insert the source data and press one of the three buttons on the top. Leading tabs can be adjusted for IVAC2, leading spaces and color attribute for IvAc1 format. The output will be moved to the clipboard, so you don't have to Ctrl-C the result manually. Basically that's all. :-)   

Example input data which will work:  
`474643N 0190652E - 473720N 0185425E - 473500N 0185300E - 473220N 0185858E - 473055N 0190118E - 473054N 0190159E - 473612N 0190412E - 474615N 0191631E - 474643N 0190652E`

## Epilogue
I don't take any responsibility if this tool screws up your origin or result point list. As I stated it had been created from scratch in a couple of hours and doesn't contain any error correction part. If there's a mistake in the input data either it shoots an error message, or does the conversion well or not well.  

PS: I used this tool for OMAE, LZBB, LHCC, LAAA and LHKR IVAC2 FIRdefinitons and for several WebEye FIR shapes and it worked nicely.

## Support?
Should you have any ideas, questions or bugreports, get in touch with me via email or Discord.