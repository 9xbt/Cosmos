﻿using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL.Drivers.PCI.Network;

namespace Cosmos.HAL.Network
{
    public class NetworkInit
    {
        public static void Init()
        {
            int NetworkDeviceID = 0;

            Console.WriteLine("Searching for Ethernet Controllers...");

            foreach (PCIDevice device in PCI.Devices)
            {
                if ((device.ClassCode == 0x02) && (device.Subclass == 0x00) && // is Ethernet Controller
                    device == PCI.GetDevice(device.bus, device.slot, device.function))
                {

                    Console.WriteLine("Found " + PCIDevice.DeviceClass.GetDeviceString(device) + " on PCI " + device.bus + ":" + device.slot + ":" + device.function);

                    #region PCNETII

                    if (device.VendorID == (ushort)VendorID.AMD && device.DeviceID == (ushort)DeviceID.PCNETII)
                    {

                        Console.WriteLine("NIC IRQ: " + device.InterruptLine);

                        var AMDPCNetIIDevice = new AMDPCNetII(device);

                        AMDPCNetIIDevice.NameID = ("eth" + NetworkDeviceID);

                        Console.WriteLine("Registered at " + AMDPCNetIIDevice.NameID + " (" + AMDPCNetIIDevice.MACAddress.ToString() + ")");

                        AMDPCNetIIDevice.Enable();

                        NetworkDeviceID++;
                    }

                    #endregion

                    #region RTL8168

                    if (device.VendorID == 0x10EC && device.DeviceID == 0x8168)
                    {

                        Console.WriteLine("NIC IRQ: " + device.InterruptLine);

                        var RTL8168Device = new RTL8168(device);

                        RTL8168Device.NameID = ("eth" + NetworkDeviceID);

                        Console.WriteLine("Registered at " + RTL8168Device.NameID + " (" + RTL8168Device.MACAddress.ToString() + ")");

                        RTL8168Device.Enable();

                        NetworkDeviceID++;
                    }

                    #endregion

                }
            }

            if (NetworkDevice.Devices.Count == 0)
            {
                Console.WriteLine("No supported network card found!!");
            }
            else
            {
                Console.WriteLine("Network initialization done!");
            }
        }
    }
}
