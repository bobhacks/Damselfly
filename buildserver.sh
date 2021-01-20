# Read the version from disk.
version=`cat VERSION`

dotnet publish Damselfly.Web -r $1 -c Release --self-contained true /p:PublishSingleFile=true /p:PublishTrimmed=true /p:Version=$version /p:IncludeNativeLibrariesForSelfExtract=true

