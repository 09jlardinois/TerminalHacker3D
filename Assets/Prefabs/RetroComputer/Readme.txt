-- Retro computer set : px2 --
openplay 2019

version 1.1.0 changes :

1) Sample scene
+ new sample scene included : sample_px2_ver1.1.unity
old sample scene files are removed :
- sample_px2_comSet-opt.unity
- sample_px2_scene.unity

2) meshes and prefabs
+ new mesh : px2_monitor-screenSingle added
+ new prefab folder and prefab objects are added
+ FBX mesh orientation correction and re-imported :
: px2_desktop-opt
: px2_keyboard-low-opt
: px2_keyboard-mid-opt
: px2_monitor-opt
: px2_mouse-opt

3) textures
+ occulusion textures are added
+ enhanced texture : tex_px2com.png
+ add PSD files :
: px2_desktop.psd
: px2_keyboard.psd
: px2_keyboardlow.psd
: px2_monitor.psd
: px2_monitor_screen.psd
: tex_px2_screenSingle.psd
: px2com

- General-
This is a set of retro computer.
This set includes :
+ Monitor with separate screen mesh and material
+ Desktop computer
+ 2 types of keyboards (medium and low polygon)
+ 2 mouses (using medium and low polygon keyboard material)

- Monitor Sceen Material-
A screen texture is divided by 4, and I made 4 materials for examples.
In Standard shader "px2_monitor_screen 1", as you can see 'Offset' options are : x 1.5 / y 0. and the screen shows old DOS screen.
