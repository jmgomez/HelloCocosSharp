namespace HelloCocos

open System
open MonoTouch.UIKit
open MonoTouch.Foundation
open CocosSharp

type HelloScene () = 
    inherit CCLayerColor()
    do 
       base.Color <- CCColor3B.Blue
       base.Opacity <- 255uy
    
    override x.AddedToScene() = 
        x.Scene.SceneResolutionPolicy <- CCSceneResolutionPolicy.ShowAll

        let label = CCLabelTtf("Hello from FSharp!","MarkerFelt",22.F)
        label.Position <- x.VisibleBoundsWorldspace.Center
        label.HorizontalAlignment <- CCTextAlignment.Center
        label.VerticalAlignment <- CCVerticalTextAlignment.Center
        label.Dimensions <- x.ContentSize
        label.AnchorPoint <- CCPoint.AnchorMiddle
        label.Color <- CCColor3B.White

        x.AddChild label
    
    static member HelloLayerScene(mainWindows : CCWindow) = 
        let scene = new CCScene(mainWindows)
        let layer = HelloScene()
        scene.AddChild layer
        scene
            


type HelloCocosApplicationDelegate () = 
    inherit CCApplicationDelegate()
    override x.ApplicationDidFinishLaunching(app,mainWindow) = 
        app.ContentRootDirectory <- "Content"
        let scene = HelloScene.HelloLayerScene mainWindow
        mainWindow.RunWithScene scene


[<Register("AppDelegate")>]
type AppDelegate() = 
    inherit UIApplicationDelegate()
    override this.FinishedLaunching app = 
        let applcation = new CCApplication()
        applcation.ApplicationDelegate <- HelloCocosApplicationDelegate()
        applcation.StartGame()

module Main = 
    [<EntryPoint>]
    let main args = 
        UIApplication.Main(args, null, "AppDelegate")
        0
