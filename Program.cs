using System;
using NAudio.CoreAudioApi;

class Program
{
    static void Main(string[] args)
    {
        var deviceEnumerator = new MMDeviceEnumerator();
        var devices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
        
        foreach (var device in devices)
        {
            Console.WriteLine($"{device.ID},{device.FriendlyName},{device.DataFlow}");
        }
    }
}