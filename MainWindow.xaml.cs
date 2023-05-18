using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using CeleryApp.Properties;
using Dragablz;
using Injector;
using Microsoft.Win32;
using WK.Libraries.BetterFolderBrowserNS.Helpers;

namespace CeleryApp {
  public partial class MainWindow: Window {
    public MainWindow() {
      Directory.CreateDirectory("scripts");
      this.InitializeComponent();
      this.NewTab("Main Tab");
      this.watch();
    }

    private void Window_Closed(object sender, EventArgs e) {
      Application.Current.Shutdown();
    }

    private void ExecutorCheck_Click(object sender, RoutedEventArgs e) {
      bool flag = !this.MiniBarState;
      if (flag) {
        this.SimpleMoveAnimation(this.MainButtons_Copy, new Thickness(0.0, 47.0, 2.4, 0.0), new Thickness(0.0, 47.0, -257.0, 0.0));
        this.SlideBar.Content = "\udb86\uddb1";
        this.MiniBarState = true;
      } else {
        bool miniBarState = this.MiniBarState;
        if (miniBarState) {
          this.SimpleMoveAnimation(this.MainButtons_Copy, new Thickness(0.0, 47.0, -257.0, 0.0), new Thickness(0.0, 47.0, 2.4, 0.0));
          this.SlideBar.Content = "\udb86\uddb0";
          this.MiniBarState = false;
        }
      }
    }

    [DebuggerStepThrough]
    private void ExecutorCheck_Checked(object sender, RoutedEventArgs e) {
      MainWindow. < ExecutorCheck_Checked > d__17 < ExecutorCheck_Checked > d__ = new MainWindow. < ExecutorCheck_Checked > d__17(); <
      ExecutorCheck_Checked > d__. < > t__builder = AsyncVoidMethodBuilder.Create(); <
      ExecutorCheck_Checked > d__. < > 4__ this = this; <
      ExecutorCheck_Checked > d__.sender = sender; <
      ExecutorCheck_Checked > d__.e = e; <
      ExecutorCheck_Checked > d__. < > 1__ state = -1; <
      ExecutorCheck_Checked > d__. < > t__builder.Start < MainWindow. < ExecutorCheck_Checked > d__17 > (ref < ExecutorCheck_Checked > d__);
    }

    private void ExecutorCheck_Unchecked(object sender, RoutedEventArgs e) {
      ((Storyboard) base.TryFindResource("Storyboard3")).Begin();
      this.CloseOutput();
      this.Browser.Visibility = Visibility.Hidden;
      this.TabControlShit.Visibility = Visibility.Hidden;
      this.mainTreeView.Visibility = Visibility.Hidden;
      this.G1.Visibility = Visibility.Hidden;
      this.MainButtons_Copy.Visibility = Visibility.Hidden;
      this.Browser.Visibility = Visibility.Hidden;
      this.SettingsWindow.Visibility = Visibility.Visible;
      this.GameHubWindow.Visibility = Visibility.Visible;
    }

    private void GameHubCheck_Checked(object sender, RoutedEventArgs e) {
      ((Storyboard) base.TryFindResource("Storyboard1")).Begin();
      this.SimpleMoveAnimation(this.GameHubWindow, new Thickness(10.0, base.Height, -10.0, -base.Height), new Thickness(4.0, 4.0, 4.0, -80.0));
      this.CloseOutput();
      this.TabControlShit.Visibility = Visibility.Hidden;
      this.Browser.Visibility = Visibility.Hidden;
      this.mainTreeView.Visibility = Visibility.Hidden;
      this.MainButtons_Copy.Visibility = Visibility.Hidden;
      this.G1.Visibility = Visibility.Hidden;
      this.Browser.Visibility = Visibility.Hidden;
      this.InvisState = true;
      this.SettingsWindow.Visibility = Visibility.Hidden;
      this.GameHubWindow.Visibility = Visibility.Visible;
    }

    [DebuggerStepThrough]
    private void GameHubCheck_Unchecked(object sender, RoutedEventArgs e) {
      MainWindow. < GameHubCheck_Unchecked > d__20 < GameHubCheck_Unchecked > d__ = new MainWindow. < GameHubCheck_Unchecked > d__20(); <
      GameHubCheck_Unchecked > d__. < > t__builder = AsyncVoidMethodBuilder.Create(); <
      GameHubCheck_Unchecked > d__. < > 4__ this = this; <
      GameHubCheck_Unchecked > d__.sender = sender; <
      GameHubCheck_Unchecked > d__.e = e; <
      GameHubCheck_Unchecked > d__. < > 1__ state = -1; <
      GameHubCheck_Unchecked > d__. < > t__builder.Start < MainWindow. < GameHubCheck_Unchecked > d__20 > (ref < GameHubCheck_Unchecked > d__);
    }

    private void SettingsCheck_Checked(object sender, RoutedEventArgs e) {
      ((Storyboard) base.TryFindResource("Storyboard1")).Begin();
      this.SimpleMoveAnimation(this.SettingsWindow, new Thickness(-200.0, 4.0, 200.0, 0.0), new Thickness(4.0, 4.0, 4.0, 4.0));
      this.CloseOutput();
      this.TabControlShit.Visibility = Visibility.Hidden;
      this.MainButtons_Copy.Visibility = Visibility.Hidden;
      this.Browser.Visibility = Visibility.Hidden;
      this.mainTreeView.Visibility = Visibility.Hidden;
      this.G1.Visibility = Visibility.Hidden;
      this.Browser.Visibility = Visibility.Hidden;
      this.InvisState = true;
      this.SettingsWindow.Visibility = Visibility.Visible;
      this.GameHubWindow.Visibility = Visibility.Hidden;
    }

