namespace RcloneLibrary.Models.OperationsDtos
{
    public class FsInfoResponse
    {
        public class FsInfoFeaturesInfo
        {
            public Dictionary<string, bool> Features { get; set; }
            public List<string> Hashes { get; set; }
        }

        public class FsInfoMetadataInfo
        {
            public class FsInfoSystemMetadataInfo
            {
                public class FsInfoFieldInfo
                {
                    public string Help { get; set; }
                    public string Type { get; set; }
                    public string Example { get; set; }
                }

                public FsInfoFieldInfo Atime { get; set; }
                public FsInfoFieldInfo Btime { get; set; }
                public FsInfoFieldInfo Gid { get; set; }
                public FsInfoFieldInfo Mode { get; set; }
                public FsInfoFieldInfo Mtime { get; set; }
                public FsInfoFieldInfo Rdev { get; set; }
                public FsInfoFieldInfo Uid { get; set; }
            }

            public FsInfoSystemMetadataInfo System { get; set; }
            public string Help { get; set; }
        }

        public FsInfoFeaturesInfo Features { get; set; }
        public string Name { get; set; }
        public int Precision { get; set; }
        public string Root { get; set; }
        public string String { get; set; }
        public FsInfoMetadataInfo MetadataInfo { get; set; }
    }
}

/*
{
    // optional features and whether they are available or not
    "Features": {
        "About": true,
        "BucketBased": false,
        "BucketBasedRootOK": false,
        "CanHaveEmptyDirectories": true,
        "CaseInsensitive": false,
        "ChangeNotify": false,
        "CleanUp": false,
        "Command": true,
        "Copy": false,
        "DirCacheFlush": false,
        "DirMove": true,
        "Disconnect": false,
        "DuplicateFiles": false,
        "GetTier": false,
        "IsLocal": true,
        "ListR": false,
        "MergeDirs": false,
        "MetadataInfo": true,
        "Move": true,
        "OpenWriterAt": true,
        "PublicLink": false,
        "Purge": true,
        "PutStream": true,
        "PutUnchecked": false,
        "ReadMetadata": true,
        "ReadMimeType": false,
        "ServerSideAcrossConfigs": false,
        "SetTier": false,
        "SetWrapper": false,
        "Shutdown": false,
        "SlowHash": true,
        "SlowModTime": false,
        "UnWrap": false,
        "UserInfo": false,
        "UserMetadata": true,
        "WrapFs": false,
        "WriteMetadata": true,
        "WriteMimeType": false
    },
    // Names of hashes available
    "Hashes": [
            "md5",
            "sha1",
            "whirlpool",
            "crc32",
            "sha256",
            "dropbox",
            "mailru",
            "quickxor"
    ],
    "Name": "local",        // Name as created
    "Precision": 1,         // Precision of timestamps in ns
    "Root": "/",            // Path as created
    "String": "Local file system at /", // how the remote will appear in logs
    // Information about the system metadata for this backend
    "MetadataInfo": {
        "System": {
            "atime": {
                "Help": "Time of last access",
                "Type": "RFC 3339",
                "Example": "2006-01-02T15:04:05.999999999Z07:00"
            },
            "btime": {
                "Help": "Time of file birth (creation)",
                "Type": "RFC 3339",
                "Example": "2006-01-02T15:04:05.999999999Z07:00"
            },
            "gid": {
                "Help": "Group ID of owner",
                "Type": "decimal number",
                "Example": "500"
            },
            "mode": {
                "Help": "File type and mode",
                "Type": "octal, unix style",
                "Example": "0100664"
            },
            "mtime": {
                "Help": "Time of last modification",
                "Type": "RFC 3339",
                "Example": "2006-01-02T15:04:05.999999999Z07:00"
            },
            "rdev": {
                "Help": "Device ID (if special file)",
                "Type": "hexadecimal",
                "Example": "1abc"
            },
            "uid": {
                "Help": "User ID of owner",
                "Type": "decimal number",
                "Example": "500"
            }
        },
        "Help": "Textual help string\n"
    }
}
*/