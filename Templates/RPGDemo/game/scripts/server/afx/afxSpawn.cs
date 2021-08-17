//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
// Arcane-FX
//
// Copyright (C) Faust Logic, Inc.
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

$Game::DefaultPlayerClass = "Player";
$Game::DefaultPlayerDataBlock = "OrcMageData";

function GameConnection::onClientEnterGame(%this)
{
   // This function currently relies on some helper functions defined in
   // core/scripts/server/spawn.cs. For custom spawn behaviors one can either
   // override the properties on the SpawnSphere's or directly override the
   // functions themselves.

   // Sync the client's clocks to the server's
   commandToClient(%this, 'SyncClock', $Sim::Time - $Game::StartTime);

   // This is where we create the afxCamera
   %this.camera = new afxCamera()
   {
      datablock = DefaultAFXCameraData;
   };

   MissionCleanup.add( %this.camera );
   %this.camera.scopeToClient(%this);

   // Start everyone with a zero score when they connect
   %this.score = 0;

   // Find a spawn point for the player
   %playerSpawnPoint = pickPlayerSpawnPoint($Game::DefaultPlayerSpawnGroups);
   // Spawn a camera for this client using the found %spawnPoint
   %this.spawnPlayer(%playerSpawnPoint);

   if (theLevelInfo.startupEffectsFunc !$= "")
   {
     call(theLevelInfo.startupEffectsFunc);
   }
}

function GameConnection::onClientLeaveGame(%this)
{
   // Cleanup the camera
   if (isObject(%this.camera))
      %this.camera.delete();
   // Cleanup the player
   if (isObject(%this.player))
      %this.player.delete();
}

//-----------------------------------------------------------------------------
// GameConnection::spawnPlayer() is responsible for spawning a player for a
// client
//-----------------------------------------------------------------------------
function GameConnection::spawnPlayer(%this, %spawnPoint, %spawnClass, %spawnDataBlock)
{
   // clear out old linkages between player and client
   if (isObject(%this.player))
   {
     %this.player.client = "";
     %this.player = "";
   }

   if (%spawnClass $= "")
     %spawnClass = $Game::DefaultPlayerClass;

   if (%spawnDataBlock $= "")
     %spawnDataBlock = $Game::DefaultPlayerDataBlock;

   // Attempt to treat %spawnPoint as an object
   if (getWordCount(%spawnPoint) == 1 && isObject(%spawnPoint))
   {
      // Overrides by the %spawnPoint
      if (isDefined("%spawnPoint.spawnClass"))
      {
         %spawnClass = %spawnPoint.spawnClass;
         %spawnDataBlock = %spawnPoint.spawnDatablock;
      }

      // This may seem redundant given the above but it allows
      // the SpawnSphere to override the datablock without
      // overriding the default player class
      if (isDefined("%spawnPoint.spawnDatablock"))
         %spawnDataBlock = %spawnPoint.spawnDatablock;

      %spawnProperties = %spawnPoint.spawnProperties;
      %spawnScript     = %spawnPoint.spawnScript;

      %spawnProperties = "client = " @ %this @ ";" @ %spawnProperties; 

      // Spawn with the engine's Sim::spawnObject() function
      %player = spawnObject(%spawnClass, %spawnDataBlock, "",
                            %spawnProperties, %spawnScript);

      // If we have an object do some initial setup
      if (isObject(%player))
      {
         // Set the transform to %spawnPoint's transform
         %player.setTransform(%spawnPoint.getTransform());
      }
      else
      {
         // If we weren't able to create the player object then warn the user
         if (isDefined("%spawnDatablock"))
         {
               MessageBoxOK("Spawn Player Failed",
                             "Unable to create a player with class " @ %spawnClass @ 
                             " and datablock " @ %spawnDatablock @ ".\n\nStarting as an Observer instead.",
                             %this @ ".spawnCamera();");
         }
         else
         {
               MessageBoxOK("Spawn Player Failed",
                              "Unable to create a player with class " @ %spawnClass @
                              ".\n\nStarting as an Observer instead.",
                              %this @ ".spawnCamera();");
         }
      }
   }
   else
   {
      // Create a default player
      %player = spawnObject(%spawnClass, %spawnDataBlock);

      // Treat %spawnPoint as a transform
      %player.setTransform(%spawnPoint);
   }

   // If we didn't actually create a player object then bail
   if (!isObject(%player))
   {
      // Make sure we at least have a camera
      %this.spawnCamera(%spawnPoint);

      return;
   }

   // AFX SCRIPT BLOCK <<
   // Create player's spellbook
   %my_spellbook = new afxSpellBook() 
   {
     dataBlock = afxDemoSpellBookData;
   };
   MissionCleanup.add(%my_spellbook);
   %this.spellbook = %my_spellbook;

   schedule(0, 0, "sendClientPlayerToClient", %this, %player);
   schedule(0, 0, "sendPlayerSpellBookToClient", %this, %my_spellbook);
   // AFX SCRIPT BLOCK >>

   // Update the default camera to start with the player
   if (isObject(%this.camera))
   {
      if (%player.getClassname() $= "Player")
         %this.camera.setTransform(%player.getEyeTransform());
      else
         %this.camera.setTransform(%player.getTransform());

      // AFX SCRIPT BLOCK <<
      // We set the camera system to run in 3rd person mode around the %player
      %this.camera.setCameraSubject(%player);   
      %this.camera.setThirdPersonMode();
      %this.camera.setThirdPersonOffset("0 0 3"); // this is default 3rd-person offset
      %this.camera.setThirdPersonDistance(3); // this is default 3rd-person distance
      %this.camera.setThirdPersonSnap();
      %this.setCameraObject(%this.camera);
      // AFX SCRIPT BLOCK >>
   }

   // Add the player object to MissionCleanup so that it
   // won't get saved into the level files and will get
   // cleaned up properly
   MissionCleanup.add(%player);

   // Store the client object on the player object for
   // future reference
   %player.client = %this;

   // Player setup...
   if (%player.isMethod("setShapeName"))
      %player.setShapeName(%this.playerName);

   if (%player.isMethod("setEnergyLevel"))
      %player.setEnergyLevel(%player.getDataBlock().maxEnergy);
      
   // AFX SCRIPT BLOCK <<
   if (%player.isMethod("setLookAnimationOverride"))
      %player.setLookAnimationOverride(true);
   // AFX SCRIPT BLOCK >>      

   // Give the client control of the player
   %this.player = %player;

   // Give the client control of the camera if in the editor
   if( $startWorldEditor )
   {
      %control = %this.camera;
      %control.setFlyMode();
      EditorGui.syncCameraGui();
   }
   else
      %control = %player;
      
   %this.setControlObject(%control);
}