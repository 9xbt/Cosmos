﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Cosmos.Build.Common;
using Cosmos.Debug.Common;

namespace Cosmos.Debug.Hosts
{
  public partial class Bochs
  {
    private Dictionary<string, string> defaultConfigs = new Dictionary<string, string>();

    private readonly string mHarddiskFile;

    private void InitializeKeyValues()
    {
      string debugGui = startDebugGui ? ", options=\"gui_debug\"" : string.Empty;
      string BochsDirectory = Path.GetDirectoryName(BochsSupport.BochsExe.FullName);
      string default_configuration = "# configuration file generated by Bochs\n"
                                     + "plugin_ctrl: unmapped=1, biosdev=1, speaker=1, extfpuirq=1, parallel=1, serial=1, gameport=1\n"
                                     + "config_interface: win32config\n" + "display_library: win32" + debugGui + "\n"
                                     + "debug_symbols: file=\"%DEBUGSYMBOLSPATH%\"\n"
                                     + "memory: host=1024, guest=1024\n" + "romimage: file=\"" + BochsDirectory
                                     + "/BIOS-bochs-latest\"\n" + "vgaromimage: file=\"" + BochsDirectory
                                     + "/VGABIOS-lgpl-latest\"\n" + "boot: cdrom\n"
                                     + "floppy_bootsig_check: disabled=0\n" + "# no floppya\n" + "# no floppyb\n"
                                     + "ata0-master: type=cdrom, path=\"%CDROMBOOTPATH%\", status=inserted, model=\"Generic 1234\", biosdetect=auto\n"
                                     + "ata0: enabled=1, ioaddr1=0x1f0, ioaddr2=0x3f0, irq=14\n"
                                     + "ata0-slave: type=none\n"
                                     + "ata1: enabled=1, ioaddr1=0x170, ioaddr2=0x370, irq=15\n"
                                     + "ata1-master: type=disk, path=\"%HARDDISKPATH%\", mode=vmware4, cylinders=0, heads=0, spt=0, model=\"Generic 1234\", biosdetect=auto, translation=auto\n"
                                     + "ata2: enabled=0\n" + "ata3: enabled=0\n" + "pci: enabled=1, chipset=i440fx\n"
                                     + "vga: extension=vbe, update_freq=20, realtime=1\n"
                                     //+ "cpu: count=1, ips=4000000, model=bx_generic, reset_on_triple_fault=1, cpuid_limit_winnt=0, ignore_bad_msrs=1, mwait_is_nop=0\n"
                                     + "cpu: count=1, ips=40000000, model=p4_prescott_celeron_336, reset_on_triple_fault=1, cpuid_limit_winnt=0, ignore_bad_msrs=1, mwait_is_nop=0\n"
                                     + "print_timestamps: enabled=0\n" + "port_e9_hack: enabled=0\n"
                                     + "private_colormap: enabled=0\n" + "clock: sync=none, time0=local, rtc_sync=0\n"
                                     + "# no cmosimage\n" + "# no loader\n" + "log: -\n" + "logprefix: %t%e%d\n"
                                     + "debug: action=ignore\n" + "info: action=report\n" + "error: action=report\n"
                                     + "panic: action=ask\n"
                                     + "keyboard: type=mf, serial_delay=250, paste_delay=100000, user_shortcut=none\n"
                                     + "mouse: type=imps2, enabled=0, toggle=ctrl+mbutton\n"
                                     + "sound: waveoutdrv=win, waveout=none, waveindrv=win, wavein=none, midioutdrv=win, midiout=none\n"
                                     + "speaker: enabled=1, mode=sound\n" + "parport1: enabled=1, file=none\n"
                                     + "parport2: enabled=0\n" + "com1: enabled=1, mode=pipe-client, dev=\""
                                     + @"\\.\pipe\" + "%PIPESERVERNAME%\"\n" + "com2: enabled=0\n"
                                     + "com3: enabled=0\n" + "com4: enabled=0\n";

      string[] Keys = default_configuration.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

      for (int i = 0; i < Keys.Length; i++)
      {
        string comboItem = Keys[i];
        int KeyValueIndex = comboItem.IndexOf(":");
        if (KeyValueIndex > -1)
        {
          string Key = comboItem.Substring(0, KeyValueIndex);
          string Value = comboItem.Substring(KeyValueIndex + 1, comboItem.Length - KeyValueIndex - 1);
          defaultConfigs.Add(Key, Value);
        }
        else
        {
          defaultConfigs.Add(comboItem, "");
        }
      }

      string xPort = mParams["VisualStudioDebugPort"];
      string[] xParts = xPort.Split(' ');

      defaultConfigs["com1"] = defaultConfigs["com1"].Replace("%PIPESERVERNAME%", xParts[1].ToLower());
      defaultConfigs["ata0-master"] = defaultConfigs["ata0-master"].Replace("%CDROMBOOTPATH%", mParams["ISOFile"]);
      defaultConfigs["ata1-master"] = defaultConfigs["ata1-master"].Replace("%HARDDISKPATH%", mHarddiskFile);
      defaultConfigs["debug_symbols"] = defaultConfigs["debug_symbols"].Replace("%DEBUGSYMBOLSPATH%", Path.ChangeExtension(mParams["ISOFile"], "sym"));

      if (_useDebugVersion)
      {
        defaultConfigs["magic_break"] = "enabled=1";
      }
    }

    private void GenerateConfiguration(string filePath)
    {
      using (FileStream configFileHandler = File.Create(filePath))
      {
        foreach (KeyValuePair<string, string> xConfig in defaultConfigs)
        {
          string key = xConfig.Key;
          string value = xConfig.Value;

          if (value.Length < 1)
          {
            byte[] lineData = Encoding.ASCII.GetBytes(key + Environment.NewLine);
            configFileHandler.Write(lineData, 0, lineData.Length);
          }
          else
          {
            string configItem = key + ":" + value;
            byte[] lineData = Encoding.ASCII.GetBytes(configItem + Environment.NewLine);
            configFileHandler.Write(lineData, 0, lineData.Length);
          }
        }
      }
    }
  }
}
