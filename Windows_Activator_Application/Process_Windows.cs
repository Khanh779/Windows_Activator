using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Windows_Activator
{
    public partial class Process_Windows
    {
        public static void Reset_Activation()
        {
            Process_Script("/clear");
        }


        public static void Activation_Windows(WindowsVersion windowsVersion)
        {
            // Windows 10 Home
            // Windows 10 Professional
            // Windows 10 Enterprise
            // Windows 10 Enterprise LTSB
            // Windows 10 Education
            string[] win10_keys = { "TX9XD-98N7V-6WMQ6-BX7FG-H8Q99",
                                    "3KHY7-WNT83-DGQKR-F7HPR-844BM",
                                    "7HNRX-D7KGG-3K4RQ-4WPJ4-YTDFH",
                                    "PVMJN-6DFY6-9CCP6-7BKTT-D3WVR",
                                    "W269N-WFGWX-YVC9B-4J6C9-T83GX",
                                    "MH37W-N47XK-V7XM9-C7227-GCQG9",
                                    "NW6C2-QMPVW-D7KKK-3GKT6-VCFB2",
                                    "NW6C2-QMPVW-D7KKK-3GKT6-VCFB2",
                                    "2WH4N-8QGBV-H22JP-CT43Q-MDWWJ",
                                    "NPPR9-FWDCX-D2C8J-H872K-2YT43",
                                    "DPH2V-TTNVB-4X9Q3-TJR4H-KHJW4",
                                    "WNMTR-4C88C-JK8YV-HQ7T2-76DF9",
                                    "2F77B-TNFGY-69QQF-B8YKP-D69TJ"
                                    };

            // Windows 8 Core
            // Windows 8 Core Single Language
            // Windows 8 Professional
            // Windows 8 Professional N
            // Windows 8 Professional WMC
            // Windows 8 Enterprise
            // Windows 8 Enterprise N
            // Windows 8.1 Core
            // Windows 8.1 Core N
            // Windows 8.1 Core Single Language
            // Windows 8.1 Professional
            // Windows 8.1 Professional N
            // Windows 8.1 Professional WMC
            // Windows 8.1 Enterprise
            // Windows 8.1 Enterprise N

            string[] win81_keys = { "GNBB8-YVD74-QJHX6-27H4K-8QHDG",
                                    "M9Q9P-WNJJT-6PXPY-DWX8H-6XWKK",
                                    "XCVCF-2NXM9-723PB-MHCB7-2RYQQ",
                                    "MHF9N-XY6XB-WVXMC-BTDCT-MKKG7",
                                    "TT4HM-HN7YT-62K67-RGRQJ-JFFXW",
                                    "7B9N3-D94CG-YTVHR-QBPX3-RJP64",
                                    "BB6NG-PQ82V-VRDPW-8XVD2-V8P66",
                                    "789NJ-TQK6T-6XTH8-J39CJ-J8D3P" ,
                                    "NG4HW-VH26C-733KW-K6F98-J8CK4",
                                    "GCRJD-8NW9H-F2CDX-CCM8D-9D6T9",
                                    "32JNW-9KQ84-P47T8-D8GGY-CWCK7",
                                    "JMNMF-RHW7P-DMY6X-RF3DR-X2BQT",
                                    "HMCNV-VVBFX-7HMBH-CTY9B-B4FXY"
            };

            string[] win7_keys =
            {
                                    "BCD25-QLO9D-YZSXR-NNNCD-XXZ9Z",   //Windows 7 Ultimate
                                    "36NKG-6YHUY-Z89TY-V7DCV-PKAMA",
                                    "Q3VMJ-TMJ3M-99RF9-CVPJ3-Q7VF3",
                                    "NMZX7-P3ZCD-P58CV-Q2H7C-PKPK1",
                                    "GMY2P-RBX7P-TQGX8-C8B9B-BGXFF",
                                    "AXBS6-LR9OV-MEYF5-RMJB9-UCRT2P", //Windows 7 Home Premium
                                    "6JFPB-DMWMM-6J299-3GF8Y-CXP87" // Windows 7 Professional
            };

            string[] win_keys = { };

            switch (windowsVersion)
            {
                case WindowsVersion.Windows10:
                    win_keys = win10_keys;
                    break;
                case WindowsVersion.Windows8_1:
                    win_keys = win81_keys;
                    break;
                case WindowsVersion.Windows7:
                    win_keys = win7_keys;
                    break;
            }

            string connectKeys = "";
            for (int i = 0; i < win_keys.Length; i++)
            {
                connectKeys += $"{win_keys[i]}";
                if (i < win_keys.Length - 1)
                    connectKeys += ",";
            }
            Process_Script("/activate-key:" + connectKeys);


        }


        static void Process_Script(string cmd)
        {

            string[] KMS_Sevs = {   "kms.chinancce.com",
                                    "NextLevel.uk.to",
                                    "GuangPeng.uk.to",
                                    "AlwaysSmile.uk.to",
                                    "kms.chinancce.com",
                                    "kms.shuax.com" ,
                                    "kms7.MSGuides.com",
                                    "kms8.MSGuides.com",
                                    "kms9.MSGuides.com"
            };

            if (cmd.Contains("/clear"))
            {
                process.StartInfo.FileName = "cscript";
                process.StartInfo.Arguments = connectCmd(new string[]{
                "//nologo c:\\windows\\system32\\slmgr.vbs /upk",
                "//nologo c:\\windows\\system32\\slmgr.vbs /cpky"
                });
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                _result = ResultActivation.UnActivated;
            }
            else if (cmd.Contains("/activate-key:"))
            {
                foreach (string key in cmd.Replace("/activate-key:", "").Split(','))
                {
                    Process d = CallProcess("csript", "//nologo c:\\windows\\system32\\slmgr.vbs /ipk " + key);
                    d.Start();
                    d.WaitForExit();
                }
                for (int i = 0; i < KMS_Sevs.Length; i++)
                {
                    if (Process_KMS(cmd, KMS_Sevs[i]) == 1)
                        break;

                }
            }



        }

        static int Process_KMS(string cmd, string KMS_Sev)
        {
            process.StartInfo.FileName = "cscript";
            process.StartInfo.Arguments = connectCmd(new string[]
            {
                $"//nologo c:\\windows\\system32\\slmgr.vbs /skms {KMS_Sev} >nul",
                "//nologo c:\\windows\\system32\\slmgr.vbs /ato"
            });
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            if (result.Contains("successfully"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static Process process = new Process();
        public static ResultActivation CheckActivation()
        {
            process.StartInfo.FileName = "cscript";
            process.StartInfo.Arguments = "//nologo c:\\windows\\system32\\slmgr.vbs /ato";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.EnableRaisingEvents = true;
            process.Start();

            string result = process.StandardOutput.ReadToEnd();
            if (result.Contains("successfully"))
            {
                _result = ResultActivation.Activated;
            }
            else
            {
                _result = ResultActivation.Fail;
            }

            return _result;
        }

        public static void AbortAll()
        {
            if (process != null)
                process.Kill();
        }

        public enum WindowsVersion
        {
            WindowsXP,
            Windows7,
            Windows8_1,
            Windows10
        }

        public enum ResultActivation : uint
        {
            Unknown,
            Activated,
            UnActivated,
            Fail
        }

        static ResultActivation _result = ResultActivation.Unknown;

        static string connectCmd(string[] cmds)
        {
            string a = "";
            if (cmds.Length > 0)
                foreach (string cmd in cmds)
                    a += cmd + " & ";
            else a = "";
            return a;
        }

        static Process CallProcess(string fileName, string args)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = args;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //process.EnableRaisingEvents = true;
            return process;
        }

        public static string GetOSName()
        {
            string s = "";
            var p = CallProcess("systeminfo", "");
            p.Start();
            p.WaitForExit();
            s = GetResultFromRowOfProcess("OS Name", p);
            return s;
        }

        static string GetResultFromRowOfProcess(string row, Process process)
        {
            string a = "";
            string result = process.StandardOutput.ReadToEnd();
            string[] lines = result.Split('\n');
            foreach (string line in lines)
            {
                if (line.Contains(row))
                {
                    a = line.Replace(row, "").Replace(":", "").Trim();
                    break;
                }
            }
            return a;
        }


    }
}
