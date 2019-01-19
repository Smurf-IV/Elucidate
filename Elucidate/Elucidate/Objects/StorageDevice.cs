using System;
using System.IO;

namespace Elucidate.Objects
{
    public class StorageDevice
    {
        public string Caption { get; set; }
        public string DeviceId { get; set; }
        public DriveType DriveType { get; set; }
        public string DriveLetter { get; set; }
        public string Name { get; set; }
        public string FileSystem { get; set; }
        public UInt32 Capacity { get; set; }
        public UInt32 FreeSpace { get; set; }
        public string Status { get; set; }
    }
}

//class Win32_Volume : CIM_StorageVolume
//{
//    uint16 Access;
//    boolean Automount;
//    uint16 Availability;
//    uint64 BlockSize;
//    uint64 Capacity;
//    string Caption;
//    boolean Compressed;
//    uint32 ConfigManagerErrorCode;
//    boolean ConfigManagerUserConfig;
//    string CreationClassName;
//    string Description;
//    string DeviceID;
//    boolean DirtyBitSet;
//    string DriveLetter;
//    uint32 DriveType;
//    boolean ErrorCleared;
//    string ErrorDescription;
//    string ErrorMethodology;
//    string FileSystem;
//    uint64 FreeSpace;
//    boolean IndexingEnabled;
//    datetime InstallDate;
//    string Label;
//    uint32 LastErrorCode;
//    uint32 MaximumFileNameLength;
//    string Name;
//    uint64 NumberOfBlocks;
//    string PNPDeviceID;
//    uint16[] PowerManagementCapabilities;
//    boolean PowerManagementSupported;
//    string Purpose;
//    boolean QuotasEnabled;
//    boolean QuotasIncomplete;
//    boolean QuotasRebuilding;
//    string Status;
//    uint16 StatusInfo;
//    string SystemCreationClassName;
//    string SystemName;
//    uint32 SerialNumber;
//    boolean SupportsDiskQuotas;
//    boolean SupportsFileBasedCompression;
//};