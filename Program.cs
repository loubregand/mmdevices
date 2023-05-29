using System;
using NAudio.CoreAudioApi;
using System.Collections.Generic;

class Program
{
	static void Main(string[] argsArray)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.Out.NewLine = "\n";
			
		var args = new List<string>(argsArray);
		var deviceEnumerator = new MMDeviceEnumerator();
		var devices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
		bool ok = false;
		
		// If at least one argument is provided the program will
		// try to match each argument with the FriendlyName of 
		// every device removing the portion in parentheses. If at 
		// least one device match one of the arguments its id is 
		// printed on stdout, else an exist status 1 is returned
		
		if( args.Count > 0 ){
			foreach (var arg in args){
				foreach (var device in devices){
					if(compareInputAndFriendlyName(arg, device.FriendlyName)){
						ok = true;
						Console.WriteLine($"{device.ID}");
						goto stopProcessingArgs;
					}
				}
			}
			
			stopProcessingArgs:
			
			if (! ok){
				System.Environment.Exit(1);
			}
		}
		else{
			foreach (var device in devices){
				Console.WriteLine($"{device.ID},{device.FriendlyName},{device.DataFlow}");
			}
		}
	}
	
	static public bool compareInputAndFriendlyName(string input, string FriendlyName)
	{
		int index = FriendlyName.IndexOf("(");
		
		if(index > 0){
			FriendlyName = FriendlyName.Substring(0, index).Trim();
		}
		
		if(FriendlyName == input){
			return true;
		}
		return false;
	}
}