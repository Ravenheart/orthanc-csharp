# orthanc-csharp
A prototype C# plugin wrapper for the Orthanc DICOM server

## Development plan
### Phase 1
This phase consists of porting the C++ plugin API to pure C# code. The port is as close to the original as possible,
namely it follows the exact naming of the original sources, every pointer in the original source is likewise a IntPtr
(with the exception of the context parameter which is its actual strong type for ease of use).

Every method has to free any unmanaged memory that it allocates in order to do a call into the Orthanc Core.
Any resources that have to be freed manually in C++ also must be freed in the ported C# code (ie with OrthancPluginFreeMemoryBuffer etc.)

### Phase 2
Create a high level library to handle all the wrapped C# code and expose .NET developer friendly functionality (no worries about 
allocating and freeing resources or marshaling ptrs to structures). This phase is all about creating a library that any .NET developer
can play with without worrying about memory allocations or subscribing callback or having to marshal stuff around. 

Ideally it should expose events and have all the callbacks implemented as listeners.

### Phase 3
This is mostly a unit testing phase where ideally every method and callback both in the low-level wrapper and the high level library
should be unit tested for errors.

## Usage
At the moment about half the functionallity of the plugin API is implemented. You can subscribe to rest callbacks and worklist modalities
and some other callbacks as well. Basic functionality is also implemented (logging, allocating and freeing buffers etc.)

To get started you can clone the repository and create your own plugin class (look at [TestPlugin.cs](https://github.com/Ravenheart/orthanc-csharp/blob/master/Orthanc.CSharp/TestPlugin.cs) ).
You must expose four mandatory methods for the Orthanc Plugin Manager to call.
(Use Robert Giesecke's excellent [Unmanaged Exports](https://www.nuget.org/packages/UnmanagedExports) to expose them to native lands)
```C#
        [DllExport("OrthancPluginInitialize", CallingConvention = CallingConvention.Cdecl)]
        public static int OrthancPluginInitialize(ref OrthancPluginContext c)
        {
            return 0;
        }

        [DllExport("OrthancPluginFinalize", CallingConvention = CallingConvention.Cdecl)]
        public static void OrthancPluginFinalize()
        {
        }

        [DllExport("OrthancPluginGetName", CallingConvention = CallingConvention.Cdecl)]
        public static string OrthancPluginGetName()
        {
            return "Orthanc C# Test Plugin";
        }

        [DllExport("OrthancPluginGetVersion", CallingConvention = CallingConvention.Cdecl)]
        public static string OrthancPluginGetVersion()
        {
            return "1.0.0.0";
        }
```

From there you must follow the official [Orthanc Plugin API](http://www.orthanc-server.com/static.php?page=documentation) 
documentation to get going with an actual plugin.
