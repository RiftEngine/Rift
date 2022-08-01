# Quickstart
Rift has a relatively simple frontend, so the learning curve of its most basic feature is pretty shallow.

**Note: in this quickstart guide, you will create a working *program*, but it won't be a fully fledged *game* (yet)**

## Installation
Install Rift. (TODO: Add detailed guide and add Rift to NuGet)

## Hello ~~World~~ Rift
In this section, you will create your first `Hello World` style program using Rift. 

First, you need to create your configuration file. Make a file called `config.json` and put it in your root project directory.

Inside of that file, add the following lines.

*Adding the json*
```json
{
  "Config": {
    "Name": "",
    "UseSave": false,
    "CreatorID": "",
    "VersionID": "",
    "CreationDate": ""
  }
}
```

Now fill out the fields:

`Name`: The name of your game. For now, it'll be called "Hello Rift".

`UseSave`: **Note: this is currently unsupported** whether or not the engine should save the user's progress between runs. Since this option is not yet supported, leave it false.

`CreatorID`: Your name or username.

`VersionID`: The [SemVer](https://semver.org/) version of this release.

`CreationDate`: The date you first created the config file.

Good job! You've made your first config file! That wasn't too hard, was it?


Now, you need to create a `Program` class and add the `Main` entry method.

*Creating the entry method*
```cs
public class Program {
	public static void Main(string[] args) {

	}
}
```

Inside of your `Main` method, you need to add a few lines.

First, add the `RiftEngine` import statement to your file, so that you can access the Rift features.

*Importing RiftEngine*
```cs
using RiftEngine;
```

Now, create an instance of the `RiftEngine.Config` class. This will store your configuration data.

*Referencing your configuration*
```cs
Config config = GameConfigManager.ReadGameConfiguration("config.json");
```
**Note: if you put your `config.json` file in a different directory, you need to change the path string accordingly.**

Next, you need to create your `Game` class. Rift is designed so that you can use multiple configurations for different games within the same project.

**Note: Rift can only run one game at a time.**

*Creating a `Game` class*
```cs
public class MyGame : Game {
    public MyGame(Config config) : base(config) { }
}
```

The line that is added inside the class is called the **constructor**. It is used to tell Rift what configuration file to use.

You're doing great! We only have a few more things to do!

Now let's override the `Init` function. This is a special function that runs once before the game starts. It is generally used to set up `Interactions`, which we will do in a moment.

*Overriding `Init`*
```cs
public override void Init() {

}
```

Good! Now we should add a few `Interactions`. 

Wait... what are those???

```
Interactions are a core aspect of Rift. They are used to trigger messages given to the player when different events happen. 

There are a few predefined events that Rift provides, but you can also create your own with custom trigger conditions. 
That is a more advanced concept, though, so it won't be covered in this quickstart. Refer to the Rift docs to learn more 
about custom events.
```

The predefined events we will be using right now are `GameStart` and `GameStop`. Just like the names imply, `GameStart` is triggered when the game starts, and `GameStop` when the game stops.

First, you need to create your interactions folder. If you're in Visual Studio, right click the solution name and click `Add`, then `New Folder`. Call the folder `interactions`.

Inside of `interactions`, create a text file called `GameStart.txt`. Inside, add the following line:
```
Hello
```

Now create another text file called `GameStop.txt`, and add this line:
```
Rift
```

Great!

Now let's add the interactions to the game class.

Inside of the overrided `Start` function, add the following lines.

*Adding the `Interactions`*
```cs
AddInteraction(new Interaction("GameStart", Events.GameStart, new FilePath("interactions/GameStart.txt")));
AddInteraction(new Interaction("GameStop", Events.GameStop, new FilePath("interactions/GameStop.txt")));
```
Let's break these lines down part by part.

`AddInteraction`: this is a function defined in the base `Game` class used to tell the engine to include a specific `Interaction` in the game.

`new Interaction`: this will create a new instance of the `Interaction` class, since we haven't defined our interaction already.

`"GameStart"`: this is the first parameter (called "interactionName") of the `Interaction` class. Each `Interaction` included in the game should have a unique name.

`Events.GameStart`: this is the reference to the predefined `GameStart` event that was referenced above. The second parameter of the `Interaction` class is the trigger event.

`new FilePath`: this creates a file path to the interaction text file. This is used to prevent Rift from writing the words `interactions/GameStart.txt` onto the screen. Instead, Rift will look for the contents of the `FilePath`.

`"interactions/GameStart.txt": this is the relative path to the interaction content.

These parts repeat on the second line, but `GameStop` replaces `GameStart`.

That's it! Go ahead and run your program, and you should see
```
Hello
Rift
```
printed to the console!

If that worked, congratulations! You made your first project with Rift! 

If it didn't go back and check that all of your code is exactly the same as the guide shows. If it still doesn't work, email `ContactREMCodes@gmail.com` to ask about an error message.

##### **PLEASE NOTE: Visual Studio compiles the debugs to a different directory than the root project folder. To overcome this, right-click `config.json`, `GameStart.txt`, and `GameStop.txt` and click `Properties` then change `Copy to output directory` to `Copy always`. Alternatively, you can copy the files to the output directory yourself.**