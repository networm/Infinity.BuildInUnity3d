# Infinity BuildInUnity3d

Unity3d sub system of Infinity Build.

## Install

Add this as a submodule in `Editor` folder.

```
cd YourUnity3dProject
git submodule add git@github.com:networm/Infinity.BuildInUnity3d.git Assets/Editor/BuildInUnity3d
```

## Usage

### Windows

Run in command line

```
"C:\Program Files\Unity\Editor\Unity.exe" -batchmode -quit -projectPath "C:\Unity3d\ExampleProject" -buildTarget win64 -logFile $stdout -executeMethod Infinity.Build.BuildPlayer
```

### Mac OS X

Run in terminal

```
"/Applications/Unity/Unity.app/Contents/MacOS/Unity" -batchmode -quit -projectPath "~/Unity3d/ExampleProject" -buildTarget win64 -logFile $stdout -executeMethod Infinity.Build.BuildPlayer
```

## LICENSE

MIT LICENSE
