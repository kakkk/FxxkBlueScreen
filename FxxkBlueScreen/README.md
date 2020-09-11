# FxxkBlueScreen
## 简单介绍

FxxkBlueScreen是一个整蛊软件，他能让你的电脑蓝屏，并且在蓝屏之前献上两段制作精美的动画，提醒你他将要蓝屏，在此期间你什么都做不了，任务管理器？Alt+F4？没得没得，你能想到的我都想到了，当你点开它之后你将会有两个选择：1、眼睁睁看着他蓝屏；2、强制关机；
![](https://cdn.kakkk.net/img/729-1.jpg)

## 关于两段动画

第一段，仿Windows升级的提示动画，来自https://fakeupdate.net/
![](https://cdn.kakkk.net/img/729-2.jpg)


第二段，满屏的滑稽，来自http://lvmaojun.com/huaji/
![](https://cdn.kakkk.net/img/729-3.jpg)


这两段动画都是我用祖传F12大法扒下来的，并为了适应本项目作出了一些修改（后面会说），在此特别鸣谢两位作者，如有侵权请联系本人删除。
## 关于代码
代码并不难，从我这种菜鸡手里写出来的东西能有多复杂对吧。

### 开发环境

- .NET 4.5
- Windows 10
- Visual Studio 2019

### 两个动画html

很多人可能会疑惑为什么这两个html里面有这么多乱码，实际上因为C#的WebBroswer控件的一些特性，也就是不能引用资源文件里的图片和JS，迫于无奈，我只能采取这种曲线救国的方式，把图片和JS转码成BASE64再合并到单个html文件里面。这个问题捣鼓了我好久的，没办法水平有限。

### 目录结构
```
│  FxxkBlueScreen.sln
│
└─FxxkBlueScreen
    │  App.config
    │  HotKeyHandler.cs	//热键屏蔽类
    │  MainForm.cs		//主窗口代码
    │  Main.Designer.cs
    │  Main.resx
    │  Program.cs
    │  SetsysVolume.cs	//声音操作类
    │
    ├─html
    │      Huaji.html	//滑稽动画HTML文件
    │      Loading.html	//载入动画HTML文件
    │
    ├─Icon
    │      Icon.ico		//图标文件
    │
    └─Properties
```
## 目前已知的Bug
- 多显示器下显示不正常
- 如果IE版本低于11，可能会出现异常
- 有可能会出现自己把自己杀掉的情况
- 如果系统本身就静音有可能会变成非静音状态

## 免责声明
本人仅作为FxxkBlueScreen的作者，任何由本项目造成的任何损失和影响本人概不负责。