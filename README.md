# <img src="assets/OpenLuckyRandom.png" width="32" height="32"/> OpenLuckyRandom

![GitHub top language](https://img.shields.io/github/languages/top/WhatDamon/OpenLuckyRandom)
![GitHub Release](https://img.shields.io/github/v/release/WhatDamon/OpenLuckyRandom)
![GitHub Downloads](https://img.shields.io/github/downloads/WhatDamon/OpenLuckyRandom/total)
![GitHub commit activity](https://img.shields.io/github/commit-activity/t/WhatDamon/OpenLuckyRandom)
![GitHub Issues](https://img.shields.io/github/issues/WhatDamon/OpenLuckyRandom)
![GitHub Pull Requests](https://img.shields.io/github/issues-pr/WhatDamon/OpenLuckyRandom)
![GitHub repo size](https://img.shields.io/github/repo-size/WhatDamon/OpenLuckyRandom)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FWhatDamon%2FOpenLuckyRandom.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FWhatDamon%2FOpenLuckyRandom?ref=badge_shield)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FWhatDamon%2FOpenLuckyRandom.svg?type=shield&issueType=security)](https://app.fossa.com/projects/git%2Bgithub.com%2FWhatDamon%2FOpenLuckyRandom?ref=badge_shield&issueType=security)


启发于某沃一体机中的 LuckyRandom 人脸识别随机抽人，使用 WinForms 开发的玩具

与某沃一样采用了 `OpenCvSharp`，都是用 C# 编写，只不过他们开发的版本使用到了 XAML (UWP)

可以给带有摄像头的旧某沃一体机或者带有摄像头的鸿某一体机随机抽人使用 (逃

本项目使用了 Qwen 协助开发

## 特点

- 允许切换摄像头
- 有一定的灵活性
- 更小的体积（相比原版而言）
- 支持大多数 Windows 设备而非限于某沃一体机

## 截图

![主窗口](./screenshots/WndMain.png)

*注: OBS Virtual Camera 正在播放的视频来自[此处](https://www.bilibili.com/video/BV1ex411P7Kc) (本项目仅使用该视频用于测试，与本程序无关)*

## 须知

使用本软件前请事先安装好 `.NET 6 桌面运行时` ，您可以点击[此处](https://dotnet.microsoft.com/zh-cn/download/dotnet/6.0)直接前往下载！

针对个人信息问题无需担心，本程序完全本地运行，不经过云端服务器！

## 开发

本项目使用到了 `.NET 6` ，进行开发前请安装对应 SDK，您也可以升级 SDK 版本到 `.NET 8` 或更新版本！

推荐直接使用 Visual Studio 或者 JetBrains Rider 进行开发

如果愿意，您也可以尝试将本项目向下移植到较为老旧的 `.NET Framework` 上 (一般推荐直接使用最新的 `.NET`)

## 许可证

本项目使用 **Apache 2.0** 许可证开源，OpenCV 可能还是用了使用 LGPL 的许可证开源的程序

[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FWhatDamon%2FOpenLuckyRandom.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FWhatDamon%2FOpenLuckyRandom?ref=badge_large)