#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="AssemblyInfo.cs" company="Smurf-IV">
// 
//  Copyright (C) 2010-2021 Simon Coghlan (Aka Smurf-IV) & BlueBlock 2018
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 2 of the License, or
//   any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see http://www.gnu.org/licenses/.
//  </copyright>
//  <summary>
//  Url: https://github.com/Smurf-IV/Elucidate
//  Email: https://github.com/Smurf-IV
//  </summary>
// --------------------------------------------------------------------------------------------------------------------
#endregion

using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Elucidate")]
[assembly: AssemblyDescription("SnapRAID GUI Implementation")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Smurf-IV & BlueBlock")]
[assembly: AssemblyProduct("Elucidate")]
[assembly: AssemblyCopyright("Copyright © BlueBlock 2018 / Copyright © Simon Coghlan (Aka Smurf-IV) 2010-2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("739868EC-E5CC-4F24-9D9F-88FDBD08371A")]

// Version information for an assembly consists of the following four values:
//
//      Major Version - Year
//      Minor Version - Month
//      Build Number  - Increment
//      Revision      - Day
//
[assembly: AssemblyVersion("2021.4.1030.4")]
[assembly: AssemblyFileVersion("21.4.1030.4")]
[assembly: NeutralResourcesLanguage("en-US")]
// TODO: Add more relevant hints here
[assembly: Dependency("System", LoadHint.Always)]
[assembly: Dependency("System.Drawing", LoadHint.Always)]
[assembly: Dependency("System.IO", LoadHint.Always)]
[assembly: Dependency("System.Windows.Forms", LoadHint.Always)]
[assembly: Dependency("System.Xml", LoadHint.Always)]

[assembly: Dependency("Alphaleonis.Win32.Filesystem", LoadHint.Always)]
[assembly: Dependency("CommandLine", LoadHint.Always)]
[assembly: Dependency("Krypton.Toolkit", LoadHint.Always)]
[assembly: Dependency("Krypton.Navigator", LoadHint.Always)]
[assembly: Dependency("Exceptionless", LoadHint.Always)]
[assembly: Dependency("Exceptionless.Nlog", LoadHint.Always)]
[assembly: Dependency("Exceptionless.Windows", LoadHint.Always)]
[assembly: Dependency("NLog", LoadHint.Always)]