    [DebuggerStepThrough]
    private void SettingsCheck_Unchecked(object sender, RoutedEventArgs e) {
      MainWindow. < SettingsCheck_Unchecked > d__22 < SettingsCheck_Unchecked > d__ = new MainWindow. < SettingsCheck_Unchecked > d__22(); <
      SettingsCheck_Unchecked > d__. < > t__builder = AsyncVoidMethodBuilder.Create(); <
      SettingsCheck_Unchecked > d__. < > 4__ this = this; <
      SettingsCheck_Unchecked > d__.sender = sender; <
      SettingsCheck_Unchecked > d__.e = e; <
      SettingsCheck_Unchecked > d__. < > 1__ state = -1; <
      SettingsCheck_Unchecked > d__. < > t__builder.Start < MainWindow. < SettingsCheck_Unchecked > d__22 > (ref < SettingsCheck_Unchecked > d__);
    }

    public void askCeleryKey(bool x = true) {}

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      DispatcherTimer dispatcherTimer = new DispatcherTimer();
      dispatcherTimer.Tick += this.dispatcherTimer_Tick;
      dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
      dispatcherTimer.Start();
      DispatcherTimer dispatcherTimer2 = new DispatcherTimer();
      dispatcherTimer2.Tick += this.update2Timer_Tick;
      dispatcherTimer2.Interval = new TimeSpan(0, 1, 0);
      dispatcherTimer2.Start();
      DispatcherTimer dispatcherTimer3 = new DispatcherTimer();
      dispatcherTimer3.Tick += this.updateTimer_Tick;
      dispatcherTimer3.Interval = new TimeSpan(0, 0, 0, 0, 10);
      dispatcherTimer3.Start();
      this.OutputWindow.Visibility = Visibility.Hidden;
      this.TabControlShit.Visibility = Visibility.Hidden;
      this.Browser.Visibility = Visibility.Hidden;
      this.G1.Visibility = Visibility.Hidden;
      this.MainButtons_Copy.Visibility = Visibility.Hidden;
      this.WelcomeLabel_Copy.Content = Environment.UserName;
      this.SimpleMoveAnimation(this.HomeWindow, new Thickness(-701.0, 40.0, 0.0, -4.0), new Thickness(0.0, 41.0, 0.0, 0.0));
      new Thread(delegate(object o) {
        bool flag = !Directory.Exists(Path.GetTempPath() + "celery");
        if (flag) {
          try {
            Directory.CreateDirectory(Path.GetTempPath() + "celery");
          } catch (Exception ex) {
            MessageBox.Show("An issue occurred. Please restart Celery. Error message: " + ex.Message);
          }
        }
        FileHelp.checkCreateFile(Path.GetTempPath() + "celery\\celeryhome.txt", AppDomain.CurrentDomain.BaseDirectory + "dll\\");
        FileHelp.checkCreateFile(AppDomain.CurrentDomain.BaseDirectory + "dll/uwpversion.txt", "0.100");
        FileHelp.checkCreateFile(AppDomain.CurrentDomain.BaseDirectory + "appversion.txt", "0.100");
        this.checkUpdates();
      }).Start();
    }

    public string HttpReadPlainText(string uri) {
      HttpWebRequest httpWebRequest;
      try {
        httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
      } catch (NotSupportedException ex) {
        Console.Out.WriteLine("NotSupportedException occurred when trying to initiate WebRequest for " + uri);
        return "";
      } catch (SecurityException ex2) {
        Console.Out.WriteLine("SecurityException occurred when trying to initiate WebRequest for " + uri);
        return "";
      }
      HttpWebResponse httpWebResponse;
      try {
        httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
      } catch (WebException ex3) {
        Console.Out.WriteLine("WebException occurred when trying to get a response from server " + uri);
        return "";
      } catch (ProtocolViolationException ex4) {
        Console.Out.WriteLine("ProtocolViolationException occurred when trying to get a response from server " + uri);
        return "";
      } catch (InvalidOperationException ex5) {
        Console.Out.WriteLine("InvalidOperationException occurred when trying to get a response from server " + uri);
        return "";
      } catch (NotSupportedException ex6) {
        Console.Out.WriteLine("NotSupportedException occurred when trying to get a response from server " + uri);
        return "";
      }
      Stream stream = null;
      try {
        stream = httpWebResponse.GetResponseStream();
      } catch (ProtocolViolationException ex7) {
        Console.Out.WriteLine("ProtocolViolationException occurred when trying to open response stream, server " + uri);
        return "";
      } catch (ObjectDisposedException ex8) {
        Console.Out.WriteLine("ObjectDisposedException occurred when trying to open response stream, server " + uri);
        return "";
      }
      bool flag = stream == null;
      string result;
      if (flag) {
        result = "";
      } else {
        StreamReader streamReader = new StreamReader(stream);
        string text = "";
        try {
          text = streamReader.ReadToEnd();
        } catch (OutOfMemoryException ex9) {
          Console.Out.WriteLine("OutOfMemoryException occurred when trying to read response stream, server " + uri);
          return "";
        } catch (IOException ex10) {
          Console.Out.WriteLine("IOException occurred when trying to read response stream, server " + uri);
          return "";
        }
        result = text;
      }
      return result;
    }

    public byte[] HttpReadBytes(string uri) {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
      byte[] result;
      using(HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse()) {
        using(Stream responseStream = httpWebResponse.GetResponseStream()) {
          List < byte > list = new List < byte > ();
          for (;;) {
            int num = responseStream.ReadByte();
            bool flag = num == -1;
            if (flag) {
              break;
            }
            list.Add((byte) num);
          }
          result = list.ToArray();
        }
      }
      return result;
    }

    private void update2Timer_Tick(object sender, EventArgs e) {
      this.checkUpdates();
    }

