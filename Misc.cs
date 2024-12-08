/*
 * OpenLuckyRandom by @WhatDamon
 * Licensed under Apache License 2.0
 * Copyright © 2024-present Damon Lu
 * https://github.com/WhatDamon/OpenLuckyRandom
*/

using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Serilog;

namespace OpenLuckyRandom
{
    internal class Misc
    {
        /// <summary>
        /// 运行信息类
        /// </summary>
        internal class Runtime
        {
            /// <summary>
            /// 获取架构
            /// </summary>
            /// <returns></returns>
            public static string GetArch()
            {
                string _architecture;
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.X86:
                        _architecture = "x86";
                        break;
                    case Architecture.X64:
                        _architecture = "x64";
                        break;
                    case Architecture.Arm:
                        _architecture = "ARM32";
                        break;
                    case Architecture.Arm64:
                        _architecture = "ARM64";
                        break;
                    default:
                        _architecture = "Unknown";
                        break;
                }
                Log.Verbose($"Architecture: {_architecture}");
                return _architecture;
            }

            /// <summary>
            /// 是否为调试模式
            /// </summary>
            /// <returns></returns>
            public static bool IsDebug()
            {
                bool _isDebug = typeof(WndMain).Assembly.GetCustomAttributes(false)
                .OfType<DebuggableAttribute>()
                .Any(da => da.IsJITTrackingEnabled || da.IsJITOptimizerDisabled);
                Log.Verbose($"IsDebug: {_isDebug}");
                return _isDebug;
            }
        }

        /// <summary>
        /// 显示关于对话框
        /// </summary>
        /// <param name="fatherWnd">传递 `this`</param>
        public static void aboutDialogShow(Form fatherWnd)
        {
            TaskDialogPage page = new TaskDialogPage()
            {
                Text = "这是一个启发于某沃基于人脸识别随机抽人的玩具\n" +
                $"版本: {Assembly.GetExecutingAssembly().GetName().Version} - {Misc.Runtime.GetArch()}\n" +
                "由 What_Damon 开发 (严格意义上时拼贴组合)\n" +
                "使用 Apache 2.0 许可证开源\n" +
                "项目依赖:\n" +
                " · OpenCvSharp4\n" +
                " · OpenCvSharp4.Extensions\n" +
                " · OpenCvSharp4.runtime.win\n" +
                "注意! OpenCV 的依赖可能使用到了不同的许可证\n" +
                "请酌情考虑商用问题！\n\n" +
                $".NET版本: {Environment.Version.ToString()}",
                Heading = "关于 OpenLuckyRandom",
                Caption = "关于",
                Icon = TaskDialogIcon.Information,
                DefaultButton = TaskDialogButton.OK,
                Buttons = { TaskDialogButton.OK }
            };

            TaskDialogButton result = TaskDialog.ShowDialog(fatherWnd, page);
        }

        /// <summary>
        /// 打开项目仓库
        /// </summary>
        public static void openRepoURL()
        {
            Process.Start("explorer.exe", "https://github.com/WhatDamon/OpenLuckyRandom");
        }
    }
}
