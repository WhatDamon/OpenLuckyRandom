/*
 * OpenLuckyRandom by @WhatDamon
 * Licensed under Apache License 2.0
 * Copyright © 2024-present Damon Lu
 * https://github.com/WhatDamon/OpenLuckyRandom
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;

namespace OpenLuckyRandom
{
    internal class FindCamera
    {
        // 枚举摄像头，代码源于 https://www.cnblogs.com/ives/p/18569933
        public class EnumDevices
        {
            /// <summary>
            /// 枚举视频设备
            /// </summary>
            public static IEnumerable<string> Devices
            {
                get
                {
                    IMoniker[] monikers = new IMoniker[5];
                    var devEnum = Activator.CreateInstance(Type.GetTypeFromCLSID(SystemDeviceEnum)) as ICreateDevEnum;
                    IEnumMoniker moniker;
                    if (devEnum.CreateClassEnumerator(VideoInputDevice, out moniker, 0) == 0)
                    {
                        while (true)
                        {
                            int hr = moniker.Next(1, monikers, IntPtr.Zero);
                            if (hr != 0 || monikers[0] == null)
                                break;
                            yield return GetName(monikers[0]);
                            foreach (var i in monikers)
                            {
                                if (i != null)
                                    Marshal.ReleaseComObject(i);
                            }
                        }
                        Marshal.ReleaseComObject(moniker);
                    }
                    Marshal.ReleaseComObject(devEnum);
                }
            }
            /// <summary>
            /// 获取设备名称
            /// </summary>
            /// <param name="moniker"></param>
            /// <returns></returns>
            static string GetName(IMoniker moniker)
            {
                IPropertyBag property;
                object value;
                object temp = null;
                try
                {
                    Guid guid = typeof(IPropertyBag).GUID;
                    moniker.BindToStorage(null, null, ref guid, out temp);
                    property = temp as IPropertyBag;
                    int hr = property.Read("FriendlyName", out value, null);
                    Marshal.ThrowExceptionForHR(hr);
                    return value as string;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    if (temp != null)
                    {
                        Marshal.ReleaseComObject(temp);
                    }
                }
            }
            static readonly Guid SystemDeviceEnum = new Guid(0x62BE5D10, 0x60EB, 0x11D0, 0xBD, 0x3B, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);
            static readonly Guid VideoInputDevice = new Guid(0x860BB310, 0x5D01, 0x11D0, 0xBD, 0x3B, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);
            [Flags]
            enum CDef
            {
                None = 0x0,
                ClassDefault = 0x1,
                BypassClassManager = 0x2,
                ClassLegacy = 0x4,
                MeritAboveDoNotUse = 0x8,
                DevmonCMGRDevice = 0x10,
                DevmonDMO = 0x20,
                DevmonPNPDevice = 0x40,
                DevmonFilter = 0x80,
                DevmonSelectiveMask = 0xF0
            }
            [ComImport]
            [SuppressUnmanagedCodeSecurity]
            [Guid("3127CA40-446E-11CE-8135-00AA004BB851")]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            interface IErrorLog
            {
                [PreserveSig]
                int AddError([In][MarshalAs(UnmanagedType.LPWStr)] string pszPropName, [In] System.Runtime.InteropServices.ComTypes.EXCEPINFO pExcepInfo);
            }
            [ComImport]
            [Localizable(false)]
            [SuppressUnmanagedCodeSecurity]
            [Guid("55272A00-42CB-11CE-8135-00AA004BB851")]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            interface IPropertyBag
            {
                [PreserveSig]
                int Read([In][MarshalAs(UnmanagedType.LPWStr)] string pszPropName, [MarshalAs(UnmanagedType.Struct)] out object pVar, [In] IErrorLog pErrorLog);

                [PreserveSig]
                int Write([In][MarshalAs(UnmanagedType.LPWStr)] string pszPropName, [In][MarshalAs(UnmanagedType.Struct)] ref object pVar);
            }

            [ComImport]
            [SuppressUnmanagedCodeSecurity]
            [Guid("29840822-5B84-11D0-BD3B-00A0C911CE86")]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            interface ICreateDevEnum
            {
                [PreserveSig]
                int CreateClassEnumerator([In][MarshalAs(UnmanagedType.LPStruct)] Guid pType, out IEnumMoniker ppEnumMoniker, [In] CDef dwFlags);
            }
        }
    }
}