    private void updateTimer_Tick(object sender, EventArgs e) {
      foreach(Util.ProcInfo procInfo in MsStorePlayer.getInjectedProcesses()) {
        int procAddress = Imports.GetProcAddress(Imports.GetModuleHandle("USER32.dll"), "DrawIconEx");
        int num = procAddress + 60;
        int num2 = procInfo.readInt32(num);
        bool flag = num2 == 1;
        if (flag) {
          int num3 = procInfo.readInt32(num + 4);
          int address = procInfo.readInt32(num + 8);
          bool flag2 = num3 > 0;
          if (flag2) {
            string value = procInfo.readString(address, num3);
            Console.Out.WriteLine(value);
          }
        } else {
          bool flag3 = num2 == 2;
          if (flag3) {
            int num4 = procInfo.readInt32(num + 4);
            int address2 = procInfo.readInt32(num + 8);
            bool flag4 = num4 > 0;
            if (flag4) {
              string value2 = procInfo.readWString(address2, num4);
              Console.Out.WriteLine(value2);
            }
          } else {
            bool flag5 = num2 == 3;
            if (flag5) {
              int num5 = procInfo.readInt32(num + 4);
              int address3 = procInfo.readInt32(num + 8);
              bool flag6 = num5 > 0;
              if (flag6) {
                string path = procInfo.readWString(address3, num5);
                bool flag7 = File.Exists(path);
                if (flag7) {
                  string text = File.ReadAllText(path);
                  int num6 = Imports.VirtualAllocEx(procInfo.handle, 0, text.Length, 12288 U, 4 U);
                  procInfo.writeString(num6, text, -1);
                  procInfo.writeInt32(num + 12, text.Length);
                  procInfo.writeInt32(num + 16, num6);
                } else {
                  procInfo.writeInt32(num + 12, 0);
                  procInfo.writeInt32(num + 16, 0);
                }
              }
            } else {
              bool flag8 = num2 == 4;
              if (flag8) {
                int num7 = procInfo.readInt32(num + 4);
                int address4 = procInfo.readInt32(num + 8);
                bool flag9 = num7 > 0;
                if (flag9) {
                  string path2 = procInfo.readWString(address4, num7);
                  bool flag10 = File.Exists(path2);
                  if (flag10) {
                    string text2 = File.ReadAllText(path2);
                    int num8 = Imports.VirtualAllocEx(procInfo.handle, 0, text2.Length, 12288 U, 4 U);
                    procInfo.writeWString(num8, text2, -1);
                    procInfo.writeInt32(num + 12, text2.Length);
                    procInfo.writeInt32(num + 16, num8);
                  } else {
                    procInfo.writeInt32(num + 12, 0);
                    procInfo.writeInt32(num + 16, 0);
                  }
                }
              } else {
                bool flag11 = num2 == 5;
                if (flag11) {
                  int num9 = procInfo.readInt32(num + 4);
                  int address5 = procInfo.readInt32(num + 8);
                  int num10 = procInfo.readInt32(num + 12);
                  int address6 = procInfo.readInt32(num + 16);
                  bool flag12 = num9 > 0 && num10 > 0;
                  if (flag12) {
                    string path3 = procInfo.readWString(address5, num9);
                    byte[] bytes = procInfo.readBytes(address6, num10);
                    FileHelp.checkCreateFile(path3);
                    try {
                      File.WriteAllBytes(path3, bytes);
                    } catch (Exception ex) {}
                  }
                } else {
                  bool flag13 = num2 == 6;
                  if (flag13) {
                    int num11 = procInfo.readInt32(num + 4);
                    int address7 = procInfo.readInt32(num + 8);
                    int num12 = procInfo.readInt32(num + 12);
                    int address8 = procInfo.readInt32(num + 16);
                    bool flag14 = num11 > 0 && num12 > 0;
                    if (flag14) {
                      string path4 = procInfo.readWString(address7, num11);
                      byte[] bytes2 = procInfo.readBytes(address8, num12 * 2);
                      FileHelp.checkCreateFile(path4);
                      try {
                        File.WriteAllBytes(path4, bytes2);
                      } catch (Exception ex2) {}
                    }
                  } else {
                    bool flag15 = num2 == 7;
                    if (flag15) {
                      int num13 = procInfo.readInt32(num + 4);
                      int address9 = procInfo.readInt32(num + 8);
                      bool flag16 = num13 > 0;
                      if (flag16) {
                        string sMessage = procInfo.readString(address9, num13);
                        Imports.MessageBoxA(Imports.FindWindow(null, "Roblox"), sMessage, "[Celery]", 0 U);
                      }
                    } else {
                      bool flag17 = num2 == 8;
                      if (flag17) {
                        int num14 = procInfo.readInt32(num + 4);
                        int address10 = procInfo.readInt32(num + 8);
                        bool flag18 = num14 > 0;
                        if (flag18) {
                          string sMessage2 = procInfo.readWString(address10, num14);
                          Imports.MessageBoxW(Imports.FindWindow(null, "Roblox"), sMessage2, "", 0 U);
                        }
                      } else {
                        bool flag19 = num2 == 9;
                        if (flag19) {
                          int num15 = procInfo.readInt32(num + 4);
                          int address11 = procInfo.readInt32(num + 8);
                          int num16 = procInfo.readInt32(num + 12);
                          int address12 = procInfo.readInt32(num + 16);
                          bool flag20 = num15 > 0 && num16 > 0;
                          if (flag20) {
                            string path5 = procInfo.readWString(address11, num15);
                            string contents = procInfo.readString(address12, num16);
                            FileHelp.checkCreateFile(path5);
                            try {
                              File.AppendAllText(path5, contents);
                            } catch (Exception ex3) {}
                          }
                        } else {
                          bool flag21 = num2 == 10;
                          if (flag21) {
                            int num17 = procInfo.readInt32(num + 4);
                            int address13 = procInfo.readInt32(num + 8);
                            int num18 = procInfo.readInt32(num + 12);
                            int address14 = procInfo.readInt32(num + 16);
                            bool flag22 = num17 > 0 && num18 > 0;
                            if (flag22) {
                              string path6 = procInfo.readWString(address13, num17);
                              byte[] array = procInfo.readBytes(address14, num18 * 2);
                              string text3 = "";
                              foreach(byte b in array) {
                                string str = text3;
                                char c = (char) b;
                                text3 = str + c.ToString();
                              }
                              FileHelp.checkCreateFile(path6);
                              try {
                                File.AppendAllText(path6, text3);
                              } catch (Exception ex4) {}
                            }
                          } else {
                            bool flag23 = num2 == 11;
                            if (flag23) {
                              int num19 = procInfo.readInt32(num + 4);
                              int address15 = procInfo.readInt32(num + 8);
                              bool flag24 = num19 > 0;
                              if (flag24) {
                                string path7 = procInfo.readWString(address15, num19);
                                try {
                                  Directory.CreateDirectory(path7);
                                } catch (Exception ex5) {}
                              }
                            } else {
                              bool flag25 = num2 == 12;
                              if (flag25) {
                                int num20 = procInfo.readInt32(num + 4);
                                int address16 = procInfo.readInt32(num + 8);
                                bool flag26 = num20 > 0;
                                if (flag26) {
                                  string path8 = procInfo.readWString(address16, num20);
                                  bool flag27 = File.Exists(path8);
                                  if (flag27) {
                                    try {
                                      File.Delete(path8);
                                    } catch (Exception ex6) {}
                                  }
                                }
                              } else {
                                bool flag28 = num2 == 13;
                                if (flag28) {
                                  int num21 = procInfo.readInt32(num + 4);
                                  int address17 = procInfo.readInt32(num + 8);
                                  bool flag29 = num21 > 0;
                                  if (flag29) {
                                    string path9 = procInfo.readWString(address17, num21);
                                    bool flag30 = Directory.Exists(path9);
                                    if (flag30) {
                                      try {
                                        Directory.Delete(path9);
                                      } catch (Exception ex7) {}
                                    }
                                  }
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
        bool flag31 = procInfo.isOpen();
        if (flag31) {
          procInfo.writeInt32(num, 0);
        }
      }
    }

    public void askUpdateApp() {
      bool flag = MessageBoxResult.OK == MessageBox.Show("Celery app has been updated (full restart required...). Press Ok to visit the download page. Download the latest zip and Extract All. NOTE: To keep your auto-run script and other files that you don't want to lose, you will have to transfer them into the new directories.", "Full App Update", MessageBoxButton.OKCancel);
      if (flag) {
        Process.Start("http://celerystick.xyz/Celery/download.php");
      }
    }

    public static void writeAppSettings() {}

    private void Window_KeyDown(object sender, KeyEventArgs e) {
      bool flag = Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.K;
      if (flag) {
        this.askCeleryKey(true);
      }
    }

    public string getUpdateUrl(string settings, string tag) {
      string text = "";
      int i = settings.IndexOf(tag) + tag.Length + 2;
      bool flag = i > 0;
      if (flag) {
        while (i < settings.Length) {
          bool flag2 = settings[i] == '"';
          if (flag2) {
            break;
          }
          text += settings[i++].ToString();
        }
      }
      return text;
    }

    public bool postFileUpdate(string settings, string settingsUpdateUrlTag, string updatedFileName) {
      string updateUrl = this.getUpdateUrl(settings, settingsUpdateUrlTag);
      bool flag = updateUrl.Length != 0;
      if (flag) {
        bool flag2 = MessageBox.Show("Update required for Celery file(s). Press Ok to download.", "Update", MessageBoxButton.OKCancel) == MessageBoxResult.OK;
        if (flag2) {
          while (WindowsPlayer.getInjectedProcesses().Count > 0 || MsStorePlayer.getInjectedProcesses().Count > 0) {
            MessageBox.Show("Please close active roblox games before updating");
            Thread.Sleep(500);
          }
          byte[] array = this.HttpReadBytes(updateUrl);
          bool flag3 = array.Length != 0;
          if (flag3) {
            FileHelp.checkCreateFile(AppDomain.CurrentDomain.BaseDirectory + "dll/" + updatedFileName);
            try {
              File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "dll\\" + updatedFileName, array);
            } catch (Exception ex) {
              return false;
            }
            this.CreateNotification("Update complete!");
            return true;
          }
        }
      }
      return false;
    }

    public void checkUpdates() {
      string text = this.HttpReadPlainText("https://raw.githubusercontent.com/TheSeaweedMonster/Celery/main/settings.txt");
      bool flag = text.Length == 0;
      if (!flag) {
        float num;
        float.TryParse(text.Substring(text.IndexOf("appversion=") + 11, 5), out num);
        float num2;
        float.TryParse(text.Substring(text.IndexOf("uwpversion=") + 11, 5), out num2);
        float num3;
        float.TryParse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "appversion.txt"), out num3);
        float num4;
        float.TryParse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "dll\\uwpversion.txt"), out num4);
        bool flag2 = num > num3;
        if (flag2) {
          string updateUrl = this.getUpdateUrl(text, "appurl");
          bool flag3 = updateUrl.Length > 0;
          if (flag3) {
            bool flag4 = MessageBox.Show("Update required for Celery App. Press Ok to download.", "Update", MessageBoxButton.OKCancel) == MessageBoxResult.OK;
            if (flag4) {
              BetterFolderBrowserDialog betterFolderBrowserDialog = new BetterFolderBrowserDialog();
              bool flag5 = betterFolderBrowserDialog.ShowDialog();
              if (flag5) {
                string fileName = betterFolderBrowserDialog.FileName;
                bool flag6 = fileName.Length != 0;
                if (flag6) {
                  string text2 = AppDomain.CurrentDomain.BaseDirectory + "download.zip";
                  bool flag7 = !File.Exists(text2);
                  if (flag7) {
                    WebClient webClient = new WebClient();
                    webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
                    webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
                    try {
                      webClient.DownloadFileAsync(new Uri(updateUrl), text2);
                    } catch (Exception ex) {
                      return;
                    }
                  }
                  try {
                    try {
                      Directory.CreateDirectory(fileName);
                    } catch (Exception ex2) {
                      return;
                    }
                    try {
                      ZipFile.ExtractToDirectory(text2, fileName);
                    } catch (Exception ex3) {
                      return;
                    }
                  } catch (Exception ex4) {
                    return;
                  }
                  this.CreateNotification("Downloaded CeleryApp to " + fileName);
                }
              }
            }
          }
        }
        bool flag8 = num2 > num4;
        if (flag8) {
          bool flag9 = MessageBox.Show("Update required for celery file(s). Press Ok to download.", "Update", MessageBoxButton.OKCancel) == MessageBoxResult.OK;
          if (flag9) {
            bool flag10 = this.postFileUpdate(text, "uwpdllurl", "celeryuwp.bin") && this.postFileUpdate(text, "uwpoffurl", "uwpoff.bin") && this.postFileUpdate(text, "uwpiniturl", "uwpinit.lua");
            if (flag10) {
              try {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "dll\\uwpversion.txt", Convert.ToString(num2));
              } catch (Exception ex5) {}
            } else {
              MessageBox.Show("Update failed...Wait 1 minute or restart CeleryApp");
            }
          }
        }
      }
    }

    private void dispatcherTimer_Tick(object sender, EventArgs e) {
      bool flag = MsStorePlayer.getInjectedProcesses().Count == 0;
      if (flag) {
        bool consoleInUse = MsStorePlayer.consoleInUse;
        if (consoleInUse) {
          MsStorePlayer.hideConsole();
        }
      }
      bool flag2 = this.autoInjectDelay > 10;
      if (flag2) {
        this.autoInjectDelay = 0;
      } else {
        bool flag3 = this.autoInjectDelay > 0;
        if (flag3) {
          this.autoInjectDelay++;
        }
      }
      bool flag4 = this.autoInjectDelay == 0;
      if (flag4) {
        bool autolaunch = Settings.Default.Autolaunch;
        if (autolaunch) {
          bool flag5 = false;
          foreach(Util.ProcInfo pinfo in Util.openProcessesByName("Windows10Universal.exe")) {
            bool flag6 = !MsStorePlayer.isInjected(pinfo);
            if (flag6) {
              InjectionStatus injectionStatus = MsStorePlayer.injectPlayer(pinfo);
              bool flag7 = injectionStatus == InjectionStatus.SUCCESS;
              if (flag7) {
                flag5 = true;
                this.CreateNotification("Celery injected");
              } else {
                bool flag8 = injectionStatus == InjectionStatus.ALREADY_INJECTING;
                if (flag8) {
                  Thread.Sleep(250);
                } else {
                  bool flag9 = injectionStatus == InjectionStatus.FAILED;
                  if (flag9) {
                    this.CreateNotification("Injection failed! Unknown error.");
                  }
                }
              }
              bool flag10 = !MainWindow.incognitoEnabled && flag5;
              if (flag10) {
                break;
              }
            }
          }
        }
      }
    }

    private void button_MouseEnter_1(object sender, MouseEventArgs e) {
      ((Storyboard) base.TryFindResource("Attach")).Begin();
    }

    private void button_MouseLeave(object sender, MouseEventArgs e) {
      ((Storyboard) base.TryFindResource("Attach2")).Begin();
    }

    [DebuggerStepThrough]
    private void StartUsingCelery(object sender, RoutedEventArgs e) {
      MainWindow. < StartUsingCelery > d__41 < StartUsingCelery > d__ = new MainWindow. < StartUsingCelery > d__41(); <
      StartUsingCelery > d__. < > t__builder = AsyncVoidMethodBuilder.Create(); <
      StartUsingCelery > d__. < > 4__ this = this; <
      StartUsingCelery > d__.sender = sender; <
      StartUsingCelery > d__.e = e; <
      StartUsingCelery > d__. < > 1__ state = -1; <
      StartUsingCelery > d__. < > t__builder.Start < MainWindow. < StartUsingCelery > d__41 > (ref < StartUsingCelery > d__);
    }

    private void ReportBugs(object sender, RoutedEventArgs e) {
      Process.Start("http://www.celerystick.xyz/");
    }

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out MainWindow.POINT lpPoint);

    public static Point GetCursorPosition() {
      MainWindow.POINT point;
      MainWindow.GetCursorPos(out point);
      return point;
    }

    private void Window_MoveFinish(object sender, MouseButtonEventArgs e) {}

    private void Window_Move(object sender, MouseButtonEventArgs e) {
      bool flag = e.LeftButton == MouseButtonState.Pressed;
      if (flag) {
        base.ResizeMode = ResizeMode.NoResize;
        base.DragMove();
        base.ResizeMode = ResizeMode.CanResizeWithGrip;
      }
    }

    private void CloseBtn_Click(object sender, RoutedEventArgs e) {
      Application.Current.Shutdown();
    }

    private void MinimizeBtrn(object sender, RoutedEventArgs e) {
      base.WindowState = WindowState.Minimized;
    }

    private void Button_Click(object sender, RoutedEventArgs e) {
      base.WindowState = WindowState.Maximized;
    }

    private void watch() {
      this.mainTreeView.Items.Clear();
      DirectoryInfo directoryInfo = new DirectoryInfo("./scripts");
      this.mainTreeView.Items.Add(this.CreateDirectoryNode(directoryInfo));
      this.watchingFolder = "./scripts";
      this.fs = new FileSystemWatcher(this.watchingFolder, "*.*");
      this.fs.EnableRaisingEvents = true;
      this.fs.IncludeSubdirectories = true;
      this.fs.Created += this.changed;
      this.fs.Changed += this.changed;
      this.fs.Renamed += this.renamed;
      this.fs.Deleted += this.changed;
    }

    private void changed(object source, FileSystemEventArgs e) {
      this.mainTreeView.Dispatcher.Invoke(delegate() {
        this.mainTreeView.Items.Clear();
        DirectoryInfo directoryInfo = new DirectoryInfo("./scripts");
        this.mainTreeView.Items.Add(this.CreateDirectoryNode(directoryInfo));
      });
    }

    private void renamed(object source, RenamedEventArgs e) {
      this.mainTreeView.Dispatcher.Invoke(delegate() {
        this.mainTreeView.Items.Clear();
        DirectoryInfo directoryInfo = new DirectoryInfo("./scripts");
        this.mainTreeView.Items.Add(this.CreateDirectoryNode(directoryInfo));
      });
    }

    private TreeViewItem GetTreeView(string tag, string text, string imagePath) {
      TreeViewItem treeViewItem = new TreeViewItem();
      treeViewItem.Foreground = Brushes.Gray;
      treeViewItem.Tag = tag;
      treeViewItem.IsExpanded = false;
      StackPanel stackPanel = new StackPanel();
      stackPanel.Orientation = Orientation.Horizontal;
      Image image = new Image();
      image.Source = new BitmapImage(new Uri("pack://application:,,/ScriptList/" + imagePath));
      image.Width = 16.0;
      image.Height = 16.0;
      RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
      Label label = new Label();
      label.Content = text;
      label.Foreground = Brushes.Gray;
      stackPanel.Children.Add(image);
      stackPanel.Children.Add(label);
      treeViewItem.Header = stackPanel;
      treeViewItem.ToolTip = imagePath;
      ToolTipService.SetIsEnabled(treeViewItem, false);
      return treeViewItem;
    }

    public void ListDirectory(TreeView treeView, string path) {
      treeView.Items.Clear();
      DirectoryInfo directoryInfo = new DirectoryInfo(path);
      treeView.Items.Add(this.CreateDirectoryNode(directoryInfo));
    }

    private TreeViewItem CreateDirectoryNode(DirectoryInfo directoryInfo) {
      TreeViewItem treeView = this.GetTreeView(directoryInfo.FullName, directoryInfo.Name, "2folder.ico");
      foreach(DirectoryInfo directoryInfo2 in directoryInfo.GetDirectories()) {
        treeView.Items.Add(this.CreateDirectoryNode(directoryInfo2));
      }
      foreach(FileInfo fileInfo in directoryInfo.GetFiles()) {
        bool flag = fileInfo.Extension == ".lua";
        if (flag) {
          treeView.Items.Add(this.GetTreeView(fileInfo.FullName, fileInfo.Name, "lua.png"));
        } else {
          bool flag2 = fileInfo.Extension == ".txt";
          if (flag2) {
            treeView.Items.Add(this.GetTreeView(fileInfo.FullName, fileInfo.Name, "txt.ico"));
          } else {
            treeView.Items.Add(this.GetTreeView(fileInfo.FullName, fileInfo.Name, "file.ico"));
          }
        }
      }
      return treeView;
    }

    private void mainTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs < object > e) {
      try {
        bool flag = this.mainTreeView.SelectedItem != null;
        if (flag) {
          TreeViewItem treeViewItem = this.mainTreeView.SelectedItem as TreeViewItem;
          string text = treeViewItem.Tag.ToString();
          bool flag2 = text.EndsWith(".txt") || (text.EndsWith(".lua") && !treeViewItem.ToolTip.ToString().EndsWith("folder.png"));
          if (flag2) {
            StreamReader streamReader = new StreamReader(treeViewItem.Tag.ToString());
            this.Browser.SetText(streamReader.ReadToEnd());
          }
        }
      } catch (Exception ex) {
        this.NotifState = true;
        this.CreateNotification(ex.ToString());
        Clipboard.SetText(ex.ToString());
        this.NotifState = false;
      }
    }

    private void Inject_Click(object sender, RoutedEventArgs e) {
      bool flag = false;
      bool flag2 = !MainWindow.incognitoEnabled && flag;
      if (!flag2) {
        foreach(Util.ProcInfo pinfo in Util.openProcessesByName("Windows10Universal.exe")) {
          bool flag3 = !MsStorePlayer.isInjected(pinfo);
          if (flag3) {
            InjectionStatus injectionStatus = MsStorePlayer.injectPlayer(pinfo);
            bool flag4 = injectionStatus == InjectionStatus.SUCCESS;
            if (flag4) {
              flag = true;
              this.CreateNotification("Celery injected");
            } else {
              bool flag5 = injectionStatus == InjectionStatus.ALREADY_INJECTING;
              if (flag5) {
                Thread.Sleep(250);
              } else {
                bool flag6 = injectionStatus == InjectionStatus.FAILED;
                if (flag6) {
                  this.CreateNotification("Injection failed! Unknown error.");
                }
              }
            }
            bool flag7 = !MainWindow.incognitoEnabled && flag;
            if (flag7) {
              break;
            }
          }
        }
      }
    }

    [DebuggerStepThrough]
    private void Execute_Click(object sender, RoutedEventArgs e) {
      MainWindow. < Execute_Click > d__66 < Execute_Click > d__ = new MainWindow. < Execute_Click > d__66(); <
      Execute_Click > d__. < > t__builder = AsyncVoidMethodBuilder.Create(); <
      Execute_Click > d__. < > 4__ this = this; <
      Execute_Click > d__.sender = sender; <
      Execute_Click > d__.e = e; <
      Execute_Click > d__. < > 1__ state = -1; <
      Execute_Click > d__. < > t__builder.Start < MainWindow. < Execute_Click > d__66 > (ref < Execute_Click > d__);
    }

    private void LoadFile_Click(object sender, RoutedEventArgs e) {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Text files (*.txt)|*.txt|Lua files (*.lua*)|*.lua*";
      bool ? flag = openFileDialog.ShowDialog();
      bool flag2 = true;
      bool flag3 = flag.GetValueOrDefault() == flag2 & flag != null;
      if (flag3) {
        this.Browser.SetText(File.ReadAllText(openFileDialog.FileName));
      }
    }

    [DebuggerStepThrough]
    private void SaveFile_Click(object sender, RoutedEventArgs e) {
      MainWindow. < SaveFile_Click > d__68 < SaveFile_Click > d__ = new MainWindow. < SaveFile_Click > d__68(); <
      SaveFile_Click > d__. < > t__builder = AsyncVoidMethodBuilder.Create(); <
      SaveFile_Click > d__. < > 4__ this = this; <
      SaveFile_Click > d__.sender = sender; <
      SaveFile_Click > d__.e = e; <
      SaveFile_Click > d__. < > 1__ state = -1; <
      SaveFile_Click > d__. < > t__builder.Start < MainWindow. < SaveFile_Click > d__68 > (ref < SaveFile_Click > d__);
    }

    private void Clear_Click(object sender, RoutedEventArgs e) {
      this.Browser.SetText("");
    }

    private void NewTab_Click(object sender, RoutedEventArgs e) {
      bool flag = this.TabCount < 6;
      if (flag) {
        this.TabCount++;
        this.NewTab("New Tab" + this.TabCount.ToString());
      } else {
        this.NotifState = true;
        this.CreateNotification("Exceeded Limit for creating tabs.");
        this.NotifState = false;
      }
    }

    private void CloseTab_Click(object sender, RoutedEventArgs e) {
      this.TabCount--;
      this.TabControlShit.Items.Remove(this.TabControlShit.SelectedItem);
    }

    public TabItem NewTab(string title) {
      this.Browser = new WebViewA("");
      this.Browser.UpdateWindowPos();
      TextBox header = new TextBox {
        Text = title,
          IsEnabled = false,
          TextWrapping = TextWrapping.NoWrap,
          IsHitTestVisible = false,
          Background = Brushes.Transparent,
          BorderBrush = Brushes.Transparent,
          Foreground = Brushes.White,
          FontFamily = new FontFamily("Bahschrift"),
          FontSize = 12.0
      };
      this.TabSettings = new TabItem {
        Style = (base.TryFindResource("Tab") as Style),
          Content = this.Browser,
          Header = header,
          AllowDrop = true
      };
      this.TabControlShit.SelectedIndex = this.TabControlShit.Items.Add(this.TabSettings);
      return this.TabSettings;
    }

    [DebuggerStepThrough]
    public void SimpleMoveAnimation(DependencyObject Object, Thickness Get, Thickness Set) {
      MainWindow. < SimpleMoveAnimation > d__74 < SimpleMoveAnimation > d__ = new MainWindow. < SimpleMoveAnimation > d__74(); <
      SimpleMoveAnimation > d__. < > t__builder = AsyncVoidMethodBuilder.Create(); <
      SimpleMoveAnimation > d__. < > 4__ this = this; <
      SimpleMoveAnimation > d__.Object = Object; <
      SimpleMoveAnimation > d__.Get = Get; <
      SimpleMoveAnimation > d__.Set = Set; <
      SimpleMoveAnimation > d__. < > 1__ state = -1; <
      SimpleMoveAnimation > d__. < > t__builder.Start < MainWindow. < SimpleMoveAnimation > d__74 > (ref < SimpleMoveAnimation > d__);
    }

    public void Fade(DependencyObject Object) {
      DoubleAnimation doubleAnimation = new DoubleAnimation {
        From = new double ? (0.0),
          To = new double ? (1.0),
          Duration = TimeSpan.FromMilliseconds(1000.0)
      };
      Storyboard.SetTarget(doubleAnimation, Object);
      Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity", new object[] {
        1
      }));
      this.SliderStoryBoard.Children.Add(doubleAnimation);
      this.SliderStoryBoard.Begin();
      this.SliderStoryBoard.Children.Remove(doubleAnimation);
    }

    public void FadeOut(DependencyObject Object) {
      DoubleAnimation doubleAnimation = new DoubleAnimation {
        From = new double ? (1.0),
          To = new double ? (0.0),
          Duration = TimeSpan.FromMilliseconds(1000.0)
      };
      Storyboard.SetTarget(doubleAnimation, Object);
      Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity", new object[] {
        1
      }));
      this.SliderStoryBoard.Children.Add(doubleAnimation);
      this.SliderStoryBoard.Begin();
      this.SliderStoryBoard.Children.Remove(doubleAnimation);
    }

    private IEasingFunction MarginEasing {
      get;
      set;
    } = new QuadraticEase {
      EasingMode = EasingMode.EaseInOut
    };

    [DebuggerStepThrough]
    private void CreateNotification(string Notification) {
      MainWindow. < CreateNotification > d__81 < CreateNotification > d__ = new MainWindow. < CreateNotification > d__81(); <
      CreateNotification > d__. < > t__builder = AsyncVoidMethodBuilder.Create(); <
      CreateNotification > d__. < > 4__ this = this; <
      CreateNotification > d__.Notification = Notification; <
      CreateNotification > d__. < > 1__ state = -1; <
      CreateNotification > d__. < > t__builder.Start < MainWindow. < CreateNotification > d__81 > (ref < CreateNotification > d__);
    }

    private void TopMostCheck_Checked(object sender, RoutedEventArgs e) {
      base.Topmost = true;
    }

    private void TopMostCheck_Unchecked(object sender, RoutedEventArgs e) {
      base.Topmost = false;
    }

    private void AutoAttachCheck_Checked(object sender, RoutedEventArgs e) {
      Settings.Default.Autolaunch = true;
    }

    private void AutoAttachCheck_Unchecked(object sender, RoutedEventArgs e) {
      Settings.Default.Autolaunch = false;
    }

    private void IncognitoCheck_Checked(object sender, RoutedEventArgs e) {
      MainWindow.incognitoEnabled = true;
    }

    private void IncognitoCheck_Unchecked(object sender, RoutedEventArgs e) {
      MainWindow.incognitoEnabled = false;
    }

    private void ViewPacketsCheck_Checked(object sender, RoutedEventArgs e) {
      MainWindow.viewPacketsEnabled = true;
      MainWindow.writeAppSettings();
    }

    private void ViewPacketsCheck_Unchecked(object sender, RoutedEventArgs e) {
      MainWindow.viewPacketsEnabled = false;
      MainWindow.writeAppSettings();
    }

    private void ExperimentalCheck_Checked(object sender, RoutedEventArgs e) {
      MainWindow.experimentalEnabled = true;
      MainWindow.writeAppSettings();
    }

    private void ExperimentalCheck_Unchecked(object sender, RoutedEventArgs e) {
      MainWindow.experimentalEnabled = false;
      MainWindow.writeAppSettings();
    }

    private void OpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs < double > e) {
      base.Opacity = this.OpacitySlider.Value;
    }

    public void AutoAttach(object sender, EventArgs e) {}

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {}

    private void AddOutput(string message, MainWindow.OutputType type) {
      int num = 0;
      foreach(char c in message) {
        bool flag = c == '\n';
        if (flag) {
          num++;
        }
      }
      ListViewItem listViewItem = new ListViewItem {
        Content = message,
          Padding = new Thickness(4.0, 4.0, 0.0, 0.0),
          Background = Brushes.Transparent,
          Height = (double)(22 + 16 * num),
          ToolTip = "Copy to clipboard",
          FontFamily = new FontFamily("Bahschrift"),
          FontSize = 13.0
      };
      switch (type) {
      case MainWindow.OutputType.Output:
        listViewItem.Foreground = Brushes.White;
        break;
      case MainWindow.OutputType.Info:
        listViewItem.Foreground = Brushes.AliceBlue;
        break;
      case MainWindow.OutputType.Warning:
        listViewItem.Foreground = Brushes.Gold;
        break;
      case MainWindow.OutputType.Error:
        listViewItem.Foreground = Brushes.IndianRed;
        break;
      }
      bool flag2 = this.outputList.Items.Count > 25;
      if (flag2) {
        this.outputList.Items.RemoveAt(0);
      }
      this.outputList.Items.Add(listViewItem);
    }

    private void CloseOutput() {
      bool flag = this.OutputWindow.Visibility > Visibility.Visible;
      if (!flag) {
        try {
          this.outputList.Items.Clear();
        } catch (NullReferenceException ex) {}
        this.OutputWindow.Visibility = Visibility.Hidden;
        this.OutputWindow.Margin = new Thickness(this.OutputWindow.Margin.Left, this.OutputWindow.Margin.Top, this.OutputWindow.Margin.Right, -180.0);
        this.TabControlShit.Margin = new Thickness(this.TabControlShit.Margin.Left, this.TabControlShit.Margin.Top, this.TabControlShit.Margin.Right, 14.0);
        this.TabControlShit.Height += 110.0;
      }
    }

    private void OutputButton_Click(object sender, RoutedEventArgs e) {
      bool flag = this.OutputWindow.Visibility == Visibility.Hidden;
      if (flag) {
        this.OutputWindow.Visibility = Visibility.Visible;
        this.OutputWindow.Margin = new Thickness(this.OutputWindow.Margin.Left, this.OutputWindow.Margin.Top, this.OutputWindow.Margin.Right, 14.0);
        this.TabControlShit.Margin = new Thickness(this.TabControlShit.Margin.Left, this.TabControlShit.Margin.Top, this.TabControlShit.Margin.Right, 126.0);
        this.TabControlShit.Height -= 110.0;
      } else {
        this.CloseOutput();
      }
    }

    private void ExecuteInfYield(object sender, RoutedEventArgs e) {
      foreach(Util.ProcInfo pinfo in MsStorePlayer.getInjectedProcesses()) {
        MsStorePlayer.sendScript(pinfo, "loadstring(httpget('https://raw.githubusercontent.com/TheSeaweedMonster/Luau/main/scripts/infyield.lua'))()");
      }
    }

    private void ExecuteDexV2(object sender, RoutedEventArgs e) {
      foreach(Util.ProcInfo pinfo in MsStorePlayer.getInjectedProcesses()) {
        MsStorePlayer.sendScript(pinfo, "loadstring(httpget('https://raw.githubusercontent.com/TheSeaweedMonster/Luau/main/scripts/dexv2.lua'))()");
      }
    }

    private void ExecuteUnnamedEsp(object sender, RoutedEventArgs e) {
      foreach(Util.ProcInfo pinfo in MsStorePlayer.getInjectedProcesses()) {
        MsStorePlayer.sendScript(pinfo, "loadstring(httpget('https://raw.githubusercontent.com/TheSeaweedMonster/Luau/main/scripts/unnamedesp.lua'))()");
      }
    }

    private void outputList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      bool flag = this.outputList.SelectedItem != null;
      if (flag) {
        try {
          Clipboard.SetText((string)((ListViewItem) this.outputList.SelectedItem).Content);
        } catch (Exception ex) {}
      }
    }

    private void TabControlShit_SelectionChanged(object sender, SelectionChangedEventArgs e) {}

    private DispatcherTimer dispatcher = new DispatcherTimer();

    private int TabCount = 0;

    private bool NotifState;

    private bool NotifAlready;

    private bool InvisState;

    private bool MiniBarState = false;

    private bool AutoAttaching = false;

    private bool CanAutoAttach = true;

    private int AdWatchDelay = 0;

    private int autoInjectDelay = 0;

    private string userKey = "";

    private Animation Animate = new Animation();

    private TabItem TabSettings = new TabItem();

    private WebViewA Browser;

    public static bool incognitoEnabled;

    public static bool viewPacketsEnabled;

    public static bool experimentalEnabled;

    public Point resizeStart;

    public Point resizeAmount;

    public bool resizeActive = false;

    public MainWindow.ResizePoints resizePoint;

    private FileSystemWatcher fs;

    private string watchingFolder;

    private Storyboard SliderStoryBoard = new Storyboard();

    public enum ResizePoints {
      TopLeft,
      Top,
      TopRight,
      Right,
      BottomRight,
      Bottom,
      BottomLeft,
      Left
    }

    public struct POINT {
      public static implicit operator Point(MainWindow.POINT point) {
        return new Point((double) point.X, (double) point.Y);
      }

      public int X;

      public int Y;
    }

    private enum OutputType {
      Output,
      Info,
      Warning,
      Error
    }
  }
}